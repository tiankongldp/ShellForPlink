using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ShellForPlink
{
    [Serializable, GeneratedCode("xsd", "2.0.50727.42"), DesignerCategory("code"), XmlType(AnonymousType=true)]
    public class PortForward
    {
        private ForwardType forwardTypeField;
        private string listenIPField;
        private int listenPortField;
        private string hostIPField;
        private int hostPortField;

        public ForwardType ForwardType
        {
            get { return forwardTypeField; }
            set { forwardTypeField = value; }
        }

        public string ListenIP
        {
            get { return listenIPField; }
            set { listenIPField = value; }
        }
        
        public int ListenPort
        {
            get { return listenPortField; }
            set { listenPortField = value; }
        }
        
        public string HostIP
        {
            get { return hostIPField; }
            set { hostIPField = value; }
        }
        
        public int HostPort
        {
            get { return hostPortField; }
            set { hostPortField = value; }
        }
    }

    public enum ForwardType
    {
        Local,
        Remote
    }
}
