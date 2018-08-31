using System;
using System.ComponentModel;

namespace Lyh.Libs.MyEnum
{
    /// <summary>
    /// Author：lyh
    /// Description：Enum 帮助类
    /// Date：2013-07-16
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// 获得指定枚举的描述文字（[Description("标签中的文字")]）
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Description(this Enum value)
        {
            var enumType = value.GetType();
            var field = enumType.GetField(value.ToString());
            if (field == null) return string.Empty;
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length == 0 ? value.ToString() : ((DescriptionAttribute)attributes[0]).Description;
        }
    }
}
