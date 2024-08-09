using Common.Communication;
using Entity;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.SystemOperations;

namespace ServerEuroleague
{
    public class Controller
    {
        private static Controller instance;
        public static Controller Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Controller();
                }
                return instance;
            }
        }
        private Controller() { }

        public Response HandleSingleRequest(Request request)
        {
            Response response = new Response();
            try
            {
                switch (request.Operation)
                {
                    case Operation.LoginUser:
                        return response = LoginUser((User)request.Body);
                    case Operation.CreateGame:
                        return response = CreateGame((Game)request.Body);
                    case Operation.CreatePlayer:
                        return response = CreatePlayer((Player)request.Body);
                    case Operation.CreateTeam:
                        return response = CreateTeam((Team)request.Body);
                    case Operation.FillComboBox:
                        return response = FillComboBox();
                    case Operation.GetAllTeams:
                        return response = GetAllTeams();
                    case Operation.SearchTeam:
                        return response = SearchTeam((string)request.Body);
                    case Operation.GetSelectedTeam:
                        return response = GetSelectedTeam((Team)request.Body);
                    case Operation.UpdatePlayer:
                        return response = UpadtePlayer((Player)request.Body);
                    case Operation.UpdateTeam:
                        return response = UpdateTeam((Team)request.Body);
                    case Operation.UpdateGame:
                        return response = UpdateGame((Game)request.Body);
                    case Operation.UpdateGameWithDelete:
                        return response = UpdateGameWithDelete((Game)request.Body);
                    case Operation.GetAllPlayers:
                        return response = GetAllPlayers();
                    case Operation.GetHomeAwayPlayers:
                        return response = GetHomeAwayPlayers((List<Team>)request.Body);
                    case Operation.GetSelectedPlayer:
                        return response=GetSelectedPlayer((Player)request.Body);
                    case Operation.SearchPlayer:
                        return response = SearchPlayer((string)request.Body);
                    case Operation.GetAllGames:
                        return response = GetAllGames();
                    case Operation.SearchGame:
                        return response = SearchGame((string)request.Body);
                    case Operation.GetStatsForSelectedGame:
                        return response = GetStatsForSelectedGame((Game)request.Body);
                    case Operation.GetSelectedGame:
                        return response = GetSelectedGame((Game)request.Body);
                    case Operation.DeleteStats:
                        return response =DeleteStats((PlayerStatistics)request.Body);
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

      

        private Response DeleteStats(PlayerStatistics stats)
        {
            DeleteStatsSystemOperation deleteStatsSO = new DeleteStatsSystemOperation();
            deleteStatsSO.playerStats = stats;
            deleteStatsSO.Execute();
            return new Response(deleteStatsSO.playerStats, Operation.DeleteStats,
                "Successfully deleted stats");
        }

        private Response GetStatsForSelectedGame(Game game)
        {
            GetStatsForSpecificGameSystemOperation getStatsSo = 
                new GetStatsForSpecificGameSystemOperation();
            getStatsSo.Game=game;
            getStatsSo.Execute();
            return new Response(getStatsSo.PlayerStatsList, Operation.SearchGame,
                "Successfully withdrawn stats");
        }

        private Response SearchGame(string filter)
        {
            SearchGameSystemOperation searchGameSo = new SearchGameSystemOperation();
            searchGameSo.filter = filter;
            searchGameSo.Execute();
            return new Response(searchGameSo.filteredGames, Operation.SearchGame,
                "Games are filtered");
        }
        private Response CreateGame(Game game)
        {
            CreateGameSystemOperation createGameSO = new CreateGameSystemOperation();
            createGameSO.Game = game;
            createGameSO.Execute();
            return new Response(createGameSO.Game, Operation.CreateGame, "Successfully created" +
                " game!");
        }

        private Response UpadtePlayer(Player player)
        {
            UpdatePlayerSystemOperation updatePlayerSO = new UpdatePlayerSystemOperation();
            updatePlayerSO.Player = player;
            updatePlayerSO.Execute();
            return new Response(updatePlayerSO.Player, Operation.UpdatePlayer, "Successfully updated" +
                " player!");
        }

        private Response UpdateTeam(Team team)
        {
            UpdateTeamSystemOperation updateTeamSO = new UpdateTeamSystemOperation();
            updateTeamSO.Team = team;
            updateTeamSO.Execute();
            return new Response(updateTeamSO.Team, Operation.UpdateTeam, "Successfully updated " +
                "team");
        }
        
        private Response UpdateGame(Game game)
        {
            UpdateGameSystemOperation updateGameSO = new UpdateGameSystemOperation();
            updateGameSO.Game = game;
            updateGameSO.Execute();
            return new Response(updateGameSO.Game, Operation.UpdateGame, "Successfully updated" +
                " game");
        }
        private Response UpdateGameWithDelete(Game game)
        {
            UpdateGameWithDeleteSystemOperation updateGameSO = new UpdateGameWithDeleteSystemOperation();
            updateGameSO.Game = game;
            updateGameSO.Execute();
            return new Response(updateGameSO.Game, Operation.UpdateGameWithDelete, "Successfully updated" +
                " game");
        }
        private Response CreatePlayer(Player player)
        {
            CreatePlayerSystemOperation createPlayerSO = new CreatePlayerSystemOperation();
            createPlayerSO.Player = player;
            createPlayerSO.Execute();
            return new Response(createPlayerSO.Player, Operation.CreatePlayer,
                "Successfully created player");
        }
        private Response CreateTeam(Team team)
        {
            CreateTeamSystemOperation createTeamSo = new CreateTeamSystemOperation();
            createTeamSo.Team = team;
            createTeamSo.Execute();
            return new Response(createTeamSo.Team, Operation.CreateTeam,
                "Successfully created team");
        }
        private Response SearchPlayer(string filter)
        {
            SearchPlayerSystemOperation searchTeamSo = new SearchPlayerSystemOperation();
            searchTeamSo.filter = filter;
            searchTeamSo.Execute();
            return new Response(searchTeamSo.filteredPlayers, Operation.SearchTeam,
                "Teams are filtered");
        }
        private Response SearchTeam(string filter)
		{
            SearchTeamSystemOperation searchTeamSo=new SearchTeamSystemOperation();
            searchTeamSo.filter = filter;
            searchTeamSo.Execute();
            return new Response(searchTeamSo.filteredTeams,Operation.SearchTeam,
                "Teams are filtered");
		}
        private Response GetSelectedPlayer(Player selectedPlayer)
        {
            GetSelectedPlayerSystemOperation getSelectedPlayerSO =
                new GetSelectedPlayerSystemOperation();
            getSelectedPlayerSO.selectedPlayer = selectedPlayer;
            getSelectedPlayerSO.Execute();
            return new Response(getSelectedPlayerSO.selectedPlayer, Operation.GetSelectedPlayer,
                "Successfully selected player, now you can edit him");
        }
        private Response GetSelectedGame(Game selectedGame)
        {
            GetSelectedGameSystemOperation getSelectedGameSO =
               new GetSelectedGameSystemOperation();
            getSelectedGameSO.selectedGame = selectedGame;
            getSelectedGameSO.Execute();
            return new Response(getSelectedGameSO.selectedGame, Operation.GetSelectedGame,
                "Successfully selected game, now you can edit match");
        }
        private Response GetSelectedTeam(Team selectedTeam)
        {
            GetSelectedTeamSystemOperation getSelectedTeamSO =
                new GetSelectedTeamSystemOperation();
            getSelectedTeamSO.selectedTeam = selectedTeam;
            getSelectedTeamSO.Execute();
            return new Response(getSelectedTeamSO.selectedTeam, Operation.GetSelectedTeam,
                "Successfully selected team, now you can edit him");
        }
        private Response GetAllTeams()
		{
			GetAllTeamSystemOperation getAllSo=new GetAllTeamSystemOperation();
            getAllSo.Execute();
            return new Response(getAllSo.TeamList,Operation.GetAllTeams,
				"Successfully withdrawn teams from the base");
		}
        private Response GetAllGames()
        {
            GetAllGamesSystemOperation getAllSo=new GetAllGamesSystemOperation();
            getAllSo.Execute();
            return new Response(getAllSo.GameList, Operation.GetAllGames,
                "Successfully withdrawn games from the base");
        }
        private Response GetHomeAwayPlayers(List<Team> teams)
        {
            GetHomeAwayPlayersSystemOperation getHomeAwaySO = new GetHomeAwayPlayersSystemOperation();
            getHomeAwaySO.homeTeam = teams[0];
            getHomeAwaySO.awayTeam = teams[1];
            getHomeAwaySO.Execute();
            return new Response(getHomeAwaySO.PlayerList, Operation.GetAllPlayers,
                "Successfully withdrawn players from the base");

        }
        private Response GetAllPlayers()
        {
            GetAllPlayerSystemOperation getAllSo = new GetAllPlayerSystemOperation();
            getAllSo.Execute();
            return new Response(getAllSo.PlayerList, Operation.GetAllPlayers,
                "Successfully withdrawn players from the base");
        }
        private Response FillComboBox()
		{
            FillCmbCitiesSystemOperation fillCmbBoxSo = new FillCmbCitiesSystemOperation();
            fillCmbBoxSo.Execute();
            return new Response(fillCmbBoxSo.cities, Operation.FillComboBox,
                "ComboBox successfully filled");
		}

		

        public Response LoginUser(User user)
        {
            LoginUserSystemOperation loginSo= new LoginUserSystemOperation();
            loginSo.User = user;
            loginSo.Execute();
            return new Response(data: loginSo.User, operation: Operation.LoginUser,
                message: "Successful login");
        }
    }
}
