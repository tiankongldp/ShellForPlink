using System;
using System.Windows.Forms;

namespace ShellForPlink
{
    public partial class frmCreateConfig : Form
    {
        private PlinkConfigCollection plinkconfigs;
        public string ConfigName = "";

        public frmCreateConfig()
        {
            InitializeComponent();
        }

        public DialogResult ShowForm(PlinkConfigCollection pconfigs)
        {
            if (pconfigs == null)
            {
                throw new Exception("配置为空");
            }
            this.plinkconfigs = pconfigs;
            return this.ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtbConfigName.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入配置名！");
                return;
            }
            if (plinkconfigs.configDict.ContainsKey(this.txtbConfigName.Text.Trim()))
            {
                MessageBox.Show("配置名已存在！");
                return;
            }
            this.ConfigName = txtbConfigName.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
