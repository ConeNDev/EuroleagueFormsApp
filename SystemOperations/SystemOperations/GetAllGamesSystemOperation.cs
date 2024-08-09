using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.BaseSO;

namespace SystemOperations.SystemOperations
{
    public class GetAllGamesSystemOperation : BaseSystemOperations
    {
        public List<Game> GameList { get; set; }
        private Game Game;  
        protected override void ExecuteConcreteOperation()
        {
            Game = new Game();
            GameList = repository.Select(Game).Cast<Game>().ToList();
        }
    }
}
