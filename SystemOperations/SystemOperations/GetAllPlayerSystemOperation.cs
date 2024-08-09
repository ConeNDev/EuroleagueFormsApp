using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.BaseSO;

namespace SystemOperations.SystemOperations
{
    public class GetAllPlayerSystemOperation : BaseSystemOperations
    {
        public List<Player> PlayerList { get; set; }
        private Player Player;
        protected override void ExecuteConcreteOperation()
        {
            Player = new Player();
            PlayerList = repository.Select(Player).Cast<Player>().ToList();
        }
    }
}
