using System;
using MySql.Data;

public class MySqlConnector : IDBConnector
{
    private MySql.Data.MySqlClient.MySqlConnection conn;
    private String server, ui, pwd, db;

    public MySqlConnector(String server, String ui, String pwd, String db)
    {
        this.server = server;
        this.ui = ui;
        this.pwd = pwd;
        this.db = db;
    }

    public object GetDBConnector() // MySql.Data.MySqlClient.MySqlConnection
    {
        conn = new MySql.Data.MySqlClient.MySqlConnection();
        conn.ConnectionString = SetConnectionString();

        return conn;
    }

    private String SetConnectionString()
    {
        String connectionstr = String.Format("Persist Security Info=False;database={0};server={1};Connect Timeout=30;user id={2}; pwd={3}",
            this.db,
            this.server,
            this.ui,
            this.pwd
            );
        return connectionstr;
    }
}
