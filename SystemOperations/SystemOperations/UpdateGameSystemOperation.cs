using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.BaseSO;

namespace SystemOperations.SystemOperations
{
    public class UpdateGameSystemOperation : BaseSystemOperations
    {
        public Game Game;
        protected override void ExecuteConcreteOperation()
        {
            if (Game == null)
                throw new Exception("Game is null");
            
            repository.Update(Game, $"GameId = {Game.GameId}");
            
            foreach (PlayerStatistics ps in Game.PlayersStatsList)
            {
                ps.GameId = Game.GameId;
                repository.Update(ps, $"GameId = {ps.GameId} and PlayerId = {ps.PlayerId}");
            }





        }
    }
}
