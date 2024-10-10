using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.BaseEntityModel
{
    [Serializable]
    public abstract class BaseEntity : IEntity
    {
        [Browsable(false)]
        public abstract string TableName { get; }
        [Browsable(false)]
        public abstract string[] PrimaryKey { get; }
        [Browsable(false)]
        public abstract string[] ForeignKeys { get; }
        [Browsable(false)]
        public abstract string InsertValues { get; }
        [Browsable(false)]
        public abstract string UpdateValues { get; }
        [Browsable(false)]
        public abstract string WhereQueryId { get; }
        [Browsable(false)]
        public abstract string Join { get; }
        public abstract List<SqlParameter> Parameters { get; }
        [Browsable(false)]
        public abstract string Alijas { get; }
        [Browsable(false)]
        public abstract string SelectedCollumns { get;}
        [Browsable(false)]
        public abstract string GroupBy { get; }

        public abstract List<IEntity> GetListOfObjects(SqlDataReader reader);
    }
}
