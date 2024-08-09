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
using System.Xml.Linq;

namespace Entity
{
	[Serializable]
	public class Player:BaseEntity
    {
        public int PlayerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public Team Team {  get; set; }
        
        public override string TableName => "Players";
        
        public override string[] PrimaryKey => new string[] { "PlayerId" };
        
        public override string[] ForeignKeys => new string[] { "TeamId" };
        
        public override string InsertValues => $"@FirstName, @LastName," +
            $"@Position, @TeamId";
        
        public override string UpdateValues => "FirstName=@FirstName, " +
            "LastName=@LastName, Position=@Position, TeamId=@TeamId";
        
        public override string WhereQueryId => "";
        
        public override string Join => "JOIN dbo.Teams t ON t.TeamId = p.TeamId";

		public override List<SqlParameter> Parameters => new List<SqlParameter>
        {
           new SqlParameter("FirstName", FirstName),
           new SqlParameter("LastName", LastName),
           new SqlParameter("Position", Position),
           new SqlParameter("TeamId", Team.TeamId)

        };

        public override string Alijas => " p";

        public override string SelectedCollumns => "p.PlayerId, p.FirstName, p.LastName, p.Position, t.TeamId, t.Name";

        public override List<IEntity> GetListOfObjects(SqlDataReader reader)
		{
            try
            {
                List<IEntity> playerList = new List<IEntity>();
                while (reader.Read())
                {
                    Player player = new Player()
                    {
                        PlayerId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Position = reader.GetString(3),
                        Team = new Team()
                        {
                            TeamId = reader.GetInt32(4),
                            Name= reader.GetString(5),
                        }
                    };
                    playerList.Add(player);
                }
                return playerList;
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
            return this.FirstName + LastName; 
        }

    }
}
