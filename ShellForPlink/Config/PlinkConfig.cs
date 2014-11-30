using System;
using System.Text;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Xml.Serialization;

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
        private bool verboseOutputField = false;
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
        private string additionalArgsField = "-N -ssh -2";

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
        public bool VerboseOutput
        {
            get { return verboseOutputField; }
            set { verboseOutputField = value; }
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
                //if (this.NoPrompt)
                //    sbArgs.Append("-batch ");
                if (this.VerboseOutput)
                    sbArgs.Append("-v ");
                if (this.Compress)
                    sbArgs.Append("-C ");
                if (this.UsePrivateKey)
                    sbArgs.Append("-i " + this.ConfigName + ".pk ");
                if (this.DynamicSocket)
                    sbArgs.Append("-D 127.0.0.1:" + this.DynamicPort + " ");
                if (this.loopBackPingField)
                {
                    sbArgs.Append("-L 127.0.0.1:" + this.LoopBackPingPort + ":127.0.0.1:" + this.LoopBackPingPort + " ");
                    sbArgs.Append("-R 127.0.0.1:" + this.LoopBackPingPort + ":127.0.0.1:" + (this.LoopBackPingPort + 1).ToString() + " ");
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
