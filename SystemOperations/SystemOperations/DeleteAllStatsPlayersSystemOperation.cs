﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.BaseSO;

namespace SystemOperations.SystemOperations
{
    public class DeleteAllStatsPlayersSystemOperation : BaseSystemOperations
    {
        public Game game;
        PlayerStatistics playerStats;
        protected override void ExecuteConcreteOperation()
        {
            playerStats = new PlayerStatistics();
            repository.Delete(playerStats, $"GameId = '{game.GameId}'");
        }
    }
}
