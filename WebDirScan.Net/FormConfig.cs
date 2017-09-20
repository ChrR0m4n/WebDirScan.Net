using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WebDirScan.Net
{
    public partial class FormConfig : Form
    {
        CConfig config;
        public FormConfig()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int nTimeout = (int)nudHttpTimeout.Value;
            int nTasks = (int)nudTasks.Value;
            config.setHttpTimeout(nTimeout);
            config.setTasks(nTasks);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            config = new CConfig();
            nudHttpTimeout.Value = (decimal)config.getHttpTimeout();
            nudTasks.Value = (decimal)config.getTasks();
        }
    }
}
