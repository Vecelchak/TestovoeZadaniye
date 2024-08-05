using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovoeZadaniye
{
    class db
    {

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-HU81JFN\SQLEXPRESS;Initial Catalog=Data;Integrated Security=True;Encrypt=True;TrustServerCertificate=true");

        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }

        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }

    }
}
