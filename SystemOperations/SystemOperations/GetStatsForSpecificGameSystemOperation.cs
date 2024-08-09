using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.BaseSO;

namespace SystemOperations.SystemOperations
{
    public class GetStatsForSpecificGameSystemOperation:BaseSystemOperations
    {
        public List<PlayerStatistics> PlayerStatsList { get; set; }
        public Game Game;
        private PlayerStatistics PlayerStatistics;
        protected override void ExecuteConcreteOperation()
        {
            PlayerStatistics = new PlayerStatistics();
            PlayerStatsList = repository.Select(PlayerStatistics,
                $"ps.GameId = '{Game.GameId}'").Cast<PlayerStatistics>().ToList();

        }
    }
}
