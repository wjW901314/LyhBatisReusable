using System.Configuration;

namespace Lyh.Libs.Xml
{
    /// <summary>
    /// Author：lyh
    /// Description：Config帮助类
    /// Date：2013-01-21
    /// </summary>
    public class ConfigHelper
    {
        private string file = string.Empty;
        private readonly Configuration config = null;

        public ConfigHelper(string file)
        {
            this.file = file;
            var map = new ExeConfigurationFileMap {ExeConfigFilename = file};
            config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
        }

        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public void SetValue(string key, string value)
        {
            if (config.AppSettings.Settings[key] == null) config.AppSettings.Settings.Add(key, value);
            else config.AppSettings.Settings[key].Value = value;
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="key">键</param>
        public string GetValue(string key)
        {
            if (config.AppSettings.Settings[key] == null) return null;
            else return config.AppSettings.Settings[key].Value;
        }

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            config.Save();
        }
    }
}
