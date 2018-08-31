using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Lyh.Libs.MyConverter
{
    /// <summary>
    /// Author：lyh
    /// Description：Json 转换器
    /// Date：2013-07-16
    /// </summary>
    public static class JsonConverter
    {
        /// <summary>
        /// 将指定对象序列化为JavaScript对象表示法（JSON）数据。
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>JSON数据</returns>
        public static string ToJson(this object obj)
        {
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(obj.GetType());
            dcjs.WriteObject(ms, obj);
            byte[] bytes = ms.ToArray();
            string json = Encoding.UTF8.GetString(bytes);
            ms.Close();
            return json;
        }

        /// <summary>
        /// 以JSON（JavaScript对象表示法）格式读取字符串，并返回反序列化的对象。
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="json">JSON数据</param>
        /// <returns>对象</returns>
        public static T FromJson<T>(string json)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            MemoryStream ms = new MemoryStream(bytes);
            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(T));
            T t = (T)dcjs.ReadObject(ms);
            ms.Close();
            return t;
        }

        /// <summary>
        /// 以JSON（JavaScript对象表示法）格式读取字符串，并返回反序列化的对象。
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="stream">Stream</param>
        /// <returns>对象</returns>
        public static T FromJson<T>(Stream stream)
        {
            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(T));
            T t = (T)dcjs.ReadObject(stream);
            stream.Close();
            return t;
        }
    }
}