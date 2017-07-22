using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Reflection;
using System.Net;

namespace WebDirScan.Net
{
    public partial class Form1 : Form
    {
        private string DictPath;
        private CWebDirScan webScan;
        private DateTime last;
        private int cnt;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.DictPath = ConfigurationManager.AppSettings["DictPath"];
                if (this.DictPath == null)
                    throw new Exception("找不到字典路径配置");
                tssLblDctPath.Text = this.DictPath;
            }
            catch
            {
                string confFilePath = Assembly.GetEntryAssembly().Location;
                Configuration conf = ConfigurationManager.OpenExeConfiguration(confFilePath);
                AppSettingsSection ass = (AppSettingsSection)conf.GetSection("appSettings");
                ass.Settings.Add("DictPath", ".\\Dicts\\");
                conf.Save();
                tssLblDctPath.Text = ".\\Dicts\\";
            }
            lvResult.Columns.Clear();
            lvResult.Columns.Add("Status", 60);
            lvResult.Columns.Add("URL", lvResult.Width - 80);
            cnt = 0;
            last = DateTime.MinValue;
            try
            {
                string[] dictFiles = CWebDirScan.LoadDicts(this.DictPath);
                if (dictFiles != null)
                {
                    clbDicts.Items.AddRange(dictFiles);
                }
                else
                {
                    MessageBox.Show(string.Format("在目录{0}下没有找到字典!", this.DictPath),
                        "错误",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                webScan = new CWebDirScan();
                webScan.OnScanResult += webScan_OnScanResult;
                webScan.OnFinished += webScan_OnFinished;
            }
            catch
            {
            }
        }

        private delegate void DelegEventProcess(Object e);

        void EventProcess(Object e)
        {
            if (e.GetType() == typeof(WebScanResultEventArgs))
            {
                cnt++;
                if (last == DateTime.MinValue)
                    last = DateTime.Now;
                else
                {
                    TimeSpan ts = DateTime.Now - last;
                    if (ts.TotalSeconds >= 1.0)
                    {
                        last = DateTime.Now;
                        lock (lssLblSpeed)
                        {
                            lssLblSpeed.Text = string.Format("每秒{0}个页面", cnt);
                        }
                        cnt = 0;
                    }
                }
                WebScanResultEventArgs arg = (WebScanResultEventArgs)e;
                lock (tssLblFile)
                {
                    tssLblFile.Text = arg.URL;
                }
                if (
                    arg.StatusCode == HttpStatusCode.OK
                    || arg.StatusCode == HttpStatusCode.Forbidden
                    || arg.StatusCode == HttpStatusCode.Redirect
                    )
                {
                    lock (lvResult)
                    {
                        //lvResult.BeginUpdate();
                        ListViewItem lvi = new ListViewItem(arg.StatusCode.ToString());
                        lvi.SubItems.Add(arg.URL);
                        lvResult.Items.Add(lvi);
                        //lvResult.EndUpdate();
                    }
                }
                lock (tsProssBar)
                {
                    tsProssBar.Maximum = arg.TotalLines;
                    tsProssBar.Value = arg.CurrentLineNum;
                }
                
            }
            else if (e.GetType() == typeof(WebScanProgressEventArgs))
            {
                WebScanProgressEventArgs arg = (WebScanProgressEventArgs)e;
                tsProssBar.Maximum = arg.TotalLines;
                tsProssBar.Value = arg.CurrentLineNum;
            }
            else if (e.GetType() == typeof(EventArgs))
            {
                MessageBox.Show("扫描结束，请检查结果!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clbDicts.Enabled = true;
                txtUrl.Enabled = true;
                btnScan.Text = "Scan";
                btnScan.Enabled = true;
            }
        }

        /// <summary>
        /// 扫描结束事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void webScan_OnFinished(object sender, EventArgs e)
        {
            this.Invoke(new DelegEventProcess(this.EventProcess), e);
        }
        /// <summary>
        /// 扫描结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void webScan_OnScanResult(object sender, WebScanResultEventArgs e)
        {
            this.Invoke(new DelegEventProcess(this.EventProcess), e);
        }
        /// <summary>
        /// 扫描进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void webScan_OnProgress(object sender, WebScanProgressEventArgs e)
        {
            this.Invoke(new DelegEventProcess(this.EventProcess), e);
        }

        

        private void 修改字典路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.DictPath = fbd.SelectedPath;
                tssLblDctPath.Text = this.DictPath;
                try
                {
                    string confFilePath = Assembly.GetEntryAssembly().Location;
                    Configuration conf = ConfigurationManager.OpenExeConfiguration(confFilePath);
                    AppSettingsSection ass = (AppSettingsSection)conf.GetSection("appSettings");
                    ass.Settings.Remove("DictPath");
                    ass.Settings.Add("DictPath", this.DictPath);
                    conf.Save();
                }
                catch
                {
                    MessageBox.Show("保存字典配置失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            try
            {
                string[] dictFiles = CWebDirScan.LoadDicts(this.DictPath);
                clbDicts.Items.Clear();
                if (dictFiles != null)
                {
                    clbDicts.Items.AddRange(dictFiles);
                }
                else
                {
                    MessageBox.Show(string.Format("在目录{0}下没有找到字典!", this.DictPath),
                        "错误",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch
            {
            }
        }

        private async void btnScan_Click(object sender, EventArgs e)
        {
            if (btnScan.Text == "Scan")
            {
                
                string url = txtUrl.Text.Trim();
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    MessageBox.Show("URL格式错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (clbDicts.CheckedItems.Count < 1)
                {
                    MessageBox.Show("请选择至少一个字典！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lvResult.Items.Clear();
                btnScan.Text = "Stop";
                clbDicts.Enabled = false;
                txtUrl.Enabled = false;
                List<string> dicts = new List<string>();
                foreach (object obj in clbDicts.CheckedItems)
                {
                    dicts.Add((string)obj);
                }
                webScan.init(this.DictPath);
                await webScan.Scan(url, dicts.ToArray());
            }
            else
            {
                webScan.Stop();
                btnScan.Enabled = false;
            }
        }


    }
}
