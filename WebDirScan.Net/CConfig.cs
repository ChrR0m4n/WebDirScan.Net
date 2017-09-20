using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;


namespace WebDirScan.Net
{
    /// <summary>
    /// 配置管理
    /// </summary>
    class CConfig
    {
        /// <summary>
        /// 配置
        /// </summary>
        public Configuration Conf
        {
            get
            {
                string confFilePath = Assembly.GetEntryAssembly().Location;
                Configuration conf = ConfigurationManager.OpenExeConfiguration(confFilePath);
                return conf;
            }
        }
        /// <summary>
        /// appSettings配置段
        /// </summary>
        public AppSettingsSection SettingSection
        {
            get
            {
                AppSettingsSection ass = (AppSettingsSection)this.Conf.GetSection("appSettings");
                return ass;
            }
        }
        /// <summary>
        /// 检查某一个配置是否存在
        /// </summary>
        /// <param name="szSettingName">配置名</param>
        /// <returns>boolean</returns>
        private bool isSettingExists(string szSettingName)
        {
            bool flag = false;
            foreach (string i in this.SettingSection.Settings.AllKeys)
            {
                if (i == szSettingName)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        /// <summary>
        /// 取得字典路径配置
        /// </summary>
        /// <returns>字典路径</returns>
        public string getDictPath()
        {
            if (isSettingExists("DictPath"))
            {
                return ConfigurationManager.AppSettings["DictPath"];
            }
            else
            {
                return ".\\Dicts\\";
            }
        }
        /// <summary>
        /// 设置字典路径
        /// </summary>
        /// <param name="szPath">字典路径</param>
        public void setDictPath(string szPath)
        {
            Configuration conf = this.Conf;
            AppSettingsSection ass = (AppSettingsSection)conf.GetSection("appSettings");
            if (isSettingExists("DictPath"))
            {
                ass.Settings.Remove("DictPath");
                ass.Settings.Add("DictPath", szPath);
                conf.Save();
            }
            else
            {
                ass.Settings.Add("DictPath", szPath);
                conf.Save();
            }
        }
        /// <summary>
        /// 获取HTTP超时时间
        /// </summary>
        /// <returns>毫秒</returns>
        public int getHttpTimeout()
        {
            if (isSettingExists("HttpTimeout"))
            {
                try
                {
                    return int.Parse(this.SettingSection.Settings["HttpTimeout"].Value);
                }
                catch
                {
                    return 1000;
                }
            }
            else
            {
                return 1000;
            }
        }
        /// <summary>
        /// 设置HTTP超时时间
        /// </summary>
        /// <param name="nTimeout">毫秒</param>
        public void setHttpTimeout(int nTimeout)
        {
            Configuration conf = this.Conf;
            AppSettingsSection ass = (AppSettingsSection)conf.GetSection("appSettings");
            if (isSettingExists("HttpTimeout"))
            {
                ass.Settings.Remove("HttpTimeout");
                ass.Settings.Add("HttpTimeout", string.Format("{0}", nTimeout));
                conf.Save();
            }
            else
            {
                ass.Settings.Add("HttpTimeout", string.Format("{0}", nTimeout));
                conf.Save();
            }
        }

        public int getTasks()
        {
            if (isSettingExists("Tasks"))
            {
                try
                {
                    return int.Parse(this.SettingSection.Settings["Tasks"].Value);
                }
                catch
                {
                    return 20;
                }
            }
            else
            {
                return 20;
            }
        }

        public void setTasks(int nTasks)
        {
            Configuration conf = this.Conf;
            AppSettingsSection ass = (AppSettingsSection)conf.GetSection("appSettings");
            if (isSettingExists("Tasks"))
            {
                ass.Settings.Remove("Tasks");
                ass.Settings.Add("Tasks", string.Format("{0}", nTasks));
                conf.Save();                
            }
            else
            {
                ass.Settings.Add("Tasks", string.Format("{0}", nTasks));
                conf.Save();
            }
        }


    }
}
