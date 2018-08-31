using System.Configuration;

namespace Lyh.Libs.Xml
{
    /// <summary>
    /// Author：lyh
    /// Description：AppSetting 帮助类
    /// Date：2013-07-16
    /// </summary>
    public class AppSettingHelper
    {
        public static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static void SetSetting(string key, string value)
        {
            ConfigurationManager.AppSettings[key] = value;
        }
    }
}
