using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.BaseSO;

namespace SystemOperations.SystemOperations
{
    
    public class DeleteStatsSystemOperation : BaseSystemOperations
    {
        public PlayerStatistics playerStats;
        protected override void ExecuteConcreteOperation()
        {
            repository.Delete(playerStats, $"PlayerId = '{playerStats.PlayerId}' and " +
                $"GameId = '{playerStats.GameId}'");
        }
    }
}
