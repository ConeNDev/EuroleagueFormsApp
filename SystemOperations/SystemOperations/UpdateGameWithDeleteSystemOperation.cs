using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.BaseSO;

namespace SystemOperations.SystemOperations
{
    public class UpdateGameWithDeleteSystemOperation:BaseSystemOperations
    {
        public Game Game;
        private PlayerStatistics ps;
        protected override void ExecuteConcreteOperation()
        {
            ps = new PlayerStatistics();
            if (Game == null)
                throw new Exception("Game is null");
            repository.Update(Game, $"GameId = {Game.GameId}");
            
            repository.Delete(ps, $"GameId = '{Game.GameId}'");
            foreach (PlayerStatistics ps in Game.PlayersStatsList)
            {
                ps.GameId = Game.GameId;
                repository.Insert(ps);
            }

        }
    }
}
