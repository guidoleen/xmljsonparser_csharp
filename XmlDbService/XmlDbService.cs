using System;

namespace XmlDbService
{

    // TODO > uitbreiden met de parameters voor de connector
    public class XmlDbService
    {
        public XmlDbService(String strText, String strType)
        {
            IDBConnector dbc = new MySqlConnector("localhost",
                "root",
                "VisualStudio123.",
                "xmlservice"
                );

            LoginInfoMySqlDAO loginDAO = new LoginInfoMySqlDAO(dbc);
            loginDAO.save(new LoginInfo(strText, strType, new DateTime()));
        }
    }
}