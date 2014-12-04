using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace ShellForPlink
{
    public partial class frmMain : Form
    {
        #region "属性"

        private PlinkConfigCollection colPlinkConfig;
        private PlinkConfig CurPlinkConfig
        {
            get { return this.colPlinkConfig.CurConfig; }
        }

        private Plink plink;

        LoopBackPing Ping;

        private const string ProgramName = "ShellForPlink";
        private string xmlConfigFileName = "ShellForPlink.xml";
        private bool ExitCommandDoing = false;
        private bool PlinkStart = false;

        #endregion

        #region "初始化"

        public frmMain()
        {
            InitializeComponent();

            notifyicon.Text = "ShellForPlink";
            notifyicon.Visible = true;
            notifyicon.ContextMenuStrip = this.contextMenuStrip2;
            notifyicon.Icon = Properties.Resources.tray_error;
            this.Icon = Properties.Resources.main;

            plink = new Plink();

            Ping = new LoopBackPing();

            this.AddEventHandle();

            try
            {
                if (File.Exists(xmlConfigFileName))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(PlinkConfigCollection));
                    FileStream fs = File.Open(xmlConfigFileName, FileMode.Open);
                    colPlinkConfig = (PlinkConfigCollection)serializer.Deserialize(fs);
                    fs.Close();
                    colPlinkConfig.FillConfigDict();
                    colPlinkConfig.FillCurConfigobj();
                    this.FillMenuStripCfNameList();
                }
                else
                {
                    colPlinkConfig = new PlinkConfigCollection();
                    colPlinkConfig.CreateConfig("Default");
                }


                this.FillConfigControl();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void AddEventHandle()
        {
            this.plink.ConnectionStateChanged += new ConnectionStateChangeHandler(plink_ConnectionStateChanged);
            this.plink.OutputDataReceived += new DataOutputHandler(this.plink_OutDataRev);

            this.Ping.SocketErrAccur += new SocketErrAccHandler(Ping_SocketErrAccur);
            this.Ping.PingFaildThree += new PingFaildThreeHandler(Ping_PingFaildThree);
        }

        #endregion

        #region "事件"

        // 拦截窗体关闭，最小化到托盘
        private void frmMain_Load(object sender, EventArgs e)
        {
            if (CurPlinkConfig.AutoConnOnStart)
                this.btnConnect_Click(this, new EventArgs());
        }
        private void MainForm_OnClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.ExitCommandDoing)
            {
                e.Cancel = true;
                this.ShowOrHide_Click(this, new EventArgs());
            }
        }
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowOrHide_Click(this, new EventArgs());
            }
        }

        // 窗体按钮
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PlinkStart)
                {
                    this.FillConfigObject();
                    this.txtbOutput.Clear();
                    //plink.StartupPath = Environment.CurrentDirectory;
                    plink.StartupPath = Application.StartupPath;
                    plink.PlinkCf = CurPlinkConfig;
                    plink.Start();
                    LockConfigControl(true);
                }
                else
                {
                    LockConfigControl(false);
                    this.notifyicon.Icon = Properties.Resources.tray_error;
                    PlinkStart = false;
                    this.btnConnect.Text = "连接";
                    this.tsmiConnOrDisconn.Text = "连接";
                    plink.Stop(ConnectionStatus.ManualStoped);
                    if (CurPlinkConfig.LoopBackPing)
                        Ping.Stop();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SavePlinkConfigs();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {

        }

        //快捷菜单
        private void CreateConfig_Click(object sender, EventArgs e)
        {
            try
            {
                if (PlinkStart)
                    this.btnConnect_Click(this, new EventArgs());

                frmCreateConfig frmCConfig = new frmCreateConfig();
                if (frmCConfig.ShowForm(this.colPlinkConfig) == DialogResult.OK)
                {
                    colPlinkConfig.CreateConfig(frmCConfig.ConfigName);
                    this.FillConfigControl();
                    if (!ShowInTaskbar)
                        ShowOrHide_Click(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurPlinkConfig.ConfirmBeforeExit)
                    if (MessageBox.Show("退出？", "确认", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.OK)
                        return;

                this.ExitCommandDoing = true;
                if (this.PlinkStart)
                    plink.Stop(ConnectionStatus.ManualStoped);
                this.Close();
                notifyicon.Visible = false;
                this.Dispose();
                Application.Exit();
            }
            catch (Exception err)
            {
                this.ExitCommandDoing = false;
                MessageBox.Show(err.Message);
            }
        }
        private void ShowOrHide_Click(object sender, EventArgs e)
        {
            try
            {
                this.SuspendLayout();
                if (this.ShowInTaskbar)
                {
                    this.WindowState = FormWindowState.Minimized;
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(160);
                    this.ShowInTaskbar = !this.ShowInTaskbar;
                    this.Hide();
                    this.tsmiShowOrHide.Text = "显示";
                }
                else
                {
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = !this.ShowInTaskbar;
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.tsmiShowOrHide.Text = "隐藏";
                }

                this.notifyicon.Visible = true;
                this.ResumeLayout();
            }
            catch (Exception err)
            {
                this.ResumeLayout();
                MessageBox.Show(err.Message);
            }
        }
        private void PlinkConfigMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (PlinkStart)
                    this.btnConnect_Click(this, new EventArgs());

                colPlinkConfig.ChangeConfig(((ToolStripMenuItem)sender).Name);
                this.FillConfigControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //
        private void dGrid_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                DataGridView dgrid = (DataGridView)sender;
                int index = dgrid.CurrentRow.Index;
                if ((e.KeyCode == Keys.Delete) && (index >= 0))
                {
                    dgrid.Rows.RemoveAt(index);
                }
            }
            catch (Exception err)
            {
                //MessageBox.Show(err.Message);
            }
        }

        //控件状态变化
        private void txtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        private void chkbox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox chk = (CheckBox)sender;

                //Type t = Type.GetType("ShellForPlink.PlinkConfig");
                //PropertyInfo setproperty = t.GetProperty(chk.Name.Substring(3));
                //setproperty.SetValue(colPlinkConfig.CurConfig, chk.Checked, null);

                if (chk.Name == this.chkEchoServicePing.Name)
                {
                    this.chkLoopBackPing.Enabled = !chk.Checked;
                    this.txtbLoopBackPingPort.Enabled = (chkEchoServicePing.Checked || chkLoopBackPing.Checked);
                }
                else if (chk.Name == this.chkLoopBackPing.Name)
                {
                    this.chkEchoServicePing.Enabled = !chk.Checked;
                    this.txtbLoopBackPingPort.Enabled = (chkEchoServicePing.Checked || chkLoopBackPing.Checked);
                }
                else if (chk.Name == this.chkReConnAfterBreak.Name)
                {
                    this.chkUnlimitReConn.Enabled = chk.Checked;
                    this.txtbReConnDelay.Enabled = chk.Checked;
                }
                else if (chk.Name == this.chkDynamicSocket.Name)
                    this.txtbDynamicPort.Enabled = chk.Checked;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //日志产生
        private void plink_OutDataRev(int type, string data)
        {
            this.Invoke(new DataOutputHandler(this.AppendDataTotxtb), type, data);
        }

        private void plink_ConnectionStateChanged(ConnectionStatus lastState, ConnectionStatus curState)
        {
            this.Invoke(new ConnectionStateChangeHandler(delegate(ConnectionStatus lastStat, ConnectionStatus curStat)
            {
                try
                {
                    if (curStat == ConnectionStatus.StartConnecting || curStat == ConnectionStatus.ReConnecting)
                    {
                        PlinkStart = true;
                        this.btnConnect.Text = "断开";
                        this.tsmiConnOrDisconn.Text = "断开";
                        this.btnConnect.Enabled = true;
                        this.notifyicon.Icon = Properties.Resources.tray_processing;
                    }
                    if (curStat == ConnectionStatus.Connected)
                    {
                        this.notifyicon.Icon = Properties.Resources.tray_ok;
                    }
                    if (curStat == ConnectionStatus.PingTunnelOpened)
                    {
                        if (CurPlinkConfig.LoopBackPing)
                        {
                            Ping.plinkConfig = CurPlinkConfig;
                            Ping.Start();
                        }
                    }
                    if (curStat == ConnectionStatus.ConnectAborted)
                    {
                        this.notifyicon.Icon = Properties.Resources.tray_error;
                        if (!CurPlinkConfig.ReConnAfterBreak)
                        {
                            this.PlinkStart = false;
                            LockConfigControl(false);
                            this.btnConnect.Text = "连接";
                            this.tsmiConnOrDisconn.Text = "连接";
                            if (CurPlinkConfig.LoopBackPing)
                                Ping.Stop();
                        }
                        else
                            this.btnConnect.Enabled = false;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            ), lastState, curState);
        }

        //链路监测
        private void Ping_PingFaildThree()
        {
            this.Invoke(new PingFaildThreeHandler(delegate()
            {
                plink.Stop(ConnectionStatus.PingFailedStopd);
                Ping.Stop();
                this.notifyicon.Icon = Properties.Resources.tray_error;
            })
            );

        }
        private void Ping_SocketErrAccur(string errdes)
        {
            this.Invoke(new DataOutputHandler(this.AppendDataTotxtb), 2, errdes);
        }

        #endregion

        #region "自定义方法"

        //状态输出
        private void AppendDataTotxtb(int type, string data)
        {
            try
            {
                if (type == 1)
                {
                    txtbOutput.AppendText(DateTime.Now.ToString("MM/dd hh:mm:ss") + " plink：" + data + Environment.NewLine);
                }
                else if (type == 0)
                {
                    txtbOutput.AppendText(DateTime.Now.ToString("MM/dd hh:mm:ss") + " ShellForPlink：" + data + Environment.NewLine);
                }
                else if (type == 2)
                {
                    txtbOutput.AppendText(DateTime.Now.ToString("MM/dd hh:mm:ss") + " PingTest：" + data + Environment.NewLine);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void FillConfigControl()
        {
            this.Text = "ShellForPlink - " + colPlinkConfig.CurConfig.ConfigName;

            this.txtbServerIP.Text = CurPlinkConfig.ServerIP;
            this.txtbServerPort.Text = CurPlinkConfig.ServerPort.ToString();
            this.txtbUsername.Text = CurPlinkConfig.Username;
            this.txtbPassword.Text = CurPlinkConfig.Password;
            this.txtbAdditionalArgs.Text = CurPlinkConfig.AdditionalArgs;

            this.chkAutoConnOnStart.Checked = CurPlinkConfig.AutoConnOnStart;
            this.chkConfirmBeforeExit.Checked = CurPlinkConfig.ConfirmBeforeExit;
            this.chkUsePrivateKey.Checked = CurPlinkConfig.UsePrivateKey;
            this.chkVerboseOutput.Checked = CurPlinkConfig.VerboseOutput;
            this.chkHidePortConnInfo.Checked = CurPlinkConfig.HidePortConnInfo;
            this.chkCompress.Checked = CurPlinkConfig.Compress;
            this.chkNoPrompt.Checked = CurPlinkConfig.NoPrompt;

            this.chkReConnAfterBreak.Checked = CurPlinkConfig.ReConnAfterBreak;
            this.chkUnlimitReConn.Checked = CurPlinkConfig.UnLimitReConn;
            this.chkUnlimitReConn.Enabled = CurPlinkConfig.ReConnAfterBreak;
            this.txtbReConnDelay.Text = CurPlinkConfig.ReConnDelay.ToString();
            this.txtbReConnDelay.Enabled = CurPlinkConfig.ReConnAfterBreak;

            this.chkEchoServicePing.Checked = CurPlinkConfig.EchoServicePing;
            this.chkEchoServicePing.Enabled = !CurPlinkConfig.LoopBackPing;
            this.chkLoopBackPing.Checked = CurPlinkConfig.LoopBackPing;
            this.chkLoopBackPing.Enabled = !CurPlinkConfig.EchoServicePing;
            this.txtbLoopBackPingPort.Text = CurPlinkConfig.LoopBackPingPort.ToString();
            this.txtbLoopBackPingPort.Enabled = CurPlinkConfig.LoopBackPing;

            this.chkDynamicSocket.Checked = CurPlinkConfig.DynamicSocket;
            this.txtbDynamicPort.Text = CurPlinkConfig.DynamicPort.ToString();
            this.txtbDynamicPort.Enabled = CurPlinkConfig.DynamicSocket;

            this.dGridLocal.Rows.Clear();
            this.dGridRemote.Rows.Clear();
            for (int i = 0; i < CurPlinkConfig.LocalForward.Count; i++)
            {
                this.dGridLocal.Rows.Add();
                this.dGridLocal.Rows[i].Cells[0].Value = CurPlinkConfig.LocalForward[i].ListenIP;
                this.dGridLocal.Rows[i].Cells[1].Value = CurPlinkConfig.LocalForward[i].ListenPort;
                this.dGridLocal.Rows[i].Cells[2].Value = CurPlinkConfig.LocalForward[i].HostIP;
                this.dGridLocal.Rows[i].Cells[3].Value = CurPlinkConfig.LocalForward[i].HostPort;
            }
            for (int i = 0; i < CurPlinkConfig.RemoteForward.Count; i++)
            {
                this.dGridRemote.Rows.Add();
                this.dGridRemote.Rows[i].Cells[0].Value = CurPlinkConfig.RemoteForward[i].ListenIP;
                this.dGridRemote.Rows[i].Cells[1].Value = CurPlinkConfig.RemoteForward[i].ListenPort;
                this.dGridRemote.Rows[i].Cells[2].Value = CurPlinkConfig.RemoteForward[i].HostIP;
                this.dGridRemote.Rows[i].Cells[3].Value = CurPlinkConfig.RemoteForward[i].HostPort;
            }
            this.txtbServerIP.Focus();
        }
        private void FillConfigObject()
        {
            CurPlinkConfig.ServerIP = this.txtbServerIP.Text.Trim();
            CurPlinkConfig.ServerPort = Convert.ToInt32(this.txtbServerPort.Text.Trim());
            CurPlinkConfig.Username = this.txtbUsername.Text.Trim();
            CurPlinkConfig.Password = this.txtbPassword.Text.Trim();
            CurPlinkConfig.AutoConnOnStart = this.chkAutoConnOnStart.Checked;
            CurPlinkConfig.ConfirmBeforeExit = this.chkConfirmBeforeExit.Checked;
            CurPlinkConfig.UsePrivateKey = this.chkUsePrivateKey.Checked;
            CurPlinkConfig.VerboseOutput = this.chkVerboseOutput.Checked;
            CurPlinkConfig.AdditionalArgs = this.txtbAdditionalArgs.Text.Trim();

            CurPlinkConfig.ReConnAfterBreak = this.chkReConnAfterBreak.Checked;
            CurPlinkConfig.UnLimitReConn = this.chkUnlimitReConn.Checked;
            CurPlinkConfig.ReConnDelay = Convert.ToInt32(this.txtbReConnDelay.Text.Trim());

            CurPlinkConfig.EchoServicePing = this.chkEchoServicePing.Checked;
            CurPlinkConfig.LoopBackPing = this.chkLoopBackPing.Checked;
            CurPlinkConfig.LoopBackPingPort = Convert.ToInt32(this.txtbLoopBackPingPort.Text.Trim());

            CurPlinkConfig.DynamicSocket = this.chkDynamicSocket.Checked;
            CurPlinkConfig.DynamicPort = Convert.ToInt32(this.txtbDynamicPort.Text.Trim());

            CurPlinkConfig.HidePortConnInfo = this.chkHidePortConnInfo.Checked;
            CurPlinkConfig.Compress = this.chkCompress.Checked;
            CurPlinkConfig.NoPrompt = this.chkNoPrompt.Checked;

            CurPlinkConfig.LocalForward.Clear();
            CurPlinkConfig.RemoteForward.Clear();
            PortForward pf;
            for (int i = 0; i < this.dGridLocal.Rows.Count - 1; i++)
            {
                pf = new PortForward();
                pf.ListenIP = this.dGridLocal.Rows[i].Cells[0].Value.ToString();
                pf.ListenPort = Convert.ToInt32(this.dGridLocal.Rows[i].Cells[1].Value);
                pf.HostIP = this.dGridLocal.Rows[i].Cells[2].Value.ToString();
                pf.HostPort = Convert.ToInt32(this.dGridLocal.Rows[i].Cells[3].Value);
                CurPlinkConfig.LocalForward.Add(pf);

            }
            for (int i = 0; i < this.dGridRemote.Rows.Count - 1; i++)
            {
                pf = new PortForward();
                pf.ListenIP = this.dGridRemote.Rows[i].Cells[0].Value.ToString();
                pf.ListenPort = Convert.ToInt32(this.dGridRemote.Rows[i].Cells[1].Value);
                pf.HostIP = this.dGridRemote.Rows[i].Cells[2].Value.ToString();
                pf.HostPort = Convert.ToInt32(this.dGridRemote.Rows[i].Cells[3].Value);
                CurPlinkConfig.RemoteForward.Add(pf);
            }
        }
        private void FillMenuStripCfNameList()
        {
            for (int i = tsmiConfigurations.DropDownItems.Count - 1; i > 1; i--)
            {
                tsmiConfigurations.DropDownItems.RemoveAt(i);
            }
            ToolStripMenuItem tsi;
            foreach (PlinkConfig pconfig in colPlinkConfig.Configs)
            {
                tsi = new ToolStripMenuItem();
                tsi.Name = pconfig.ConfigName;
                tsi.Text = pconfig.ConfigName;
                tsi.Click += new EventHandler(PlinkConfigMenuItem_Click);
                tsmiConfigurations.DropDownItems.Add(tsi);
            }
        }
        private void SavePlinkConfigs()
        {
            this.FillConfigObject();

            XmlSerializer serializer = new XmlSerializer(typeof(PlinkConfigCollection));
            MemoryStream w = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(w, Encoding.UTF8);
            serializer.Serialize((XmlWriter)writer, this.colPlinkConfig);
            w.Seek(0L, SeekOrigin.Begin);
            XmlDocument document = new XmlDocument();
            document.Load(w);
            document.Save(xmlConfigFileName);
            System.Threading.Thread.Sleep(500);
            w.Close();
            writer.Close();

            this.FillMenuStripCfNameList();
        }
        private void LockConfigControl(bool Locked)
        {
            if (Locked)
            {
                this.txtbServerIP.Enabled = false;
                this.txtbServerPort.Enabled = false;
                this.txtbUsername.Enabled = false;
                this.txtbPassword.Enabled = false;
                this.chkAutoConnOnStart.Enabled = false;
                this.chkConfirmBeforeExit.Enabled = false;
                this.chkUsePrivateKey.Enabled = false;
                this.chkVerboseOutput.Enabled = false;
                this.txtbAdditionalArgs.Enabled = false;
                this.chkHidePortConnInfo.Enabled = false;
                this.chkCompress.Enabled = false;
                this.chkNoPrompt.Enabled = false;

                this.chkReConnAfterBreak.Enabled = false;
                this.chkUnlimitReConn.Enabled = false;
                this.txtbReConnDelay.Enabled = false;

                this.chkEchoServicePing.Enabled = false;
                this.chkLoopBackPing.Enabled = false;
                this.txtbLoopBackPingPort.Enabled = false;

                this.chkDynamicSocket.Enabled = false;
                this.txtbDynamicPort.Enabled = false;

                this.dGridLocal.ReadOnly = true;
                this.dGridRemote.ReadOnly = true;
            }
            else
            {
                this.txtbServerIP.Enabled = true;
                this.txtbServerPort.Enabled = true;
                this.txtbUsername.Enabled = true;
                this.txtbPassword.Enabled = true;
                this.chkAutoConnOnStart.Enabled = true;
                this.chkConfirmBeforeExit.Enabled = true;
                this.chkUsePrivateKey.Enabled = true;
                this.chkVerboseOutput.Enabled = true;
                this.txtbAdditionalArgs.Enabled = true;
                this.chkHidePortConnInfo.Enabled = true;
                this.chkCompress.Enabled = true;
                this.chkNoPrompt.Enabled = true;

                this.chkReConnAfterBreak.Enabled = true;
                this.chkUnlimitReConn.Enabled = CurPlinkConfig.ReConnAfterBreak;
                this.txtbReConnDelay.Enabled = CurPlinkConfig.ReConnAfterBreak;

                this.chkEchoServicePing.Enabled = !CurPlinkConfig.LoopBackPing;
                this.chkLoopBackPing.Enabled = !CurPlinkConfig.EchoServicePing;
                this.txtbLoopBackPingPort.Enabled = (CurPlinkConfig.LoopBackPing || CurPlinkConfig.EchoServicePing);

                this.chkDynamicSocket.Enabled = true;
                this.txtbDynamicPort.Enabled = CurPlinkConfig.DynamicSocket;

                this.dGridLocal.ReadOnly = false;
                this.dGridRemote.ReadOnly = false;
            }
        }

        #endregion
    }
}
