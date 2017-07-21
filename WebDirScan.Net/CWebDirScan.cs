using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Threading;

namespace WebDirScan.Net
{

    class WebScanResultEventArgs : EventArgs
    {
        private string url;
        private HttpStatusCode code;
        /// <summary>
        /// 总数
        /// </summary>
        private int total;
        /// <summary>
        /// 当前数量
        /// </summary>
        private int cur;


        public int TotalLines
        {
            get { return this.total; }
        }

        public int CurrentLineNum
        {
            get { return this.cur; }
        }

        public string URL
        {
            get { return this.url; }
        }

        public HttpStatusCode StatusCode
        {
            get { return this.code; }
        }

        public WebScanResultEventArgs(string url, HttpStatusCode code, int total, int cur)
        {
            this.url = url;
            this.code = code;
            this.total = total;
            this.cur = cur;
        }
    }

    class WebScanProgressEventArgs : EventArgs
    {
        /// <summary>
        /// 总数
        /// </summary>
        private int total;
        /// <summary>
        /// 当前数量
        /// </summary>
        private int cur;


        public int TotalLines
        {
            get { return this.total; }
        }

        public int CurrentLineNum
        {
            get { return this.cur; }
        }

        public WebScanProgressEventArgs(int total, int cur)
        {
            this.total = total;
            this.cur = cur;
        }

    }

    delegate void WebScanResultEventHandler(object sender, WebScanResultEventArgs e);
    delegate void WebScanProgressEventHandler(object sender, WebScanProgressEventArgs e);
    delegate void WebScanFinishedEventHandler(object sender, EventArgs e);
    class CWebDirScan : Object, IDisposable
    {
        private string DictPath;
        private List<string> lstDicts;
        private int TotalLines;
        private int CurLine;
        private string url;
        private bool bStop;
        private AutoResetEvent areCur;
        /// <summary>
        /// 扫描结果事件
        /// </summary>
        public event WebScanResultEventHandler OnScanResult;

        /// <summary>
        /// 进度事件
        /// </summary>
        public event WebScanProgressEventHandler OnProgress;

        /// <summary>
        /// 结束事件
        /// </summary>
        public event WebScanFinishedEventHandler OnFinished;

        public CWebDirScan(string DictPath)
        {
            this.init(DictPath);
            lstDicts = new List<string>();
        }

        public CWebDirScan()
        {
            lstDicts = new List<string>();
        }
        
        public static string[] LoadDicts(string DictPath)
        {
            if (!Directory.Exists(DictPath))
                return null;
            string[] files = Directory.GetFiles(DictPath);
            return files;
        }

        public void init(string DictPath)
        {
            bStop = false;
            areCur = new AutoResetEvent(true);
            System.Net.ServicePointManager.DefaultConnectionLimit = 512;
            this.DictPath = DictPath;
            if (!Directory.Exists(this.DictPath))
            {
                //目录不存在
                throw new DirectoryNotFoundException(string.Format("目录{0}不存在！", this.DictPath));
            }
        }

        public async Task Scan(string url, string[] DictFiles)
        {
            this.url = url;
            // 计算总行数
            TotalLines = 0;
            foreach (string filename in DictFiles)
            {
                TotalLines += await GetFileLines(filename);
            }
            // 开始扫描
            CurLine = 0;
            List<Task> lstTasks = new List<Task>();
            foreach (string filename in DictFiles)
            {
                if (!File.Exists(filename))
                    continue;
                var task = Task.Run(() => DoScan(filename));
                lstTasks.Add(task);
            }
            await Task.WhenAll(lstTasks);
            /*
            if (OnFinished != null)
            {
                OnFinished(this, new EventArgs());
            }*/
            var t = Task.Run(() => CheckStop());
            await Task.WhenAll(t);            
        }

        private void CheckStop()
        {
            while (true)
            {
                Thread.Sleep(100);
                if (bStop || CurLine >= TotalLines)
                {
                    if (OnFinished != null)
                    {
                        OnFinished(this, new EventArgs());
                    }
                    break;
                }
            }
        }

        



        private async void DoScan(string filename)
        {
            try
            {
                StreamReader sr = new StreamReader(filename);
                List<Task> lstTasks = new List<Task>();
                while (!sr.EndOfStream)
                {
                    string line = await sr.ReadLineAsync();
                    line = line.Trim();
                    if (line == "")
                    {
                        continue;
                    }
                    //line = HttpUtility.UrlEncode(line);
                    string u = this.url;                    
                    if (u.EndsWith("/") && line.StartsWith("/"))
                    {
                        u = u.Substring(0, u.Length - 1) + line;
                    }
                    else if (u.EndsWith("/") || line.StartsWith("/"))
                    {
                        u = u + line;
                    }
                    else
                    {
                        u = u + "/" + line;
                    }
                    Task t = Task.Run(() => Head(u));
                    lstTasks.Add(t);
                    if (lstTasks.Count > 20)
                    {
                        await Task.WhenAll(lstTasks);
                        lstTasks.Clear();
                        if (bStop)
                            break;
                    }
                }
                sr.Close();
            }
            catch (Exception err)
            {

            }
        }


        public async Task<int> GetFileLines(string filename)
        {
            if (!File.Exists(filename))
                return 0;
            int n = 0;
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(filename);
                while (!sr.EndOfStream)
                {
                    string line = await sr.ReadLineAsync();
                    if (line.Trim() == "")
                        continue;
                    n++;
                }
            }
            catch
            {
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
            return n;
        }


        public async Task Head(string url)
        {
            HttpStatusCode code = HttpStatusCode.OK;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            
            req.Method = WebRequestMethods.Http.Head;
            req.Timeout = 1000;
            try
            {
                WebResponse resp = await req.GetResponseAsync();
                code = ((HttpWebResponse)resp).StatusCode;
            }
            catch (WebException ex)
            {
                code = ((HttpWebResponse)ex.Response).StatusCode;
            }
            areCur.WaitOne();
            CurLine += 1;
            areCur.Set();
            if (OnScanResult != null)
            {
                OnScanResult(this, new WebScanResultEventArgs(url, code, TotalLines, CurLine));
            }
        }
        public void Stop()
        {
            bStop = true;
        }
        public void Dispose()
        {
            
        }
    }
}
