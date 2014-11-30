using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ShellForPlink
{
    [Serializable, XmlType(AnonymousType = true), DesignerCategory("code"), GeneratedCode("xsd", "2.0.50727.42")]
    public class PlinkConfigCollection
    {
        [XmlIgnore]
        public Dictionary<string,int> configDict = new Dictionary<string,int>();
        [XmlIgnore]
        public PlinkConfig CurConfig;

        private DateTime lastUseDateField = DateTime.Now;
        private string lastUseConfigField = "";
        private List<PlinkConfig> configsField = new List<PlinkConfig>();

        public DateTime LastUseDate
        {
            get
            {
                return this.lastUseDateField;
            }
            set
            {
                this.lastUseDateField = value;
            }
        }
        public string LastUseConfig
        {
            get
            {
                return this.lastUseConfigField;
            }
            set
            {
                this.lastUseConfigField = value;
            }
        }
        public List<PlinkConfig> Configs
        {
            get
            {
                return this.configsField;
            }
            set
            {
                this.configsField = value;
            }
        }

        public void CreateConfig(string ConfigName)
        {
            if (configDict.ContainsKey(ConfigName))
                throw new Exception("配置名已存在！");
            CurConfig = new PlinkConfig();
            CurConfig.ConfigName = ConfigName;
            configsField.Add(CurConfig);
            configDict.Add(ConfigName, configsField.Count - 1);
            lastUseConfigField = ConfigName;
            lastUseDateField = DateTime.Now;
        }

        public void ChangeConfig(string ConfigName)
        {
            if (!configDict.ContainsKey(ConfigName))
                throw new Exception("配置名不存在！");
            CurConfig = configsField[configDict[ConfigName]];
            lastUseConfigField = ConfigName;
            lastUseDateField = DateTime.Now;
        }

        public void FillConfigDict()
        {
            configDict.Clear();
            for (int i = 0; i <= configsField.Count - 1; i++)
            {
                if (configDict.ContainsKey(configsField[i].ConfigName))
                    throw new Exception("配置名重复！");
                else
                    configDict.Add(configsField[i].ConfigName, i);
            }
        }

        public void FillCurConfigobj()
        {
            if (this.lastUseConfigField.Length > 0 && configDict.ContainsKey(lastUseConfigField))
            {
                CurConfig = Configs[configDict[lastUseConfigField]];
                lastUseConfigField = CurConfig.ConfigName;
                lastUseDateField = DateTime.Now;
            }
            else if (configsField.Count > 0)
            {
                CurConfig = Configs[0];
                lastUseConfigField = CurConfig.ConfigName;
                lastUseDateField = DateTime.Now;
            }
            else
            {
                this.CreateConfig("Default");
            }

        }
    }
}
