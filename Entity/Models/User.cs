using Entity.Models.BaseEntityModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    [Serializable]
    public class User:BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public override string TableName => "Users";

        public override string[] PrimaryKey => new string[] {"Id"};

        public override string[] ForeignKeys => throw new NotImplementedException();

        public override string InsertValues => "";

        public override string UpdateValues { get; }

        public override string WhereQueryId => $"";

        public override List<SqlParameter> Parameters { get; }

        public override string Join => "";

        public override string Alijas => " u";

        public override string SelectedCollumns => "u.Id, u.FirstName, u.LastName, u.Username, u.Password";

        public override List<IEntity> GetListOfObjects(SqlDataReader reader)
        {
            List<IEntity> listUser = new List<IEntity>();
            while (reader.Read())
            {   
                User user= new User()
                {
                    Id = (int)reader[0],
                    FirstName = (string)reader[1],
                    LastName = (string)reader[2],
                    Username = reader[3].ToString(),
                    Password = reader[4].ToString()
                };
                listUser.Add(user);

            }

            return listUser;
        }
    }
}
