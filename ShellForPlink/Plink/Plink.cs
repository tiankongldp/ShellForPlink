using System;
using System.Timers;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;

namespace ShellForPlink
{
    class Plink
    {
        private PlinkConfig mPlinkCf;
        public PlinkConfig PlinkCf
        {
            get { return mPlinkCf; }
            set { mPlinkCf = value; }
        }

        private Process mPlinkProcess;

        private ConnectionStatus curStatus;
        public ConnectionStatus CurStatus
        {
            get { return curStatus; }
            set { OldStatus = curStatus; curStatus = value; }
        }
        private ConnectionStatus OldStatus;

        private Socket mLoopbackSocket;
        private Timer RevPingBackTimer;
        private int PingFaildTimes;

        private Timer ReConnDelayTimer;
        
        public event DataOutputHandler OutputDataReceived;
        public event ConnectionStateChangeHandler ConnectionStateChanged;

        public Plink()
        {
            mPlinkProcess = new Process();
            mPlinkProcess.StartInfo.FileName = "plink.exe";
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
            if (OutputDataReceived == null || e.Data == null || e.Data.Length ==  0)
            {
                OutputDataReceived(1, "data null");
                return;
            }
            else if (e.Data.Contains("password:"))
            {
                 mPlinkProcess.StandardInput.WriteLine(mPlinkCf.Password);
                OutputDataReceived(1, e.Data);
            }
            else if (e.Data.Contains("Remote port forwarding") && e.Data.Contains("enabled"))
            {
                CurStatus = ConnectionStatus.Connected;
                ConnectionStateChanged.BeginInvoke(OldStatus, CurStatus, null, this);
                OutputDataReceived(1, e.Data);
            }
            else if ((e.Data.Contains("Opening connection to") ||
                e.Data.Contains("Received remote port") ||
                e.Data.Contains("Attempting to forward remote port to") ||
                e.Data.Contains("Forwarded port opened successfully") ||
                e.Data.Contains("Forwarded port closed")) && PlinkCf.HidePortConnInfo)
            {

            }
            else
                OutputDataReceived(1, e.Data);
        }
        private void mPlinkProcess_Exited(object sender, System.EventArgs e)
        {
            mPlinkProcess = new Process();
            mPlinkProcess.StartInfo.FileName = "plink.exe";
            mPlinkProcess.StartInfo.UseShellExecute = false;
            mPlinkProcess.StartInfo.RedirectStandardInput = true;
            mPlinkProcess.StartInfo.RedirectStandardOutput = true;
            mPlinkProcess.StartInfo.RedirectStandardError = true;
            mPlinkProcess.StartInfo.CreateNoWindow = true;
            mPlinkProcess.EnableRaisingEvents = true;

            mPlinkProcess.OutputDataReceived += new DataReceivedEventHandler(mPlinkProcess_ErrorOrOutputDataReceived);
            mPlinkProcess.ErrorDataReceived += new DataReceivedEventHandler(mPlinkProcess_ErrorOrOutputDataReceived);
            mPlinkProcess.Exited += new System.EventHandler(mPlinkProcess_Exited);


            OutputDataReceived(0, "plink程序异常退出");
            CurStatus = ConnectionStatus.ConnectAborted;
            if (this.ConnectionStateChanged != null)
                this.ConnectionStateChanged(this.OldStatus, this.CurStatus);
            
            if (mPlinkCf.ReConnAfterBreak)
                ReConnDelayTimer.Enabled = true;
        }
        private void ReConnDelayTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            OutputDataReceived(0, "重新连接");
            CurStatus = ConnectionStatus.ReConnecting;
            if (this.ConnectionStateChanged != null)
                this.ConnectionStateChanged(this.OldStatus, this.CurStatus);

            this.Connect();
        }

        public void Start()
        {
            this.ArgVailidata();
            ReConnDelayTimer.Interval = mPlinkCf.ReConnDelay * 1000;
            CurStatus = ConnectionStatus.StartConnecting;
            this.Connect();
        }
        public void Stop()
        {
            CurStatus = ConnectionStatus.ManualStoped;
            this.DisConnect();
        }

        private void Connect()
        {
            try
            {
                ReConnDelayTimer.Enabled = false;

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
                //不发送换行获取不到输出，待查
                mPlinkProcess.StandardInput.WriteLine("");
                mPlinkProcess.StandardInput.Flush();
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
                OutputDataReceived(0, "用户中断连接");
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
        }
    }

    public delegate void DataOutputHandler(int type, string data);
    public delegate void ConnectionStateChangeHandler(ConnectionStatus lastState, ConnectionStatus curState);

    public enum ConnectionStatus
    {
        idle,
        StartConnecting,
        ReConnecting,
        SendingUseName,
        SendingPassword,
        Authenticated,
        Connected,
        ConnectAborted,
        ManualStoped,
        PingFailedStopd
    }
}
