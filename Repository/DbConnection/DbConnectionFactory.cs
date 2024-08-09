using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DbConnection
{
    public class DbConnectionFactory
    {
        private DbConnection connection = new DbConnection();
        private static DbConnectionFactory instance;
        public static DbConnectionFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DbConnectionFactory();
                }
                return instance;
            }
        }
        private DbConnectionFactory() { }
        public DbConnection getConnection()
        {
            if (!connection.isConnectionReady())
            {
                connection.OpenConnection();
            }
            return connection;
        }
    }
}
