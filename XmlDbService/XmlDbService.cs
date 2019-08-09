using System;

namespace XmlDbService
{

    public class XmlDbService
    {
        public XmlDbService(String strText, String strType, MysqlConnectionString msString)
        {
            IDBConnector dbc = new MySqlConnector(
                msString.getServer(),
                msString.getUi(),
                msString.getPwd(),
                msString.getDb()
                );

            LoginInfoMySqlDAO loginDAO = new LoginInfoMySqlDAO(dbc);
            loginDAO.save(new LoginInfo(strText, strType, new DateTime()));
        }
    }
}