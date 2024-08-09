using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    [Serializable]
    public enum Operation
    {

        LoginUser,
        CreateTeam,
        CreatePlayer,
        FillComboBox,
        GetAllTeams,
        GetAllPlayers,
        GetSelectedTeam,
        GetSelectedPlayer,
        GetAllGames,
        SearchTeam,
        SearchPlayer,
        SearchGame,
        UpdateTeam,
        UpdatePlayer,
        GetHomeAwayPlayers,
        CreateGame,
        CreatePlayerStatistics,
        GetStatsForSelectedGame,
        UpdateGame,
        UpdateGameWithDelete,
        GetSelectedGame,
        DeleteStats
        
    }
}
