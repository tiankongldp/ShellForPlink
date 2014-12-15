using System;
using System.Text;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace ShellForPlink
{
    [Serializable, XmlType(AnonymousType = true), DesignerCategory("code"), GeneratedCode("xsd", "2.0.50727.42")]
    public class PlinkConfig
    {
        private string configNameField = "";
        private string serverIPField = "";
        private int serverPortField = 22;
        private string usernameField = "";
        private string passwordField = "";
        private bool autoConnOnStartField = false;
        private bool reConnAfterBreakField = false;
        private bool unLimitReConnField = false;
        private bool usePrivateKeyField = false;
        private LogLevel LoglevelField = LogLevel.Normal;
        private bool loopBackPingField = true;
        private bool confirmBeforeExitField = true;
        private bool echoServicePingField = false;
        private bool dynamicSocketField = false;
        private bool hidePortConnInfoField = false;
        private bool compressField = false;
        private bool noPromptField = false;
        private int reConnDelayField = 10;
        private int dynamicPortField = 1080;
        private int loopBackPingPortField = 7070;
        private string additionalArgsField = "-v -N -ssh -2 -4";
        private List<PortForward> localForwardField = new List<PortForward>();
        private List<PortForward> remoteForwardField = new List<PortForward>();

        public string ConfigName
        {
            get { return configNameField; }
            set { configNameField = value; }
        }
        public string ServerIP
        {
            get { return serverIPField; }
            set { serverIPField = value; }
        }
        public int ServerPort
        {
            get { return serverPortField; }
            set { serverPortField = value; }
        }
        public string Username
        {
            get { return usernameField; }
            set { usernameField = value; }
        }
        public string Password
        {
            get { return passwordField; }
            set { passwordField = value; }
        }
        [XmlIgnore]
        public string PasswordCrypt
        {
            get {
                if (passwordField.Length == 0)
                    return passwordField;
                else
                    return Encryption.Decrypt(passwordField);
            }
            set {
                if ((value + "").Length == 0)
                    passwordField = "";
                else
                {
                    passwordField = Encryption.Encrypt(value);
                }
            }
        }
        public bool AutoConnOnStart
        {
            get { return autoConnOnStartField; }
            set { autoConnOnStartField = value; }
        }
        public bool ReConnAfterBreak
        {
            get { return reConnAfterBreakField; }
            set { reConnAfterBreakField = value; }
        }
        public bool UnLimitReConn
        {
            get { return unLimitReConnField; }
            set { unLimitReConnField = value; }
        }
        public bool UsePrivateKey
        {
            get { return usePrivateKeyField; }
            set { usePrivateKeyField = value; }
        }
        public LogLevel Loglevel
        {
            get { return LoglevelField; }
            set { LoglevelField = value; }
        }
        public bool LoopBackPing
        {
            get { return loopBackPingField; }
            set { loopBackPingField = value; }
        }
        public bool EchoServicePing
        {
            get { return echoServicePingField; }
            set { echoServicePingField = value; }
        }
        public bool ConfirmBeforeExit
        {
            get { return confirmBeforeExitField; }
            set { confirmBeforeExitField = value; }
        }
        public bool DynamicSocket
        {
            get { return dynamicSocketField; }
            set { dynamicSocketField = value; }
        }
        public bool HidePortConnInfo
        {
            get { return hidePortConnInfoField; }
            set { hidePortConnInfoField = value; }
        }
        public bool Compress
        {
            get { return compressField; }
            set { compressField = value; }
        }
        public bool NoPrompt
        {
            get { return noPromptField; }
            set { noPromptField = value; }
        }
        public int ReConnDelay
        {
            get { return reConnDelayField; }
            set { reConnDelayField = value; }
        }
        public int DynamicPort
        {
            get { return dynamicPortField; }
            set { dynamicPortField = value; }
        }
        public int LoopBackPingPort
        {
            get { return loopBackPingPortField; }
            set { loopBackPingPortField = value; }
        }
        public string AdditionalArgs
        {
            get { return additionalArgsField; }
            set { additionalArgsField = value; }
        }
        public List<PortForward> LocalForward
        {
            get { return localForwardField; }
            set { localForwardField = value; }
        }
        public List<PortForward> RemoteForward
        {
            get { return remoteForwardField; }
            set { remoteForwardField = value; }
        }

        public string FullArgument
        {
            get
            {
                StringBuilder sbArgs = new StringBuilder();
                sbArgs.Append(this.AdditionalArgs + " ");
                if (!this.AdditionalArgs.Contains("-N"))
                    sbArgs.Append("-N ");
                if (!this.AdditionalArgs.Contains("-ssh"))
                    sbArgs.Append("-ssh ");
                if (!this.AdditionalArgs.Contains("-2"))
                    sbArgs.Append("-2 ");
                if (!this.AdditionalArgs.Contains("-4"))
                    sbArgs.Append("-4 ");
                //if (this.NoPrompt)
                //    sbArgs.Append("-batch ");
                if (!this.AdditionalArgs.Contains("-v"))
                    sbArgs.Append("-v ");
                if (this.Compress)
                    sbArgs.Append("-C ");
                if (this.UsePrivateKey)
                    sbArgs.Append("-i " + this.ConfigName + ".ppk ");
                if (this.DynamicSocket)
                    sbArgs.Append("-D " + this.DynamicPort + " ");
                if (this.loopBackPingField)
                {
                    sbArgs.Append("-L " + this.LoopBackPingPort + ":127.0.0.1:" + this.LoopBackPingPort + " ");
                    sbArgs.Append("-R " + this.LoopBackPingPort + ":127.0.0.1:" + (this.LoopBackPingPort + 1).ToString() + " ");
                }
                if (this.echoServicePingField)
                    sbArgs.Append("-L " + this.LoopBackPingPort + ":127.0.0.1:" + this.LoopBackPingPort + " ");
                for (int i = 0; i < this.localForwardField.Count; i++)
                {
                    if ((this.echoServicePingField && localForwardField[i].ListenPort == this.loopBackPingPortField)
                        || this.loopBackPingField && (localForwardField[i].ListenPort == this.loopBackPingPortField || localForwardField[i].ListenPort == this.loopBackPingPortField + 1))
                        continue;
                    sbArgs.Append("-L " + localForwardField[i].ListenIP + ":" + localForwardField[i].ListenPort + ":" + localForwardField[i].HostIP + ":" + localForwardField[i].HostPort + " ");
                }
                for (int i = 0; i < this.remoteForwardField.Count; i++)
                {
                    if ((this.echoServicePingField && remoteForwardField[i].ListenPort == this.loopBackPingPortField))
                        continue;
                    sbArgs.Append("-R " + remoteForwardField[i].ListenIP + ":" + remoteForwardField[i].ListenPort + ":" + remoteForwardField[i].HostIP + ":" + remoteForwardField[i].HostPort + " ");
                }
                if (this.ServerPort != 22)
                    sbArgs.Append("-P " + this.ServerPort + " ");
                sbArgs.Append("-l " + this.Username + " ");
                sbArgs.Append(this.ServerIP);

                return sbArgs.ToString();
            }
        }
    }
}
