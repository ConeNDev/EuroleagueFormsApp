using Entity.Models.BaseEntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Entity
{
    [Serializable]
    public class PlayerStatistics : BaseEntity
    {
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public Player Player { get; set; }
        public int PlayersPoints { get; set; }
        
        [Browsable(false)]
        public Game Game { get; set; }
        
        public override string TableName => "PlayersStatistics";
        
        public override string[] PrimaryKey => new string[] { "PlayerId", "GameId" };
        
        public override string[] ForeignKeys => new string[] { "PlayerId", "GameId" };
        
        public override string InsertValues => $"@PlayerId, @GameId, @PlayersPoints";
        
        public override string UpdateValues => "PlayerId=@PlayerId, GameId=@GameId," +
            " PlayersPoints=@PlayersPoints";
        
        public override string WhereQueryId => "";
        
        public override string Join => "JOIN dbo.Players p ON ps.PlayerId = p.PlayerId";

        public override List<SqlParameter> Parameters => new List<SqlParameter>
        {
            new SqlParameter("PlayerId", PlayerId),
            new SqlParameter("GameId", GameId),
            new SqlParameter("PlayersPoints", PlayersPoints)
        };

        public override string Alijas => " ps";

        public override string SelectedCollumns => "ps.PlayerId, ps.GameId, p.LastName, ps.PlayersPoints";

        public override List<IEntity> GetListOfObjects(SqlDataReader reader)
        {
            try
            {
                List<IEntity> gameList = new List<IEntity>();
                while (reader.Read())
                {
                    PlayerStatistics playerStatistics = new PlayerStatistics()
                    {
                        PlayerId = reader.GetInt32(0),
                        GameId = reader.GetInt32(1),
                        Player = new Player()
                        {
                            LastName = reader.GetString(2),
                        },
                        PlayersPoints = reader.GetInt32(3),
                    };  
                    gameList.Add(playerStatistics);
                }
                return gameList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                reader.Close();
                throw ex;
            }
        }
    }
}