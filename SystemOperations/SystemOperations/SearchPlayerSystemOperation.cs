using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.BaseSO;

namespace SystemOperations.SystemOperations
{
    public class SearchPlayerSystemOperation : BaseSystemOperations
    {
        public List<Player> filteredPlayers { get; set; }
        public string filter;
        private Player player;
        protected override void ExecuteConcreteOperation()
        {
            player = new Player();
            filteredPlayers = repository.Select(player, $"p.LastName like '%{filter}%'")
                .Cast<Player>().ToList();
        }
    }
}
