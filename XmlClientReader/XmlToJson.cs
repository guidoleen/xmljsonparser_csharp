using System;
using System.Collections.Generic;

namespace XmlClientReader
{
    //TODO > extra rekening houden met attributes in een xml
    public class XmlToJson
    {
        public String XmlToJsonString(List<KeyValuePair<String, String>> list)
        {
            String strJson = "{";
            int index = 0;
            int iL = list.Count;
            String tempvalue = "";

            for (int i = 0; i < iL; i++)
            {
                index++;
                if (index >= iL) index = (iL - 1);

                strJson += "\"" + list[i].Key + "\":";

                if (list[i].Value.Contains(XmlClientReaderCONST.SEPERATOR))
                {
                    strJson += "{" + list[i].Value + "}";
                }
                else
                    strJson += list[i].Value;

                strJson += ", ";

            }
            strJson += strJson.Substring(0, iL - 2);
            strJson += "} }";

            return strJson;
        }
    }
}
