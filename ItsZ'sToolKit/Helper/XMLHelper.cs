using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ItsZ_sToolKit.Helper
{
    public class XMLHelper
    {
        public string path = "";
        public string fileName = "";

        public XMLHelper(string fileName)
        {
            fileName = fileName;
        }

        //public string ReadByTagName(string fieldName)
        //{
        //    XmlDocument doc = new XmlDocument();

        //    // 获得配置文件的全路径　　  
        //    string strFileName = fileName;

        //    doc.Load(strFileName); 
        //    XmlNode node = doc.GetElementById("font"); 
        //    XmlNodeList nodes = node.ChildNodes;
        //    for (int i = 0; i < nodes.Count; i++)
        //    {
        //        if (nodes[i].NodeType == XmlNodeType.Element)
        //        {
        //            m_FontList[nodes[i].Name] = nodes[i].InnerText;
        //        }
        //    }
        //}
    }
}
