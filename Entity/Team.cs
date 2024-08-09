using Entity.Models;
using Entity.Models.BaseEntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
	[Serializable]
	public class Team : BaseEntity
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int EuroleagueChampionsTitles { get; set; }
        public string Coach { get; set; }
		public string Arena { get; set; }
		
		public City City { get; set; }

        [Browsable(false)]
        public List<Player> PlayersList { get; set; }
		
		public override string TableName => "Teams";
		
		public override string[] PrimaryKey => new string[] {"TeamId"};
		
		public override string[] ForeignKeys => new string[] { "CityId" };
		
		public override string InsertValues =>$"@Name, @EuroleagueChampionsTitles," +
			$"@Coach, @Arena, @CityId";
		
		public override string UpdateValues => "Name=@Name, EuroleagueChampionsTitles=" +
			"@EuroleagueChampionsTitles, Coach=@Coach, Arena=@Arena, CityId=@CityId";
		
		public override string WhereQueryId => "";
		
		public override string Join => "JOIN dbo.Cities c ON t.CityId = c.CityId";

		public override List<SqlParameter> Parameters => new List<SqlParameter>
		{
		   new SqlParameter("Name", Name),
		   new SqlParameter("EuroleagueChampionsTitles", EuroleagueChampionsTitles),
		   new SqlParameter("Coach", Coach),
		   new SqlParameter("Arena", Arena),
		   new SqlParameter("CityId", City.CityId)
		   
		};
        
        public override string Alijas => " t";
        
        public override string SelectedCollumns => "t.TeamId, t.Name, t.EuroleagueChampionsTitles," +
			" t.Coach, t.Arena, c.CityId, c.Name, c.PostCode";

        public override List<IEntity> GetListOfObjects(SqlDataReader reader)
        {
			try
			{
				List<IEntity> teamList = new List<IEntity>();
				while (reader.Read())
				{
					Team team = new Team()
					{
						TeamId= reader.GetInt32(0),
						Name = reader.GetString(1),
						EuroleagueChampionsTitles = reader.GetInt32(2),
						Coach = reader.GetString(3),
						Arena = reader.GetString(4),
						City=new City()
						{
							CityId= reader.GetInt32(5),
							Name=reader.GetString(6),
							PostCode=reader.GetString(7)
						}
					};
					teamList.Add(team);
				}
				return teamList;
			}
			catch (Exception ex)
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
