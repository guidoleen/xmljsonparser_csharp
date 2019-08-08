using System;
using System.Xml;

namespace XmlClientReader
{
    public class XmlDocFromUrl
    {
        private String path;
        public XmlDocFromUrl(String path)
        {
            this.path = path;
        }

        private XmlDocument GetXmlDocument()
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(new XmlFetcherToString(this.path).XmlClientReaderToString());

            return xml;
        }

        public String ReadOutXmlDocument(String singleNode)
        {
            String readoutxmlval = "";
            // XmlNode node = // DocumentElement.SelectSingleNode(singleNode);

            
            //foreach (node in .DocumentElement.ChildNodes)
            //{
            //    readoutxmlval += node.InnerText;
            //}

            return readoutxmlval = GetXmlDocument().HasChildNodes.ToString();
        }
 
    }
}
