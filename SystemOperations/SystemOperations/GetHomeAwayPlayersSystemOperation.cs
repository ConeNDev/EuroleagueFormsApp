using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.BaseSO;

namespace SystemOperations.SystemOperations
{
    public class GetHomeAwayPlayersSystemOperation : BaseSystemOperations
    {
        public List<Player> PlayerList { get; set; }
        public Team homeTeam;
        public Team awayTeam;
        private Player Player;
        protected override void ExecuteConcreteOperation()
        {
            Player = new Player();
            PlayerList = repository.Select(Player,$"p.TeamId = '{homeTeam.TeamId}' or " +
                $"p.TeamId = '{awayTeam.TeamId}'").Cast<Player>().ToList();
        }
    }
}
