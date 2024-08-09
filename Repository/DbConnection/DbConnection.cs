using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DbConnection
{
    public class DbConnection
    {
        private SqlConnection connection;
        private SqlTransaction transaction;

        public void OpenConnection()
        {
            if (!isConnectionReady())
            {
                connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EuroleagueDB;Integrated Security=True;");
                connection.Open();
            }
        }
        public SqlCommand CreateCommand(string sql = "")
        {
            if (transaction?.Connection != null)
            {
                transaction = connection.BeginTransaction();
            }
            return new SqlCommand(sql, connection, transaction);
        }
        public void Commit() => transaction?.Commit();

        public void Rollback() => transaction?.Rollback();
        public bool isConnectionReady() => connection != null && connection.State != ConnectionState.Closed;

        public void Close()
        {
            connection?.Close();
            transaction?.Dispose();
            transaction = null;
        }
    }
}
