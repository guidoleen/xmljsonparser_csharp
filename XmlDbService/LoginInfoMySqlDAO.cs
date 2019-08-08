using System;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace XmlDbService
{
    // TODO > DateTime naar een apparte util class
    public class LoginInfoMySqlDAO
    {
        private MySql.Data.MySqlClient.MySqlConnection conn;
        private IDBConnector connector;

        public LoginInfoMySqlDAO(IDBConnector connector)
        {
            this.connector = connector;
        }

        // Set up the connection...
        private void SetUpMySqlConnector()
        {
            this.conn = (MySql.Data.MySqlClient.MySqlConnection) connector.GetDBConnector();
            this.conn.Open();
        }

        // Save als een insert into.....
        public void save(LoginInfo loginInfo)
        {
            SetUpMySqlConnector();

            // string connString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            MySqlConnection conn = this.conn;

            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "INSERT INTO logininfo(lii_date, lii_text, lii_type) VALUES(@lii_date, @lii_text, @lii_type)";

                comm.Parameters.AddWithValue("@lii_date", ToDateTimeNow());
                comm.Parameters.AddWithValue("@lii_text", loginInfo.GetText());
                comm.Parameters.AddWithValue("@lii_type", loginInfo.GetType());

            comm.ExecuteNonQuery();

            this.conn.Close();
        }

        private String ToDateTimeNow()
        {
            DateTime dateTimeVariable = DateTime.Now;
            return dateTimeVariable.ToString("yyyy-MM-dd H:mm:ss");
        }
    }
}
