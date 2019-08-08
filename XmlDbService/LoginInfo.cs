using System;

namespace XmlDbService
{
    public class LoginInfo
    {
        private String text { get; }
        private String type { get; }
        private DateTime datetime { get; }

        public String GetText()
        {
            return this.text;
        }
        public String GetType()
        {
            return this.type;
        }
        public DateTime GetTDateTime()
        {
            return this.datetime;
        }


        public LoginInfo(String text,String type, DateTime dateTime)
        {
            this.text = text;
            this.type = type;
            this.datetime = dateTime;
        }

        override
            public String ToString()
        {
            String strFormat = String.Format("%s %d %s",
                    this.text,
                    this.datetime,
                    this.type
                );

            return strFormat;
        }
    }
}
