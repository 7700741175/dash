using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Dash_API.Utils
{
    public class Repository
    {

        private string _DataSource = WebConfigurationManager.AppSettings["DataSource"];
        private string _UserID = WebConfigurationManager.AppSettings["UserID"];
        private string _Password = WebConfigurationManager.AppSettings["Password"];
        private string _InitialCatalog = WebConfigurationManager.AppSettings["DataBase"];

        private SqlConnectionStringBuilder builder;

        public Repository()
        {
            builder = new SqlConnectionStringBuilder();
            builder.DataSource = Criptex.Decrypt(_DataSource);
            builder.UserID = Criptex.Decrypt(_UserID);
            builder.Password = Criptex.Decrypt(_Password);
            builder.InitialCatalog = Criptex.Decrypt(_InitialCatalog);
        }

        public SqlConnection getInstance()
        {
            return new SqlConnection(builder.ConnectionString);
        }
    }
}