using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerDB
{
    public class Broker
    {
        SqlConnection conn;
        public Broker()
        {
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EuroleagueDB;Integrated Security=True;");
        }

        public void OpenConnection()
        {
            conn?.Open();
        }
        public void CloseConnection()
        {
            conn?.Close();
        }
    }
}
