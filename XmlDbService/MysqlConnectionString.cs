using System;

namespace XmlDbService
{

    public class MysqlConnectionString
    {
        // Persist Security Info=False;database={0};server={1};port=3306;Connect Timeout=30;user id={2}; pwd={3}
        String server { get; }
        String ui { get; }
        String pwd { get; }
        String db { get; }

       public String getServer()
        {
            return this.server;
        }
        public String getUi()
        {
            return this.ui;
        }
        public String getPwd()
        {
            return this.pwd;
        }
        public String getDb()
        {
            return this.db;
        }

        public MysqlConnectionString(String server, String ui, String pwd, String db)
        {
            this.server = server;
            this.ui = ui;
            this.pwd = pwd;
            this.db = db;
        }
    }
}
