using Entity.Models.BaseEntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Entity
{
    [Serializable]
    public class Game : BaseEntity
    {
        public int GameId { get; set; }
        public DateTime GameTime { get; set; }
        public Team Team1 { get; set; }

        public Team Team2 { get; set; }
        public int HomeTeamPoints { get; set; }
        public int AwayTeamPoints { get; set; }
        public List<PlayerStatistics> PlayersStatsList { get; set; } = new List<PlayerStatistics>();


        public override string TableName => "Games";
        
        public override string[] PrimaryKey => new string[] { "GameId" };
        
        public override string[] ForeignKeys => new string[] { "TeamId1", "TeamId2" };
        
        public override string InsertValues => "@GameTime, " +
            "@HomeTeamPoints, @AwayTeamPoints, @TeamId1, @TeamId2";
        
        public override string UpdateValues => "GameTime=@GameTime," +
            "HomeTeamPoints=@HomeTeamPoints, " +
            "AwayTeamPoints=@AwayTeamPoints," +
            " TeamId1=@TeamId1, " +
            "TeamId2=@TeamId2";
        
        public override string WhereQueryId => "GameId=@GameId";

        public override string Join => "JOIN dbo.Teams t ON g.TeamId1 = t.TeamId" +
                                      " JOIN dbo.Teams tt ON g.TeamId2 = tt.TeamId";
 
        public override List<SqlParameter> Parameters => new List<SqlParameter>
        {
            new SqlParameter("@GameTime", GameTime),
            new SqlParameter("@HomeTeamPoints", HomeTeamPoints),
            new SqlParameter("@AwayTeamPoints", AwayTeamPoints),
            new SqlParameter("@TeamId1", Team1.TeamId),
            new SqlParameter("@TeamId2", Team2.TeamId)
        };

        public override string Alijas => " g";

        public override string SelectedCollumns => "g.GameId, g.GameTime, g.HomeTeamPoints," +
            " g.AwayTeamPoints, t.TeamId, tt.TeamId, t.Name ,tt.Name";

        public override string GroupBy => "";

        public override List<IEntity> GetListOfObjects(SqlDataReader reader)
        {
            try
            {
                List<IEntity> gameList = new List<IEntity>();
                while (reader.Read())
                {
                    Game game = new Game()
                    {
                        GameId = reader.GetInt32(0),
                        GameTime = reader.GetDateTime(1),
                        HomeTeamPoints = reader.GetInt32(2),
                        AwayTeamPoints = reader.GetInt32(3),
                        Team1 = new Team()
                        {
                            TeamId = reader.GetInt32(4),
                            Name = reader.GetString(6)
                        },
                        Team2 = new Team()
                        {
                            TeamId = reader.GetInt32(5),
                            Name = reader.GetString(7)
                        }
                        
                        
                    };
                    gameList.Add(game);
                }
                return gameList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                reader.Close();
                throw;
            }
        }
    }
}
