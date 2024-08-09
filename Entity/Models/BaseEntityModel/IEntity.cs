using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.BaseEntityModel
{
    public interface IEntity
    {
        string TableName { get; }
		string[] PrimaryKey { get; }
		string[] ForeignKeys { get; }
        string InsertValues { get; }
        string UpdateValues { get; }
        string WhereQueryId { get; }
        string Join { get; }

        string Alijas {  get; }

        string SelectedCollumns {  get; }
        List<SqlParameter> Parameters { get; }
        List<IEntity> GetListOfObjects(SqlDataReader reader);
    }
}
