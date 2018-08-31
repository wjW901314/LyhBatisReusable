using System.Xml;

namespace Lyh.Libs.Xml
{
    /// <summary>
    /// Author：lyh
    /// Description：Xml帮助类
    /// Date：2013-09-08
    /// </summary>
    public class XmlHelper
    {
        private readonly string xml = string.Empty;
        private readonly XmlDocument doc = null;

        public XmlHelper(string xml)
        {
            this.xml = xml;
            doc = new XmlDocument();
            doc.Load(xml);
        }

        /// <summary>
        /// 获得给定路径的节点
        /// </summary>
        /// <param name="xpath">以斜杠开始的路径，如：/a/b/c</param>
        /// <returns>节点</returns>
        public XmlNode GetNode(string xpath)
        {
            var xmlns = doc.ChildNodes[1].NamespaceURI;

            XmlNode node;
            if (!string.IsNullOrEmpty(xmlns))
            {
                var nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("ns", xmlns);
                xpath = xpath.Replace("/", "/ns:");
                node = doc.SelectSingleNode(xpath, nsmgr);
            }
            else
            {
                node = doc.SelectSingleNode(xpath);
            }
            return node;
        }

        public XmlNodeList GetNodes(string xpath)
        {
            var xmlns = doc.ChildNodes[1].NamespaceURI;

            XmlNodeList nodes;
            if (!string.IsNullOrEmpty(xmlns))
            {
                var nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("ns", xmlns);
                xpath = xpath.Replace("/", "/ns:");
                nodes = doc.SelectNodes(xpath, nsmgr);
            }
            else
            {
                nodes = doc.SelectNodes(xpath);
            }
            return nodes;
        }

        /// <summary>
        /// 设置给定路径及给定属性的值
        /// </summary>
        /// <param name="xpath">以斜杠开始的路径，如：/a/b/c</param>
        /// <param name="attribute">要设置的属性名称</param>
        /// <param name="value">要设置的属性值</param>
        public void SetValue(string xpath, string attribute, string value)
        {
            XmlNode node = GetNode(xpath);
            node.Attributes[attribute].Value = value;
        }

        /// <summary>
        /// 设置给定路径的值
        /// </summary>
        /// <param name="xpath">以斜杠开始的路径，如：/a/b/c</param>
        /// <param name="value">要设置的属性值</param>
        public void SetValue(string xpath, string value)
        {
            XmlNode node = GetNode(xpath);
            node.InnerXml = value;
        }

        /// <summary>
        /// 获得给点路径及给定属性的值
        /// </summary>
        /// <param name="xpath">以斜杠开始的路径，如：/a/b/c</param>
        /// <param name="attribute">要设置的属性名称</param>
        /// <returns>值</returns>
        public string GetValue(string xpath, string attribute)
        {
            XmlNode node = GetNode(xpath);
            return node.Attributes[attribute].Value;
        }

        /// <summary>
        /// 获得给点路径的值
        /// </summary>
        /// <param name="xpath">以斜杠开始的路径，如：/a/b/c</param>
        /// <returns>值</returns>
        public string GetValue(string xpath)
        {
            XmlNode node = GetNode(xpath);
            return node.InnerXml;
        }

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            doc.Save(xml);
        }
    }
}
