using Common;
using Common.Communication;
using Common.Extensions;
using Entity;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EuroleagueApp
{
    public class CommunicationHelper
    {
        private Socket socket;
        private Sender sender;
        private Receiver receiver;
        public User User;

        private static CommunicationHelper instance;

        public static CommunicationHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommunicationHelper();
                }
                return instance;        
            }
        }
        private CommunicationHelper()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public bool clientConnected = false;

        public void Connect()
        {
            try
            {
                if (clientConnected)
                    throw new Exception("Client is already connected to server");

                socket.Connect("127.0.0.1", 9999);

                sender = new Sender(socket);
                receiver = new Receiver(socket);

                clientConnected = true;
            }
            catch (Exception ex)
            {

                Console.WriteLine("SERVER HASN'T STARTED "+ex.Message);
            }
        }
        public User LoginUser(User user)
        {
            try
            {
                if (!clientConnected)
                    throw new Exception("Not connected to server");
                Request request = MakeRequest(user, Operation.LoginUser);
                sender.Send(request);

                Response response = (Response)receiver.Receive();
                user = response.GetDataFromResponse<User>();
                MessageBox.Show(response.Message);
                return user;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        private Request MakeRequest(object body, Operation operation)
        {
            return new Request(body, operation);
        }
        public Player InsertPlayer(Player playerFromForm)
        {
            try
            {
                if (!clientConnected)
                    throw new Exception("Not connected to server.");

                Request request = MakeRequest(playerFromForm, Operation.CreatePlayer);
                sender.Send(request);

                Response response = (Response)receiver.Receive();
                playerFromForm = response.GetDataFromResponse<Player>();

                MessageBox.Show(response.Message);

                return playerFromForm;

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return null;
            }
        }
        public Game InsertGame(Game gameFromForm)
        {
            try
            {
                if (!clientConnected)
                    throw new Exception("Not connected to server.");

                Request request = MakeRequest(gameFromForm, Operation.CreateGame);
                sender.Send(request);

                Response response = (Response)receiver.Receive();
                gameFromForm = response.GetDataFromResponse<Game>();

                MessageBox.Show(response.Message);

                return gameFromForm;

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return null;
            }
        }
        public void InsertPlayerStatistics(PlayerStatistics playerStatistics)
        {
            try
            {
                if (!clientConnected)
                    throw new Exception("Not connected to server.");

                Request request = MakeRequest(playerStatistics, Operation.CreatePlayerStatistics);
                sender.Send(request);

                Response response = (Response)receiver.Receive();
                playerStatistics = response.GetDataFromResponse<PlayerStatistics>();

                MessageBox.Show(response.Message);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public Team InsertTeam(Team teamFromForm)
		{
			try
			{
				if (!clientConnected)
					throw new Exception("Not connected to server.");

				Request request = MakeRequest(teamFromForm, Operation.CreateTeam);
				sender.Send(request);

				Response response = (Response)receiver.Receive();
				teamFromForm = response.GetDataFromResponse<Team>();

				MessageBox.Show(response.Message);

				return teamFromForm;

			}
			catch (Exception ex)
			{

				Debug.WriteLine(ex.Message);
				return null;
			}
		}
        public Player GetSelectedPlayer(Player selectedPlayerFromDgv)
        {
            try
            {
                if (!clientConnected)
                    throw new Exception("Not connected to server.");

                Request request = MakeRequest(selectedPlayerFromDgv,
                    Operation.GetSelectedPlayer);
                sender.Send(request);

                Response response = (Response)receiver.Receive();
                selectedPlayerFromDgv = response.GetDataFromResponse<Player>();

                MessageBox.Show(response.Message);

                return selectedPlayerFromDgv;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return null;
            }
        }
        public Game GetSelectedGame(Game selectedGameFromDgv)
        {
            try
            {
                if (!clientConnected)
                    throw new Exception("Not connected to server.");

                Request request = MakeRequest(selectedGameFromDgv,
                    Operation.GetSelectedGame);
                sender.Send(request);

                Response response = (Response)receiver.Receive();
                selectedGameFromDgv = response.GetDataFromResponse<Game>();

                MessageBox.Show(response.Message);

                return selectedGameFromDgv;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return null;
            }
        }
        public Team GetSelectedTeam(Team selectedTeamFromDgv)
        {
            try
            {
                if (!clientConnected)
                    throw new Exception("Not connected to server.");

                Request request = MakeRequest(selectedTeamFromDgv,
                    Operation.GetSelectedTeam);
                sender.Send(request);

                Response response = (Response)receiver.Receive();
                selectedTeamFromDgv = response.GetDataFromResponse<Team>();

                MessageBox.Show(response.Message);

                return selectedTeamFromDgv;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return null;
            }
        }
		public List<City> GetAllCities()
		{
			if (!clientConnected)
				throw new Exception("Not connected to server.");

			Request request = MakeRequest("", Operation.FillComboBox);
			sender.Send(request);

			Response response = (Response)receiver.Receive();
			List<City> cities = response.GetDataFromResponse<List<City>>();

			return cities;
		}

		public List<Team> GetAllTeams()
		{
			if (!clientConnected)
				throw new Exception("Not connected to server.");

            Request request = MakeRequest("", Operation.GetAllTeams);
            sender.Send(request);

            Response response = (Response)receiver.Receive();
            List<Team> teams=response.GetDataFromResponse<List<Team>>();
            return teams;
		}
        public List<Player> GetFilteredPlayers(string filter)
        {
            if (!clientConnected)
                throw new Exception("Not connected to server.");

            Request request = MakeRequest(filter, Operation.SearchPlayer);
            sender.Send(request);

            Response response = (Response)receiver.Receive();
            List<Player> FilterdPlayers = response.GetDataFromResponse<List<Player>>();
            return FilterdPlayers;
        }
        public List<Team> GetFilteredTeams(string filter)
		{
			if (!clientConnected)
				throw new Exception("Not connected to server.");

			Request request = MakeRequest(filter, Operation.SearchTeam);
			sender.Send(request);

			Response response = (Response)receiver.Receive();
			List<Team> FilterdTeams = response.GetDataFromResponse<List<Team>>();
            return FilterdTeams;
		}
        public Player UpdatePlayer(Player playerToUpdate)
        {
            try
            {
                if (!clientConnected)
                    throw new Exception("Not connected to server.");

                Request request = MakeRequest(playerToUpdate, Operation.UpdatePlayer);
                sender.Send(request);

                Response response = (Response)receiver.Receive();
                playerToUpdate = response.GetDataFromResponse<Player>();

                MessageBox.Show(response.Message);

                return playerToUpdate;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
        public Game UpdateGameWithDelete(Game gameToUpdate)
        {
            try
            {
                if (!clientConnected)
                    throw new Exception("Not connected to server.");

                Request request = MakeRequest(gameToUpdate, Operation.UpdateGameWithDelete);
                sender.Send(request);

                Response response = (Response)receiver.Receive();
                gameToUpdate = response.GetDataFromResponse<Game>();

                MessageBox.Show(response.Message);

                return gameToUpdate;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
        public Game UpdateGame(Game gameToUpdate)
        {
            try
            {
                if (!clientConnected)
                    throw new Exception("Not connected to server.");

                Request request = MakeRequest(gameToUpdate, Operation.UpdateGame);
                sender.Send(request);

                Response response = (Response)receiver.Receive();
                gameToUpdate = response.GetDataFromResponse<Game>();

                MessageBox.Show(response.Message);

                return gameToUpdate;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        
        public Team UpdateTeam(Team teamToUpdate)
        {
            try
            {
                if (!clientConnected)
                    throw new Exception("Not connected to server.");

                Request request = MakeRequest(teamToUpdate, Operation.UpdateTeam);
                sender.Send(request);

                Response response = (Response)receiver.Receive();
                teamToUpdate = response.GetDataFromResponse<Team>();

                MessageBox.Show(response.Message);

                return teamToUpdate;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public List<Player> GetAllPlayers()
        {
            if (!clientConnected)
                throw new Exception("Not connected to server.");

            Request request = MakeRequest("", Operation.GetAllPlayers);
            sender.Send(request);

            Response response = (Response)receiver.Receive();
            List<Player> players = response.GetDataFromResponse<List<Player>>();
            return players;
        }

        public List<Player> GetHomeAwayPlayers(List<Team> teams)
        {
            if (!clientConnected)
                throw new Exception("Not connected to server.");

            Request request = MakeRequest(teams, Operation.GetHomeAwayPlayers);
            sender.Send(request);

            Response response = (Response)receiver.Receive();
            List<Player> players = response.GetDataFromResponse<List<Player>>();
            return players;
        }

        public List<Game> GetAllGames()
        {
            if (!clientConnected)
                throw new Exception("Not connected to server.");

            Request request = MakeRequest("", Operation.GetAllGames);
            sender.Send(request);

            Response response = (Response)receiver.Receive();
            List<Game> games = response.GetDataFromResponse<List<Game>>();
            return games;
        }

        public List<Game> GetFilteredGames(string filter)
        {
            if (!clientConnected)
                throw new Exception("Not connected to server.");

            Request request = MakeRequest(filter, Operation.SearchGame);
            sender.Send(request);

            Response response = (Response)receiver.Receive();
            List<Game> FilterdGames = response.GetDataFromResponse<List<Game>>();
            return FilterdGames;
        }

        public List<PlayerStatistics> GetStatsForThatGame(Game game)
        {
            if (!clientConnected)
                throw new Exception("Not connected to server.");

            Request request = MakeRequest(game,Operation.GetStatsForSelectedGame);
            sender.Send(request);

            Response response = (Response)receiver.Receive();  
            List<PlayerStatistics> FilteredStats = response.
                GetDataFromResponse<List<PlayerStatistics>>();
            return FilteredStats;
        }

        public void DeletePlayerStats(PlayerStatistics playerStats)
        {
            if (!clientConnected)
                throw new Exception("Not connected to server.");

            Request request = MakeRequest(playerStats, Operation.DeleteStats);
            sender.Send(request);

            Response response = (Response)receiver.Receive();
            playerStats = response.GetDataFromResponse<PlayerStatistics>();
            MessageBox.Show(response.Message);
        }

        

        
    }
}
