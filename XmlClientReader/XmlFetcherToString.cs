using System;
using System.Net;

namespace XmlClientReader
{
    public class XmlFetcherToString
    {
        private String url;
        public XmlFetcherToString(String url)
        {
            this.url = url;
        }

        public String XmlClientReaderToString()
        {
            String xmlreaderresult;
            WebClient webClient = new WebClient();

            System.IO.Stream stream = webClient.OpenRead(this.url);
            if (!stream.CanRead)
                throw new ArgumentNullException();

            System.IO.StreamReader streamReader = new System.IO.StreamReader(stream);
            if (streamReader == null)
                throw new Exception("Streamreader can\'t be opened");

            xmlreaderresult = streamReader.ReadToEnd();

            return xmlreaderresult;
        }
    }
}
