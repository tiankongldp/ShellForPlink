namespace ShellForPlink
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpStatus = new System.Windows.Forms.TabPage();
            this.txtbOutput = new System.Windows.Forms.TextBox();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.chkConfirmBeforeExit = new System.Windows.Forms.CheckBox();
            this.chkAutoConnOnStart = new System.Windows.Forms.CheckBox();
            this.chkReConnAfterBreak = new System.Windows.Forms.CheckBox();
            this.chkUsePrivateKey = new System.Windows.Forms.CheckBox();
            this.chkVerboseOutput = new System.Windows.Forms.CheckBox();
            this.chkUnlimitReConn = new System.Windows.Forms.CheckBox();
            this.chkDynamicSocket = new System.Windows.Forms.CheckBox();
            this.chkHidePortConnInfo = new System.Windows.Forms.CheckBox();
            this.chkCompress = new System.Windows.Forms.CheckBox();
            this.chkNoPrompt = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbReConnDelay = new System.Windows.Forms.TextBox();
            this.txtbDynamicPort = new System.Windows.Forms.TextBox();
            this.txtbLoopBackPingPort = new System.Windows.Forms.TextBox();
            this.txtbAdditionalArgs = new System.Windows.Forms.TextBox();
            this.cboLanguage = new System.Windows.Forms.ComboBox();
            this.chkLoopBackPing = new System.Windows.Forms.CheckBox();
            this.chkEchoServicePing = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtbServerIP = new System.Windows.Forms.TextBox();
            this.txtbServerPort = new System.Windows.Forms.TextBox();
            this.txtbPassword = new System.Windows.Forms.TextBox();
            this.txtbUsername = new System.Windows.Forms.TextBox();
            this.tpTunnels = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grpBoxLocal = new System.Windows.Forms.GroupBox();
            this.dGridLocal = new System.Windows.Forms.DataGridView();
            this.Col_Loc_ListenIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Loc_ListenPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Loc_HostIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Loc_HostPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbBoxRemote = new System.Windows.Forms.GroupBox();
            this.dGridRemote = new System.Windows.Forms.DataGridView();
            this.Col_Rem_ListenIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Rem_ListenPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Rem_HostIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Rem_HostPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpLicence = new System.Windows.Forms.TabPage();
            this.txtbLicence = new System.Windows.Forms.TextBox();
            this.tpReadMe = new System.Windows.Forms.TabPage();
            this.txtbReadMe = new System.Windows.Forms.TextBox();
            this.tpAbout = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnHide = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowOrHide = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConnOrDisconn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConfigurations = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreateConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyicon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpStatus.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tpTunnels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.grpBoxLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridLocal)).BeginInit();
            this.grbBoxRemote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridRemote)).BeginInit();
            this.tpLicence.SuspendLayout();
            this.tpReadMe.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(626, 339);
            this.splitContainer1.SplitterDistance = 301;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpStatus);
            this.tabControl1.Controls.Add(this.tpSettings);
            this.tabControl1.Controls.Add(this.tpTunnels);
            this.tabControl1.Controls.Add(this.tpLicence);
            this.tabControl1.Controls.Add(this.tpReadMe);
            this.tabControl1.Controls.Add(this.tpAbout);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(626, 301);
            this.tabControl1.TabIndex = 0;
            // 
            // tpStatus
            // 
            this.tpStatus.Controls.Add(this.txtbOutput);
            this.tpStatus.Location = new System.Drawing.Point(4, 22);
            this.tpStatus.Name = "tpStatus";
            this.tpStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tpStatus.Size = new System.Drawing.Size(618, 275);
            this.tpStatus.TabIndex = 0;
            this.tpStatus.Text = "状态";
            this.tpStatus.UseVisualStyleBackColor = true;
            // 
            // txtbOutput
            // 
            this.txtbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbOutput.Location = new System.Drawing.Point(3, 3);
            this.txtbOutput.Margin = new System.Windows.Forms.Padding(1);
            this.txtbOutput.Multiline = true;
            this.txtbOutput.Name = "txtbOutput";
            this.txtbOutput.ReadOnly = true;
            this.txtbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbOutput.Size = new System.Drawing.Size(612, 269);
            this.txtbOutput.TabIndex = 0;
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.tableLayoutPanel3);
            this.tpSettings.Controls.Add(this.tableLayoutPanel2);
            this.tpSettings.Location = new System.Drawing.Point(4, 22);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(618, 275);
            this.tpSettings.TabIndex = 1;
            this.tpSettings.Text = "设定";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel3.Controls.Add(this.chkConfirmBeforeExit, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.chkAutoConnOnStart, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.chkReConnAfterBreak, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.chkUsePrivateKey, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.chkVerboseOutput, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.chkUnlimitReConn, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.chkDynamicSocket, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.chkHidePortConnInfo, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.chkCompress, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.chkNoPrompt, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.label1, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.label2, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.label3, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.label5, 2, 5);
            this.tableLayoutPanel3.Controls.Add(this.txtbReConnDelay, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtbDynamicPort, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtbLoopBackPingPort, 3, 4);
            this.tableLayoutPanel3.Controls.Add(this.txtbAdditionalArgs, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.cboLanguage, 2, 6);
            this.tableLayoutPanel3.Controls.Add(this.chkLoopBackPing, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.chkEchoServicePing, 0, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 58);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(612, 214);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // chkConfirmBeforeExit
            // 
            this.chkConfirmBeforeExit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkConfirmBeforeExit.AutoSize = true;
            this.chkConfirmBeforeExit.Location = new System.Drawing.Point(198, 6);
            this.chkConfirmBeforeExit.Name = "chkConfirmBeforeExit";
            this.chkConfirmBeforeExit.Size = new System.Drawing.Size(84, 16);
            this.chkConfirmBeforeExit.TabIndex = 10;
            this.chkConfirmBeforeExit.Text = "退出前提示";
            this.chkConfirmBeforeExit.UseVisualStyleBackColor = true;
            this.chkConfirmBeforeExit.Click += new System.EventHandler(this.chkbox_CheckedChanged);
            // 
            // chkAutoConnOnStart
            // 
            this.chkAutoConnOnStart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkAutoConnOnStart.AutoSize = true;
            this.chkAutoConnOnStart.Location = new System.Drawing.Point(3, 6);
            this.chkAutoConnOnStart.Name = "chkAutoConnOnStart";
            this.chkAutoConnOnStart.Size = new System.Drawing.Size(108, 16);
            this.chkAutoConnOnStart.TabIndex = 5;
            this.chkAutoConnOnStart.Text = "启动时自动连接";
            this.chkAutoConnOnStart.UseVisualStyleBackColor = true;
            this.chkAutoConnOnStart.Click += new System.EventHandler(this.chkbox_CheckedChanged);
            // 
            // chkReConnAfterBreak
            // 
            this.chkReConnAfterBreak.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkReConnAfterBreak.AutoSize = true;
            this.chkReConnAfterBreak.Location = new System.Drawing.Point(3, 35);
            this.chkReConnAfterBreak.Name = "chkReConnAfterBreak";
            this.chkReConnAfterBreak.Size = new System.Drawing.Size(108, 16);
            this.chkReConnAfterBreak.TabIndex = 6;
            this.chkReConnAfterBreak.Text = "失败时重新连接";
            this.chkReConnAfterBreak.UseVisualStyleBackColor = true;
            this.chkReConnAfterBreak.Click += new System.EventHandler(this.chkbox_CheckedChanged);
            // 
            // chkUsePrivateKey
            // 
            this.chkUsePrivateKey.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkUsePrivateKey.AutoSize = true;
            this.chkUsePrivateKey.Location = new System.Drawing.Point(3, 64);
            this.chkUsePrivateKey.Name = "chkUsePrivateKey";
            this.chkUsePrivateKey.Size = new System.Drawing.Size(96, 16);
            this.chkUsePrivateKey.TabIndex = 7;
            this.chkUsePrivateKey.Text = "使用私人密钥";
            this.chkUsePrivateKey.UseVisualStyleBackColor = true;
            this.chkUsePrivateKey.Click += new System.EventHandler(this.chkbox_CheckedChanged);
            // 
            // chkVerboseOutput
            // 
            this.chkVerboseOutput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkVerboseOutput.AutoSize = true;
            this.chkVerboseOutput.Location = new System.Drawing.Point(3, 93);
            this.chkVerboseOutput.Name = "chkVerboseOutput";
            this.chkVerboseOutput.Size = new System.Drawing.Size(72, 16);
            this.chkVerboseOutput.TabIndex = 8;
            this.chkVerboseOutput.Text = "冗余记录";
            this.chkVerboseOutput.UseVisualStyleBackColor = true;
            this.chkVerboseOutput.Click += new System.EventHandler(this.chkbox_CheckedChanged);
            // 
            // chkUnlimitReConn
            // 
            this.chkUnlimitReConn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkUnlimitReConn.AutoSize = true;
            this.chkUnlimitReConn.Location = new System.Drawing.Point(198, 35);
            this.chkUnlimitReConn.Name = "chkUnlimitReConn";
            this.chkUnlimitReConn.Size = new System.Drawing.Size(108, 16);
            this.chkUnlimitReConn.TabIndex = 11;
            this.chkUnlimitReConn.Text = "不限制重试次数";
            this.chkUnlimitReConn.UseVisualStyleBackColor = true;
            this.chkUnlimitReConn.Click += new System.EventHandler(this.chkbox_CheckedChanged);
            // 
            // chkDynamicSocket
            // 
            this.chkDynamicSocket.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkDynamicSocket.AutoSize = true;
            this.chkDynamicSocket.Location = new System.Drawing.Point(198, 64);
            this.chkDynamicSocket.Name = "chkDynamicSocket";
            this.chkDynamicSocket.Size = new System.Drawing.Size(108, 16);
            this.chkDynamicSocket.TabIndex = 12;
            this.chkDynamicSocket.Text = "启用动态套接字";
            this.chkDynamicSocket.UseVisualStyleBackColor = true;
            this.chkDynamicSocket.Click += new System.EventHandler(this.chkbox_CheckedChanged);
            // 
            // chkHidePortConnInfo
            // 
            this.chkHidePortConnInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkHidePortConnInfo.AutoSize = true;
            this.chkHidePortConnInfo.Location = new System.Drawing.Point(198, 93);
            this.chkHidePortConnInfo.Name = "chkHidePortConnInfo";
            this.chkHidePortConnInfo.Size = new System.Drawing.Size(96, 16);
            this.chkHidePortConnInfo.TabIndex = 13;
            this.chkHidePortConnInfo.Text = "隐藏端口连接";
            this.chkHidePortConnInfo.UseVisualStyleBackColor = true;
            this.chkHidePortConnInfo.Click += new System.EventHandler(this.chkbox_CheckedChanged);
            // 
            // chkCompress
            // 
            this.chkCompress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkCompress.AutoSize = true;
            this.chkCompress.Location = new System.Drawing.Point(406, 6);
            this.chkCompress.Name = "chkCompress";
            this.chkCompress.Size = new System.Drawing.Size(72, 16);
            this.chkCompress.TabIndex = 15;
            this.chkCompress.Text = "启用压缩";
            this.chkCompress.UseVisualStyleBackColor = true;
            this.chkCompress.Click += new System.EventHandler(this.chkbox_CheckedChanged);
            // 
            // chkNoPrompt
            // 
            this.chkNoPrompt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkNoPrompt.AutoSize = true;
            this.chkNoPrompt.Location = new System.Drawing.Point(406, 93);
            this.chkNoPrompt.Name = "chkNoPrompt";
            this.chkNoPrompt.Size = new System.Drawing.Size(72, 16);
            this.chkNoPrompt.TabIndex = 18;
            this.chkNoPrompt.Text = "禁用提示";
            this.chkNoPrompt.UseVisualStyleBackColor = true;
            this.chkNoPrompt.Click += new System.EventHandler(this.chkbox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(406, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "重试延迟:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "本地端口:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(406, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Port:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "可选参数:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(406, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "语言:";
            // 
            // txtbReConnDelay
            // 
            this.txtbReConnDelay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtbReConnDelay.Location = new System.Drawing.Point(528, 33);
            this.txtbReConnDelay.MaxLength = 6;
            this.txtbReConnDelay.Name = "txtbReConnDelay";
            this.txtbReConnDelay.Size = new System.Drawing.Size(81, 21);
            this.txtbReConnDelay.TabIndex = 16;
            this.txtbReConnDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_KeyPress);
            // 
            // txtbDynamicPort
            // 
            this.txtbDynamicPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtbDynamicPort.Location = new System.Drawing.Point(528, 62);
            this.txtbDynamicPort.MaxLength = 5;
            this.txtbDynamicPort.Name = "txtbDynamicPort";
            this.txtbDynamicPort.Size = new System.Drawing.Size(81, 21);
            this.txtbDynamicPort.TabIndex = 17;
            this.txtbDynamicPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_KeyPress);
            // 
            // txtbLoopBackPingPort
            // 
            this.txtbLoopBackPingPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtbLoopBackPingPort.Location = new System.Drawing.Point(528, 120);
            this.txtbLoopBackPingPort.Name = "txtbLoopBackPingPort";
            this.txtbLoopBackPingPort.Size = new System.Drawing.Size(81, 21);
            this.txtbLoopBackPingPort.TabIndex = 19;
            this.txtbLoopBackPingPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_KeyPress);
            // 
            // txtbAdditionalArgs
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.txtbAdditionalArgs, 2);
            this.txtbAdditionalArgs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbAdditionalArgs.Location = new System.Drawing.Point(3, 177);
            this.txtbAdditionalArgs.Name = "txtbAdditionalArgs";
            this.txtbAdditionalArgs.Size = new System.Drawing.Size(397, 21);
            this.txtbAdditionalArgs.TabIndex = 20;
            // 
            // cboLanguage
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.cboLanguage, 2);
            this.cboLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLanguage.FormattingEnabled = true;
            this.cboLanguage.Location = new System.Drawing.Point(406, 177);
            this.cboLanguage.Name = "cboLanguage";
            this.cboLanguage.Size = new System.Drawing.Size(203, 20);
            this.cboLanguage.TabIndex = 21;
            // 
            // chkLoopBackPing
            // 
            this.chkLoopBackPing.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkLoopBackPing.AutoSize = true;
            this.chkLoopBackPing.Location = new System.Drawing.Point(198, 122);
            this.chkLoopBackPing.Name = "chkLoopBackPing";
            this.chkLoopBackPing.Size = new System.Drawing.Size(120, 16);
            this.chkLoopBackPing.TabIndex = 14;
            this.chkLoopBackPing.Text = "启用环回ping命令";
            this.chkLoopBackPing.UseVisualStyleBackColor = true;
            this.chkLoopBackPing.Click += new System.EventHandler(this.chkbox_CheckedChanged);
            // 
            // chkEchoServicePing
            // 
            this.chkEchoServicePing.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkEchoServicePing.AutoSize = true;
            this.chkEchoServicePing.Location = new System.Drawing.Point(3, 122);
            this.chkEchoServicePing.Name = "chkEchoServicePing";
            this.chkEchoServicePing.Size = new System.Drawing.Size(144, 16);
            this.chkEchoServicePing.TabIndex = 9;
            this.chkEchoServicePing.Text = "启用回音服务ping命令";
            this.chkEchoServicePing.UseVisualStyleBackColor = true;
            this.chkEchoServicePing.Click += new System.EventHandler(this.chkbox_CheckedChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.lblServer, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblUserName, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblPassword, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblPort, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtbServerIP, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtbServerPort, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtbPassword, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtbUsername, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(612, 55);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblServer
            // 
            this.lblServer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(3, 7);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(65, 12);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "SSH服务器:";
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(3, 35);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(59, 12);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "用户名称:";
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(325, 35);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(35, 12);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "口令:";
            // 
            // lblPort
            // 
            this.lblPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(325, 7);
            this.lblPort.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(53, 12);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "SSH端口:";
            // 
            // txtbServerIP
            // 
            this.txtbServerIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbServerIP.Location = new System.Drawing.Point(125, 3);
            this.txtbServerIP.Name = "txtbServerIP";
            this.txtbServerIP.Size = new System.Drawing.Size(177, 21);
            this.txtbServerIP.TabIndex = 1;
            // 
            // txtbServerPort
            // 
            this.txtbServerPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbServerPort.Location = new System.Drawing.Point(430, 3);
            this.txtbServerPort.Name = "txtbServerPort";
            this.txtbServerPort.Size = new System.Drawing.Size(179, 21);
            this.txtbServerPort.TabIndex = 2;
            this.txtbServerPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_KeyPress);
            // 
            // txtbPassword
            // 
            this.txtbPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbPassword.Location = new System.Drawing.Point(430, 30);
            this.txtbPassword.Name = "txtbPassword";
            this.txtbPassword.PasswordChar = '*';
            this.txtbPassword.Size = new System.Drawing.Size(179, 21);
            this.txtbPassword.TabIndex = 4;
            // 
            // txtbUsername
            // 
            this.txtbUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbUsername.Location = new System.Drawing.Point(125, 30);
            this.txtbUsername.Name = "txtbUsername";
            this.txtbUsername.Size = new System.Drawing.Size(177, 21);
            this.txtbUsername.TabIndex = 3;
            // 
            // tpTunnels
            // 
            this.tpTunnels.Controls.Add(this.splitContainer2);
            this.tpTunnels.Location = new System.Drawing.Point(4, 22);
            this.tpTunnels.Name = "tpTunnels";
            this.tpTunnels.Size = new System.Drawing.Size(618, 275);
            this.tpTunnels.TabIndex = 2;
            this.tpTunnels.Text = "通道";
            this.tpTunnels.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.grpBoxLocal);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grbBoxRemote);
            this.splitContainer2.Size = new System.Drawing.Size(618, 275);
            this.splitContainer2.SplitterDistance = 306;
            this.splitContainer2.TabIndex = 0;
            // 
            // grpBoxLocal
            // 
            this.grpBoxLocal.Controls.Add(this.dGridLocal);
            this.grpBoxLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxLocal.Location = new System.Drawing.Point(0, 0);
            this.grpBoxLocal.Name = "grpBoxLocal";
            this.grpBoxLocal.Size = new System.Drawing.Size(306, 275);
            this.grpBoxLocal.TabIndex = 0;
            this.grpBoxLocal.TabStop = false;
            this.grpBoxLocal.Text = "本地";
            // 
            // dGridLocal
            // 
            this.dGridLocal.AllowUserToDeleteRows = false;
            this.dGridLocal.AllowUserToResizeColumns = false;
            this.dGridLocal.AllowUserToResizeRows = false;
            this.dGridLocal.BackgroundColor = System.Drawing.Color.White;
            this.dGridLocal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridLocal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_Loc_ListenIP,
            this.Col_Loc_ListenPort,
            this.Col_Loc_HostIP,
            this.Col_Loc_HostPort});
            this.dGridLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGridLocal.Location = new System.Drawing.Point(3, 17);
            this.dGridLocal.MultiSelect = false;
            this.dGridLocal.Name = "dGridLocal";
            this.dGridLocal.RowHeadersVisible = false;
            this.dGridLocal.RowTemplate.Height = 23;
            this.dGridLocal.Size = new System.Drawing.Size(300, 255);
            this.dGridLocal.TabIndex = 0;
            this.dGridLocal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dGrid_KeyDown);
            // 
            // Col_Loc_ListenIP
            // 
            this.Col_Loc_ListenIP.HeaderText = "监听IP";
            this.Col_Loc_ListenIP.MaxInputLength = 15;
            this.Col_Loc_ListenIP.Name = "Col_Loc_ListenIP";
            this.Col_Loc_ListenIP.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Col_Loc_ListenIP.Width = 96;
            // 
            // Col_Loc_ListenPort
            // 
            this.Col_Loc_ListenPort.HeaderText = "Port";
            this.Col_Loc_ListenPort.MaxInputLength = 5;
            this.Col_Loc_ListenPort.Name = "Col_Loc_ListenPort";
            this.Col_Loc_ListenPort.Width = 50;
            // 
            // Col_Loc_HostIP
            // 
            this.Col_Loc_HostIP.HeaderText = "主机IP";
            this.Col_Loc_HostIP.MaxInputLength = 15;
            this.Col_Loc_HostIP.Name = "Col_Loc_HostIP";
            this.Col_Loc_HostIP.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Col_Loc_HostIP.Width = 96;
            // 
            // Col_Loc_HostPort
            // 
            this.Col_Loc_HostPort.HeaderText = "Port";
            this.Col_Loc_HostPort.MaxInputLength = 5;
            this.Col_Loc_HostPort.Name = "Col_Loc_HostPort";
            this.Col_Loc_HostPort.Width = 50;
            // 
            // grbBoxRemote
            // 
            this.grbBoxRemote.Controls.Add(this.dGridRemote);
            this.grbBoxRemote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbBoxRemote.Location = new System.Drawing.Point(0, 0);
            this.grbBoxRemote.Name = "grbBoxRemote";
            this.grbBoxRemote.Size = new System.Drawing.Size(308, 275);
            this.grbBoxRemote.TabIndex = 0;
            this.grbBoxRemote.TabStop = false;
            this.grbBoxRemote.Text = "远程";
            // 
            // dGridRemote
            // 
            this.dGridRemote.AllowUserToDeleteRows = false;
            this.dGridRemote.AllowUserToResizeColumns = false;
            this.dGridRemote.AllowUserToResizeRows = false;
            this.dGridRemote.BackgroundColor = System.Drawing.Color.White;
            this.dGridRemote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridRemote.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_Rem_ListenIP,
            this.Col_Rem_ListenPort,
            this.Col_Rem_HostIP,
            this.Col_Rem_HostPort});
            this.dGridRemote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGridRemote.Location = new System.Drawing.Point(3, 17);
            this.dGridRemote.MultiSelect = false;
            this.dGridRemote.Name = "dGridRemote";
            this.dGridRemote.RowHeadersVisible = false;
            this.dGridRemote.RowTemplate.Height = 23;
            this.dGridRemote.Size = new System.Drawing.Size(302, 255);
            this.dGridRemote.TabIndex = 0;
            this.dGridRemote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dGrid_KeyDown);
            // 
            // Col_Rem_ListenIP
            // 
            this.Col_Rem_ListenIP.HeaderText = "监听IP";
            this.Col_Rem_ListenIP.MaxInputLength = 15;
            this.Col_Rem_ListenIP.Name = "Col_Rem_ListenIP";
            this.Col_Rem_ListenIP.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Col_Rem_ListenIP.Width = 97;
            // 
            // Col_Rem_ListenPort
            // 
            this.Col_Rem_ListenPort.HeaderText = "Port";
            this.Col_Rem_ListenPort.MaxInputLength = 5;
            this.Col_Rem_ListenPort.Name = "Col_Rem_ListenPort";
            this.Col_Rem_ListenPort.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Col_Rem_ListenPort.Width = 50;
            // 
            // Col_Rem_HostIP
            // 
            this.Col_Rem_HostIP.HeaderText = "主机IP";
            this.Col_Rem_HostIP.MaxInputLength = 15;
            this.Col_Rem_HostIP.Name = "Col_Rem_HostIP";
            this.Col_Rem_HostIP.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Col_Rem_HostIP.Width = 97;
            // 
            // Col_Rem_HostPort
            // 
            this.Col_Rem_HostPort.HeaderText = "Port";
            this.Col_Rem_HostPort.MaxInputLength = 5;
            this.Col_Rem_HostPort.Name = "Col_Rem_HostPort";
            this.Col_Rem_HostPort.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Col_Rem_HostPort.Width = 50;
            // 
            // tpLicence
            // 
            this.tpLicence.Controls.Add(this.txtbLicence);
            this.tpLicence.Location = new System.Drawing.Point(4, 22);
            this.tpLicence.Name = "tpLicence";
            this.tpLicence.Size = new System.Drawing.Size(618, 275);
            this.tpLicence.TabIndex = 3;
            this.tpLicence.Text = "许可";
            this.tpLicence.UseVisualStyleBackColor = true;
            // 
            // txtbLicence
            // 
            this.txtbLicence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbLicence.Location = new System.Drawing.Point(0, 0);
            this.txtbLicence.Multiline = true;
            this.txtbLicence.Name = "txtbLicence";
            this.txtbLicence.Size = new System.Drawing.Size(618, 275);
            this.txtbLicence.TabIndex = 0;
            // 
            // tpReadMe
            // 
            this.tpReadMe.Controls.Add(this.txtbReadMe);
            this.tpReadMe.Location = new System.Drawing.Point(4, 22);
            this.tpReadMe.Name = "tpReadMe";
            this.tpReadMe.Size = new System.Drawing.Size(618, 275);
            this.tpReadMe.TabIndex = 4;
            this.tpReadMe.Text = "自述";
            this.tpReadMe.UseVisualStyleBackColor = true;
            // 
            // txtbReadMe
            // 
            this.txtbReadMe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbReadMe.Location = new System.Drawing.Point(0, 0);
            this.txtbReadMe.Multiline = true;
            this.txtbReadMe.Name = "txtbReadMe";
            this.txtbReadMe.Size = new System.Drawing.Size(618, 275);
            this.txtbReadMe.TabIndex = 0;
            // 
            // tpAbout
            // 
            this.tpAbout.Location = new System.Drawing.Point(4, 22);
            this.tpAbout.Name = "tpAbout";
            this.tpAbout.Size = new System.Drawing.Size(618, 275);
            this.tpAbout.TabIndex = 5;
            this.tpAbout.Text = "关于";
            this.tpAbout.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btnConnect, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnHide, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnExit, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(626, 34);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnect.Location = new System.Drawing.Point(10, 3);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(10, 3, 10, 7);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(136, 24);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(166, 3);
            this.btnSave.Margin = new System.Windows.Forms.Padding(10, 3, 10, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(136, 24);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnHide
            // 
            this.btnHide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHide.Location = new System.Drawing.Point(322, 3);
            this.btnHide.Margin = new System.Windows.Forms.Padding(10, 3, 10, 7);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(136, 24);
            this.btnHide.TabIndex = 1;
            this.btnHide.Text = "隐藏";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.ShowOrHide_Click);
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Location = new System.Drawing.Point(478, 3);
            this.btnExit.Margin = new System.Windows.Forms.Padding(10, 3, 10, 7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(138, 24);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowOrHide,
            this.tsmiConnOrDisconn,
            this.tsmiConfigurations,
            this.toolStripSeparator1,
            this.tsmiAbout,
            this.tsmiExit});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(101, 120);
            // 
            // tsmiShowOrHide
            // 
            this.tsmiShowOrHide.Name = "tsmiShowOrHide";
            this.tsmiShowOrHide.Size = new System.Drawing.Size(100, 22);
            this.tsmiShowOrHide.Text = "显示";
            this.tsmiShowOrHide.Click += new System.EventHandler(this.ShowOrHide_Click);
            // 
            // tsmiConnOrDisconn
            // 
            this.tsmiConnOrDisconn.Name = "tsmiConnOrDisconn";
            this.tsmiConnOrDisconn.Size = new System.Drawing.Size(100, 22);
            this.tsmiConnOrDisconn.Text = "连接";
            this.tsmiConnOrDisconn.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tsmiConfigurations
            // 
            this.tsmiConfigurations.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCreateConfig,
            this.aToolStripMenuItem});
            this.tsmiConfigurations.Name = "tsmiConfigurations";
            this.tsmiConfigurations.Size = new System.Drawing.Size(100, 22);
            this.tsmiConfigurations.Text = "配置";
            // 
            // tsmiCreateConfig
            // 
            this.tsmiCreateConfig.Name = "tsmiCreateConfig";
            this.tsmiCreateConfig.Size = new System.Drawing.Size(124, 22);
            this.tsmiCreateConfig.Text = "创建配置";
            this.tsmiCreateConfig.Click += new System.EventHandler(this.CreateConfig_Click);
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(121, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(97, 6);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(100, 22);
            this.tsmiAbout.Text = "关于";
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(100, 22);
            this.tsmiExit.Text = "退出";
            this.tsmiExit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // notifyicon
            // 
            this.notifyicon.Text = "notifyIcon1";
            this.notifyicon.Visible = true;
            this.notifyicon.DoubleClick += new System.EventHandler(this.ShowOrHide_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 339);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShellForPlink";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_OnClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpStatus.ResumeLayout(false);
            this.tpStatus.PerformLayout();
            this.tpSettings.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tpTunnels.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.grpBoxLocal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridLocal)).EndInit();
            this.grbBoxRemote.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridRemote)).EndInit();
            this.tpLicence.ResumeLayout(false);
            this.tpLicence.PerformLayout();
            this.tpReadMe.ResumeLayout(false);
            this.tpReadMe.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpStatus;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.TabPage tpTunnels;
        private System.Windows.Forms.TabPage tpLicence;
        private System.Windows.Forms.TabPage tpReadMe;
        private System.Windows.Forms.TabPage tpAbout;
        private System.Windows.Forms.TextBox txtbOutput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtbServerIP;
        private System.Windows.Forms.TextBox txtbServerPort;
        private System.Windows.Forms.TextBox txtbPassword;
        private System.Windows.Forms.TextBox txtbUsername;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.CheckBox chkConfirmBeforeExit;
        private System.Windows.Forms.CheckBox chkAutoConnOnStart;
        private System.Windows.Forms.CheckBox chkReConnAfterBreak;
        private System.Windows.Forms.CheckBox chkUsePrivateKey;
        private System.Windows.Forms.CheckBox chkVerboseOutput;
        private System.Windows.Forms.CheckBox chkLoopBackPing;
        private System.Windows.Forms.CheckBox chkUnlimitReConn;
        private System.Windows.Forms.CheckBox chkDynamicSocket;
        private System.Windows.Forms.CheckBox chkHidePortConnInfo;
        private System.Windows.Forms.CheckBox chkEchoServicePing;
        private System.Windows.Forms.CheckBox chkCompress;
        private System.Windows.Forms.CheckBox chkNoPrompt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtbReConnDelay;
        private System.Windows.Forms.TextBox txtbDynamicPort;
        private System.Windows.Forms.TextBox txtbLoopBackPingPort;
        private System.Windows.Forms.TextBox txtbLicence;
        private System.Windows.Forms.TextBox txtbReadMe;
        private System.Windows.Forms.TextBox txtbAdditionalArgs;
        private System.Windows.Forms.ComboBox cboLanguage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowOrHide;
        private System.Windows.Forms.ToolStripMenuItem tsmiConnOrDisconn;
        private System.Windows.Forms.ToolStripMenuItem tsmiConfigurations;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateConfig;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox grpBoxLocal;
        private System.Windows.Forms.DataGridView dGridLocal;
        private System.Windows.Forms.GroupBox grbBoxRemote;
        private System.Windows.Forms.DataGridView dGridRemote;
        private System.Windows.Forms.NotifyIcon notifyicon;
        private System.Windows.Forms.ToolStripSeparator aToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Loc_ListenIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Loc_ListenPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Loc_HostIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Loc_HostPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Rem_ListenIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Rem_ListenPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Rem_HostIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Rem_HostPort;
    }
}

