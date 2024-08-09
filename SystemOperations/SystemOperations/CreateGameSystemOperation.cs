    using Entity;
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
            
            repository.Insert(Game);
            foreach (PlayerStatistics ps in Game.PlayersStatsList)
            {
                ps.GameId = Game.GameId;
                repository.Insert(ps);
            }
        }
    }
}
