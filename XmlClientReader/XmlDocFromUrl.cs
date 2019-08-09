using System;
using System.Xml;
using System.Collections.Generic;

namespace XmlClientReader
{
    public class XmlDocFromUrl
    {
        private String path;
        private List<KeyValuePair<String, String>> xmlDocList = new List<KeyValuePair<String, String>>();

        public List<KeyValuePair<String, String>> GetXmlDocList()
        {
            ReadOutXmlDocToMapping();
            return this.xmlDocList;
        }

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

        private void ReadOutXmlDocToMapping()
        {
            XmlDocument xml = GetXmlDocument();
            XmlNode root = xml.DocumentElement;
            String key, value = "";
            XmlAttributeCollection attr;
            int iTeller = 0;

            if (root != null )
            {
                foreach (XmlNode xmln in root)
                {
                    iTeller++;

                    key = xmln.Name + iTeller.ToString();
                    attr = xmln.Attributes;
                    if (attr != null)
                        value = AttributeIteration(attr);
                    else
                        value = xmln.InnerText;

                    xmlDocList.Add( new KeyValuePair<string, string>(key, value) );
                }
            }
        }

        private String AttributeIteration(XmlAttributeCollection xmlAttr)
        {
            String attributeResult = "";
            for(int i = 0; i<xmlAttr.Count; i++)
            {
                attributeResult += (xmlAttr.Item(i).Name + XmlClientReaderCONST.SEPERATOR + xmlAttr.Item(i).Value + "\n");
            }
            return attributeResult;
        }
    }
}
