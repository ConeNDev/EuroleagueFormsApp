    using Entity;
using Repository.DbConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.BaseSO;

namespace SystemOperations.SystemOperations
{
    public class CreateGameSystemOperation : BaseSystemOperations
    {
        public Game Game { get; set; } 
        protected override void ExecuteConcreteOperation()
        {
            if (Game == null)
            {
                throw new Exception("Game is null");
            }
            List<Game> gamesFromDb = repository.Select(Game, $" t.Name = '{Game.Team1.Name}' and" +
                $"  tt.Name = '{Game.Team2.Name}' and g.GameTime = '{Game.GameTime}'").Cast<Game>().ToList();

            if (gamesFromDb.Count != 0)
            {
                throw new Exception("System can't create that game," +
                    " because it already exists");
            }
            else
            {
                repository.Insert(Game);
                foreach (PlayerStatistics ps in Game.PlayersStatsList)
                {
                    ps.GameId = Game.GameId;
                    repository.Insert(ps);
                }
            }

            

        }
    }
}
