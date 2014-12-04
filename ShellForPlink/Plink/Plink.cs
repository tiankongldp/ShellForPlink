using System;
using System.Timers;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace ShellForPlink
{
    internal class Plink
    {
        private PlinkConfig mPlinkCf;
        public PlinkConfig PlinkCf
        {
            get { return mPlinkCf; }
            set { mPlinkCf = value; }
        }

        public string StartupPath = "";

        private Process mPlinkProcess;

        private ConnectionStatus curStatus;
        public ConnectionStatus CurStatus
        {
            get { return curStatus; }
            set { OldStatus = curStatus; curStatus = value; }
        }
        private ConnectionStatus OldStatus;

        private Timer ReConnDelayTimer;
        
        public event DataOutputHandler OutputDataReceived;
        public event ConnectionStateChangeHandler ConnectionStateChanged;

        public Plink()
        {
            mPlinkProcess = new Process();
            //mPlinkProcess.StartInfo.FileName = "plink.exe";
            mPlinkProcess.StartInfo.UseShellExecute = false;
            mPlinkProcess.StartInfo.RedirectStandardInput = true;
            mPlinkProcess.StartInfo.RedirectStandardOutput = true;
            mPlinkProcess.StartInfo.RedirectStandardError = true;
            mPlinkProcess.StartInfo.CreateNoWindow = true;
            mPlinkProcess.EnableRaisingEvents = true;

            mPlinkProcess.OutputDataReceived += new DataReceivedEventHandler(mPlinkProcess_ErrorOrOutputDataReceived);
            mPlinkProcess.ErrorDataReceived += new DataReceivedEventHandler(mPlinkProcess_ErrorOrOutputDataReceived);
            mPlinkProcess.Exited += new System.EventHandler(mPlinkProcess_Exited);

            ReConnDelayTimer = new Timer();
            ReConnDelayTimer.Enabled = false;
            ReConnDelayTimer.Interval = 5 * 1000;
            ReConnDelayTimer.Elapsed += new ElapsedEventHandler(ReConnDelayTimer_Elapsed);

            this.CurStatus = ConnectionStatus.idle;
        }

        private void mPlinkProcess_ErrorOrOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null)
            {
                if (OutputDataReceived != null)
                    OutputDataReceived(1, "e.Data null");
                return;
            }

            if (e.Data.Length ==  0)
            {
                if (OutputDataReceived != null)
                    OutputDataReceived(1, e.Data);
                return;
            }
            else if (Utility.IsLookingup(e.Data))
            {
                if (curStatus == ConnectionStatus.idle)
                    CurStatus = ConnectionStatus.StartConnecting;
                else if (CurStatus != ConnectionStatus.ReConnecting && CurStatus != ConnectionStatus.StartConnecting)
                    CurStatus = ConnectionStatus.ReConnecting;
            }
            else if (Utility.IsStoreKey(e.Data))
            {
                mPlinkProcess.StandardInput.WriteLine("n");
                CurStatus = ConnectionStatus.KeyConfirm;
            }
            else if (Utility.IsUsername(e.Data))
            {
                mPlinkProcess.StandardInput.WriteLine(mPlinkCf.Password);
                CurStatus = ConnectionStatus.SendingUseName;
            }
            else if (Utility.IsPassword(e.Data))
            {
                CurStatus = ConnectionStatus.SendingPassword;
            }
            else if (Utility.IsAccessGranted(e.Data))
            {
                CurStatus = ConnectionStatus.Authenticated;
            }
            else if (Utility.IsLocalportForward(e.Data) || Utility.IsDynamicSocks(e.Data))
            {
                if (curStatus == ConnectionStatus.Connected)
                {
                    if (OutputDataReceived != null)
                        OutputDataReceived(1, e.Data);
                    return;
                }
                else
                    CurStatus = ConnectionStatus.Connected;
            }
            else if (PlinkCf.LoopBackPing && Utility.IsRemoteportForward(e.Data))
            {
                CurStatus = ConnectionStatus.PingTunnelOpened;
            }
            else if (Utility.IsPortConnInfo(e.Data))
            {
                if (PlinkCf.HidePortConnInfo)
                    return;
                else
                {
                    if (OutputDataReceived != null)
                        OutputDataReceived(1, e.Data);
                    return;
                }
            }
            else
            {
                if (OutputDataReceived != null)
                    OutputDataReceived(1, e.Data);
                return;
            }

            ConnectionStateChanged.BeginInvoke(OldStatus, CurStatus, null, this);
            if (OutputDataReceived != null)
                OutputDataReceived(1, e.Data);
        }
        private void mPlinkProcess_Exited(object sender, System.EventArgs e)
        {
            mPlinkProcess = new Process();
            mPlinkProcess.StartInfo.FileName = StartupPath + @"\plink.exe";
            mPlinkProcess.StartInfo.UseShellExecute = false;
            mPlinkProcess.StartInfo.RedirectStandardInput = true;
            mPlinkProcess.StartInfo.RedirectStandardOutput = true;
            mPlinkProcess.StartInfo.RedirectStandardError = true;
            mPlinkProcess.StartInfo.CreateNoWindow = true;
            mPlinkProcess.EnableRaisingEvents = true;

            mPlinkProcess.OutputDataReceived += new DataReceivedEventHandler(mPlinkProcess_ErrorOrOutputDataReceived);
            mPlinkProcess.ErrorDataReceived += new DataReceivedEventHandler(mPlinkProcess_ErrorOrOutputDataReceived);
            mPlinkProcess.Exited += new System.EventHandler(mPlinkProcess_Exited);

            CurStatus = ConnectionStatus.ConnectAborted;
            if (this.ConnectionStateChanged != null)
                ConnectionStateChanged.BeginInvoke(OldStatus, CurStatus, null, null);
            OutputDataReceived(0, "plink程序异常退出");

            if (mPlinkCf.ReConnAfterBreak)
                ReConnDelayTimer.Enabled = true;
        }
        private void ReConnDelayTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            OutputDataReceived(0, "重新连接");
            this.Connect();
        }

        public void Start()
        {
            this.ArgVailidata();
            ReConnDelayTimer.Interval = mPlinkCf.ReConnDelay * 1000;
            this.Connect();
        }
        public void Stop(ConnectionStatus stopType)
        {
            CurStatus = stopType;
            this.DisConnect();
        }

        private void Connect()
        {
            try
            {
                ReConnDelayTimer.Enabled = false;

                mPlinkProcess.StartInfo.FileName = StartupPath + @"\plink.exe";
                mPlinkProcess.StartInfo.Arguments = mPlinkCf.FullArgument;
                mPlinkProcess.Start();
                
                try
                {
                    mPlinkProcess.BeginErrorReadLine();
                    OutputDataReceived(0, "BeginErrorReadLine Success");
                }
                catch (Exception e)
                {
                    OutputDataReceived(0, "BeginErrorReadLine" + e.Message);
                }
                
                try
                {
                    mPlinkProcess.BeginOutputReadLine();
                    OutputDataReceived(0, "BeginOutputReadLine Success");
                }
                catch (Exception e)
                {
                    OutputDataReceived(0, "BeginOutputReadLine" + e.Message);
                }
                //不发送换行获取不到没有换行符的输出
                //mPlinkProcess.StandardInput.WriteLine("n");
                //mPlinkProcess.StandardInput.Flush();
            }
            catch (Exception e)
            {
                OutputDataReceived(0, e.Message);
            }
        }
        private void DisConnect()
        {
            try
            {
                if (!mPlinkProcess.HasExited)
                {
                    mPlinkProcess.StandardInput.WriteLine("");
                    System.Threading.Thread.Sleep(200);

                    try
                    {
                        mPlinkProcess.CancelErrorRead();
                        OutputDataReceived(0, "CancelErrorRead Success");
                    }
                    catch (Exception e)
                    {
                        OutputDataReceived(0, "CancelErrorRead" + e.Message);
                    }
                    try
                    {
                        mPlinkProcess.CancelOutputRead();
                        OutputDataReceived(0, "CancelOutputRead Success");
                    }
                    catch (Exception e)
                    {
                        OutputDataReceived(0, "CancelOutputRead" + e.Message);
                    }
                    
                    mPlinkProcess.Kill();
                    mPlinkProcess.Close();
                }
            }
            catch (Exception e)
            {
                OutputDataReceived(0, e.Message);
            }
            finally
            {
                if (CurStatus == ConnectionStatus.ManualStoped)
                {
                    ReConnDelayTimer.Enabled = false;
                    OutputDataReceived(0, "用户中断连接");
                }
                else if (CurStatus == ConnectionStatus.PingFailedStopd)
                {
                    ReConnDelayTimer.Enabled = true;
                    OutputDataReceived(0, "PingFailed，中断连接");
                }
            }
        }

        private void ArgVailidata()
        {
            if (this.mPlinkCf == null)
                throw new Exception("配置为空！");
            else if (this.mPlinkCf.ServerIP.Length == 0)
                throw new Exception("服务器IP为空！");
            else if (this.mPlinkCf.ServerPort == 0)
                throw new Exception("服务器Port为空！");
            else if (this.mPlinkCf.Username.Length == 0)
                throw new Exception("用户名为空！");
            else if (!this.mPlinkCf.UsePrivateKey && this.mPlinkCf.Password.Length == 0)
                throw new Exception("密码为空！");
            if (StartupPath.Length == 0 )
                throw new Exception("程序目录未知！");
            if (!File.Exists(StartupPath + @"\plink.exe"))
            {
                throw new Exception("未找到plink.exe");
            }
            
        }
    }

    public delegate void DataOutputHandler(int type, string data);
    public delegate void ConnectionStateChangeHandler(ConnectionStatus lastState, ConnectionStatus curState);

    public enum ConnectionStatus
    {
        idle,
        StartConnecting,
        ReConnecting,
        KeyConfirm,
        SendingUseName,
        SendingPassword,
        Authenticated,
        Connected,
        PingTunnelOpened,
        ConnectAborted,
        PingFailedStopd,
        ManualStoped
    }
}
