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
            notifyicon.Icon = Properties.Resources.ico1;
            this.Icon = Properties.Resources.ico1;

            this.btnCancle.Enabled = false;

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
                if (CurPlinkConfig.AutoConnOnStart)
                    this.btnConnect_Click(this, new EventArgs());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void AddEventHandle()
        {
            this.FormClosing += new FormClosingEventHandler(this.MainForm_OnClosing);
            //this.SizeChanged += new EventHandler(MainForm_SizeChanged);

            this.chkConfirmBeforeExit.Click += new System.EventHandler(this.chkbox_CheckedChanged);
            this.chkAutoConnOnStart.Click += new System.EventHandler(this.chkbox_CheckedChanged);
            this.chkReConnAfterBreak.Click += new System.EventHandler(this.chkbox_CheckedChanged);
            this.chkUsePrivateKey.Click += new System.EventHandler(this.chkbox_CheckedChanged);
            this.chkVerboseOutput.Click += new System.EventHandler(this.chkbox_CheckedChanged);
            this.chkLoopBackPing.Click += new System.EventHandler(this.chkbox_CheckedChanged);
            this.chkUnlimitReConn.Click += new System.EventHandler(this.chkbox_CheckedChanged);
            this.chkDynamicSocket.Click += new System.EventHandler(this.chkbox_CheckedChanged);
            this.chkHidePortConnInfo.Click += new System.EventHandler(this.chkbox_CheckedChanged);
            this.chkEchoServicePing.Click += new System.EventHandler(this.chkbox_CheckedChanged);
            this.chkCompress.Click += new System.EventHandler(this.chkbox_CheckedChanged);
            this.chkNoPrompt.Click += new System.EventHandler(this.chkbox_CheckedChanged);

            this.txtbReConnDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_KeyPress);
            this.txtbDynamicPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_KeyPress);
            this.txtbLoopBackPingPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_KeyPress);
            this.txtbServerPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_KeyPress);

            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnHide.Click += new System.EventHandler(this.ShowOrHide_Click);
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);

            this.tsmiExit.Click += new System.EventHandler(this.Exit_Click);
            this.tsmiShowOrHide.Click += new System.EventHandler(this.ShowOrHide_Click);
            this.tsmiCreateConfig.Click += new System.EventHandler(this.CreateConfig_Click);

            this.notifyicon.DoubleClick += new System.EventHandler(this.ShowOrHide_Click);

            this.plink.ConnectionStateChanged += new ConnectionStateChangeHandler(plink_ConnectionStateChanged);
            this.plink.OutputDataReceived += new DataOutputHandler(this.plink_OutDataRev);

            this.Ping.SocketErrAccur += new SocketErrAccHandler(Ping_SocketErrAccur);
            this.Ping.PingFaildThree += new PingFaildThreeHandler(Ping_PingFaildThree);
        }

        #endregion
        
        #region "事件"

        // 拦截窗体关闭，最小化到托盘
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
                    plink.PlinkCf = CurPlinkConfig;
                    plink.Start();
                    LockConfigControl(true);
                    PlinkStart = true;
                    this.btnConnect.Text = "断开";
                }
                else
                {
                    plink.Stop();
                    if (CurPlinkConfig.LoopBackPing)
                        Ping.Stop();
                    LockConfigControl(false);
                    PlinkStart = false;
                    this.btnConnect.Text = "连接";
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
                this.ExitCommandDoing = true;
                if (this.PlinkStart)
                    plink.Stop();
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
                if (this.ShowInTaskbar)
                {
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        this.WindowState = FormWindowState.Normal;
                    }
                    this.Hide();
                    this.tsmiShowOrHide.Text = "显示";
                }
                else
                {
                    this.Show();
                    this.tsmiShowOrHide.Text = "隐藏";
                }
                this.ShowInTaskbar = !this.ShowInTaskbar;
                this.notifyicon.Visible = true;
            }
            catch (Exception err)
            {
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
                }
                else if (chk.Name == this.chkLoopBackPing.Name)
                {
                    this.chkEchoServicePing.Enabled = !chk.Checked;
                    this.txtbLoopBackPingPort.Enabled = chk.Checked;
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
            try
            {
                if (CurPlinkConfig.LoopBackPing && curState == ConnectionStatus.Connected)
                {
                    this.btnConnect.Enabled = true;
                    this.btnCancle.Enabled = false;

                    Ping.plinkConfig = CurPlinkConfig;
                    Ping.Start();
                }
                if (curState == ConnectionStatus.ConnectAborted)
                {
                    this.PlinkStart = false;
                    if (CurPlinkConfig.ReConnAfterBreak)
                    {
                        this.btnConnect.Enabled = false;
                        this.btnCancle.Enabled = true;
                    }
                    else
                    {
                        this.btnConnect.Text = "连接";

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        private void Ping_PingFaildThree()
        {
            //throw new NotImplementedException();
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
            if (type == 1)
            {
                txtbOutput.AppendText(DateTime.Now.ToString("MM/dd hh:mm:ss") + " plink：" + data + "\n");
            }
            else if (type == 0)
            {
                txtbOutput.AppendText(DateTime.Now.ToString("MM/dd hh:mm:ss") + " ShellForPlink：" + data + "\n");
            }
            else if (type == 2)
            {
                txtbOutput.AppendText(DateTime.Now.ToString("MM/dd hh:mm:ss") + " PingTest：" + data + "\n");
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
                this.txtbLoopBackPingPort.Enabled = CurPlinkConfig.LoopBackPing;

                this.chkDynamicSocket.Enabled = true;
                this.txtbDynamicPort.Enabled = CurPlinkConfig.DynamicSocket;
            }
        }

        #endregion
    }
}
