using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.BaseSO;

namespace SystemOperations.SystemOperations
{
    public class GetSelectedGameSystemOperation : BaseSystemOperations
    {
        public Game selectedGame;
        protected override void ExecuteConcreteOperation()
        {
            List<Game> game = repository.Select(selectedGame,
               $" GameId = '{selectedGame.GameId}'").Cast<Game>().ToList();
            if (game == null)
            {
                throw new Exception("Game doesn't exist in database :( ");
            }
            else
            {
                selectedGame = game[0];
            }
        }
    }
}
