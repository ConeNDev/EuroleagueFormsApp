using Entity.Models.BaseEntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
	[Serializable]
	public class City:BaseEntity
    {
        [Browsable(false)]
        public int CityId { get; set; }
        public string PostCode { get; set; }
        public string Name { get; set; }

        public List<Team> Teams { get; set; } = new List<Team>();
        public override string TableName => "Cities";

        public override string[] PrimaryKey => new string[] { "CityId" };

        public override string[] ForeignKeys => new string[] { "CityId" };

        public override string InsertValues => "";

        public override string UpdateValues => "";

        public override string WhereQueryId => "";

        public override string Join => "JOIN dbo.Teams t ON t.CityId = c.CityId";

        public override List<SqlParameter> Parameters => new List<SqlParameter>
        {
            
        };

        public override string Alijas => " c";

        public override string GroupBy => "";
        public override string SelectedCollumns => "c.CityId, c.PostCode, c.Name";

        public override List<IEntity> GetListOfObjects(SqlDataReader reader)
        {
            try
            {
                List<IEntity> cityList = new List<IEntity>();

                while (reader.Read())
                {
                    City city = new City()
                    {
                        CityId = reader.GetInt32(0),
                        PostCode = reader.GetString(1),
                        Name = reader.GetString(2)
                    };
                    cityList.Add(city);
                }

                return cityList;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                reader.Close();
                throw ex;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
