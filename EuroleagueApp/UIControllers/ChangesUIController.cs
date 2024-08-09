using Entity;
using Entity.Models;
using EuroleagueApp.Forms;
using EuroleagueApp.UserControls.UCGames;
using EuroleagueApp.UserControls.UCPlayers;
using EuroleagueApp.UserControls.UCTeams;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EuroleagueApp.UIControllers
{
    public class ChangesUIController
    {
        private Team selectedTeam;
        private Player selectedPlayer;
        private Game selectedGame;
        public MenuForm menuForm;
        public UCTeamEditData teamEditData;
        public UCPlayerEditData playerEditData;
        public UCGameEditData gameEditData;
        private List<PlayerStatistics> statsListForDelete;
        DataTable dataTable = new DataTable();
        public UCPlayerEditData MakePlayerEditWindow(Player selectedPlayer)
        {
            this.selectedPlayer = selectedPlayer;
            playerEditData = new UCPlayerEditData();
            playerEditData.txtFirstName.Text = selectedPlayer.FirstName;
            playerEditData.txtLastName.Text = selectedPlayer.LastName;
            playerEditData.txtPosition.Text = selectedPlayer.Position;

            List<Team> teams = CommunicationHelper.Instance.GetAllTeams();
            playerEditData.cmbTeams.Items.Clear();
            playerEditData.cmbTeams.Items.AddRange(teams.ToArray());
            playerEditData.cmbTeams.DisplayMember = "Name";

            //for showing team name on combo box on UserControl Initialize
            foreach (var team in teams)
            {
                if (team.TeamId == selectedPlayer.Team.TeamId)
                {
                    playerEditData.cmbTeams.Text = team.Name;
                }
            }
            playerEditData.btnUpdate.Click += BtnUpdatePlayer;
            return playerEditData;
        }

        

        public UCTeamEditData MakeTeamEditWindow(Team selectedTeam)
        {
            this.selectedTeam = selectedTeam;
            teamEditData = new UCTeamEditData();
            teamEditData.txtName.Text = selectedTeam.Name;
            teamEditData.txtArena.Text = selectedTeam.Arena;
            teamEditData.txtEuroleagueTitles.Text = selectedTeam.
                EuroleagueChampionsTitles.ToString();

            List<City> cities= CommunicationHelper.Instance.GetAllCities();
            teamEditData.cmbCity.Items.Clear();
            teamEditData.cmbCity.Items.AddRange(cities.ToArray());
            teamEditData.cmbCity.DisplayMember = "Name";

            //for showing city name on combo box on UserControl Initialize
            foreach (var city in cities)
            {
                if (city.CityId == selectedTeam.City.CityId)
                {
                    teamEditData.cmbCity.Text = city.Name;
                }
            }
            
            teamEditData.txtCoach.Text = selectedTeam.Coach;
            teamEditData.btnUpdate.Click += BtnUpdateTeam;
            return teamEditData;
        }
        private void BtnUpdatePlayer(object sender, EventArgs e)
        {
            try
            {
                Player playerToUpdate = new Player()
                {
                    PlayerId = selectedPlayer.PlayerId,
                    FirstName = playerEditData.txtFirstName.Text,
                    LastName = playerEditData.txtLastName.Text,
                    Position = playerEditData.txtPosition.Text,
                    Team = (Team)playerEditData.cmbTeams.SelectedItem

                };
                if (string.IsNullOrEmpty(playerToUpdate.FirstName)
                   || !playerToUpdate.FirstName.All(c => char.IsLetter(c)|| c == ' '
                   || c == '-'))
                {
                    MessageBox.Show("Invalid player's first name." +
                        " Please enter a valid first name using letters.");
                    return;
                }

                if (string.IsNullOrEmpty(playerToUpdate.LastName)
                    || !playerToUpdate.LastName.All(c => char.IsLetter(c) || c == ' '
                    || c == '-'))
                {
                    MessageBox.Show("Invalid player's last name." +
                        " Please enter a valid last name using letters.");
                    return;
                }
                Player updatedPlayer = CommunicationHelper.Instance.UpdatePlayer(playerToUpdate);
                playerEditData.txtFirstName.Text = updatedPlayer.FirstName;
                playerEditData.txtLastName.Text = updatedPlayer.LastName;
                playerEditData.txtPosition.Text = updatedPlayer.Position;
                playerEditData.cmbTeams.SelectedItem = updatedPlayer.Team.Name;
                
            }
            catch (Exception ex)
            {
                string message = "Player can't be null and" + " " + ex.Message;
                MessageBox.Show(message);
            }
        }
        private void BtnUpdateTeam(object sender, EventArgs e)
        {
            try
            {
                Team teamToUpdate = new Team()
                {
                    TeamId = selectedTeam.TeamId,
                    Name = teamEditData.txtName.Text,
                    EuroleagueChampionsTitles = int.Parse(teamEditData
                    .txtEuroleagueTitles.Text),
                    Coach = teamEditData.txtCoach.Text,
                    Arena = teamEditData.txtArena.Text,
                    City = (City)teamEditData.cmbCity.SelectedItem

                };
                if (string.IsNullOrEmpty(teamToUpdate.Name)
                   || !teamToUpdate.Name.All(c => char.IsLetter(c) || c == ' '))
                {
                    MessageBox.Show("Invalid team name." +
                        " Please enter a valid name without numbers.");
                    return;
                }

                if (string.IsNullOrEmpty(teamToUpdate.Coach)
                    || !teamToUpdate.Coach.All(c => char.IsLetter(c) || c == ' '))
                {
                    MessageBox.Show("Invalid coach name." +
                        " Please enter a valid name without numbers.");
                    return;
                }
                Team updatedTeam=CommunicationHelper.Instance.UpdateTeam(teamToUpdate);
                teamEditData.txtName.Text = updatedTeam.Name;
                teamEditData.txtEuroleagueTitles.Text = updatedTeam.EuroleagueChampionsTitles
                    +"";
                teamEditData.txtCoach.Text = updatedTeam.Coach;
                teamEditData.txtArena.Text = updatedTeam.Arena;
                //teamEditData.cmbCity.SelectedItem= updatedTeam.City.Name;
            }
            catch (Exception ex)
            {
                string message = "Team can't be null and" + " " + ex.Message;
                MessageBox.Show(message);
            }
        }

        public Control MakeGameEditWindow(Game selectedGame)
        {
            this.selectedGame = selectedGame;

            gameEditData = new UCGameEditData();
            gameEditData.txtGameDateTime.Text = selectedGame.GameTime.
                ToString("MM/dd/yyyy").Replace('-', '/');
            
            List<Team> teams = CommunicationHelper.Instance.GetAllTeams();
            gameEditData.cmbHome.Items.Clear();
            gameEditData.cmbAway.Items.Clear();
            gameEditData.cmbHome.Items.AddRange(teams.ToArray());
            gameEditData.cmbAway.Items.AddRange(teams.ToArray());
            gameEditData.cmbHome.Text = selectedGame.Team1.Name;
            gameEditData.cmbAway.Text = selectedGame.Team2.Name;

            gameEditData.btnShowPlayers.Click += BtnShowPlayers;
            gameEditData.btnAddStats.Click += BtnAddStats;
            gameEditData.btnUpdateGame.Click += BtnUpdateGame;


            //for showing team name on combo box on UserControl Initialize
            foreach (var team in teams)
            {
                if (team.TeamId == selectedGame.Team1.TeamId)
                {
                    gameEditData.cmbHome.Text = team.Name;
                }
                if (team.TeamId == selectedGame.Team2.TeamId)
                {
                    gameEditData.cmbAway.Text = team.Name;
                }
            }

            return gameEditData;
        }

        private void BtnAddStats(object sender, EventArgs e)
        {
            try
            {
                Player player = gameEditData.cmbPlayer.SelectedItem as Player;
                if (player == null)
                {
                    MessageBox.Show("Invalid player." +
                        " Please select a player from combo box.");
                    return;
                }
                if (string.IsNullOrEmpty(gameEditData.txtPoints.Text))
                {
                    MessageBox.Show("Invalid points field." +
                        " Please enter a valid value, enter a number.");
                    return;
                }
                DataGridView dgv;
                // Provera da li igrač već postoji u DataGridView 
                if (gameEditData.dgvPlayersStats.Visible)
                {
                    dgv = gameEditData.dgvPlayersStats;
                }
                else
                {
                    dgv = gameEditData.dgvStats;
                }

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells["PlayerId"].Value.Equals(player.PlayerId))
                    {
                        MessageBox.Show("Statistics for this player has already filled.");
                        return;
                    }
                }
                PlayerStatistics playerStatistics = new PlayerStatistics();
                playerStatistics.PlayersPoints = int.Parse(gameEditData.txtPoints.Text);
                //dodajemo prazan red i on vraca njegov indeks
                
                if (gameEditData.dgvStats.Visible)
                {
                    dataTable.Columns.Add("PlayerId", typeof(int));
                    dataTable.Columns.Add("GameId", typeof(string));
                    dataTable.Columns.Add("PlayerName", typeof(string));
                    dataTable.Columns.Add("PlayersPoints", typeof(int));

                    dataTable.Rows.Add(player.PlayerId,selectedGame.GameId,player.LastName,
                        playerStatistics.PlayersPoints);

                    gameEditData.dgvStats.DataSource= dataTable;
                    
                }
                else
                {
                    int rowIndex = gameEditData.dgvPlayersStats.Rows.Add();
                    gameEditData.dgvPlayersStats.Rows[rowIndex].Cells["Player"].
                    Value = player.LastName;
                    gameEditData.dgvPlayersStats.Rows[rowIndex].Cells["PlayerPoints"].
                        Value = playerStatistics.PlayersPoints;
                    gameEditData.dgvPlayersStats.Rows[rowIndex].Cells["PlayerId"].
                        Value = player.PlayerId;
                    
                }
                
                

            }
            catch (Exception ex)
            {
                string message = "Player can't be null and" + " " + ex.Message;
                MessageBox.Show(message);
            }


        }

        private void BtnShowPlayers(object sender, EventArgs e)
        {
            gameEditData.btnShowPlayers.Enabled = false;
            gameEditData.txtGameDateTime.Enabled = false;
            gameEditData.cmbAway.Enabled = false;
            gameEditData.cmbHome.Enabled = false;
            DateTime dateValue;
            bool isValidDateFormat = DateTime.TryParseExact(gameEditData.txtGameDateTime.Text,
                "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue);
            if (!isValidDateFormat)
            {
                MessageBox.Show("Game DateTime format is not valid, please enter valid " +
                    "format like this: MM/dd/yyyy");
                return;
            }
            if (gameEditData.cmbHome.SelectedItem == null)
            {
                MessageBox.Show("Home team hasn't selected, please select team.");
                return;
            }
            if (gameEditData.cmbAway.SelectedItem == null)
            {
                MessageBox.Show("Away team hasn't selected, please select team.");
                return;
            }
            if (gameEditData.cmbAway.SelectedItem.Equals(gameEditData.cmbHome.SelectedItem))
            {
                MessageBox.Show("Home team and Away team are equal, please select 2 diff" +
                    "erent teams.");
                return;
            }
            gameEditData.lbl1.Visible = true;
            gameEditData.lbl2.Visible = true;
            gameEditData.lbl3.Visible = true;
            gameEditData.lbl4.Visible = true;
            gameEditData.lbl5.Visible = true;
            gameEditData.lbl6.Visible = true;
            gameEditData.dgvPlayersStats.Visible = true;
            gameEditData.cmbPlayer.Visible = true;
            gameEditData.txtPoints.Visible = true;
            gameEditData.txtHomeTeamPoints.Visible = true;
            gameEditData.txtAwayTeamPoints.Visible = true;
            gameEditData.btnAddStats.Visible = true;
            gameEditData.btnUpdateGame.Visible = true;
            FillCmbWithHomeAwayPlayers();
            
            //ovde proveravamo da li su u editu promenjeni timovi jer ako je bar jedan promenjen
            // to je totalno nova utakmica pa onda necemo kupiti statistiku igraca nego cemo unositi
            //novu a ako hocemo da editujemo utakmicu a ne menjamo timove onda vucemo trenutnu stats
            //i editujemo je (broj poena igraca i rez tekme)

            if ((((Team)gameEditData.cmbHome.SelectedItem).TeamId).Equals(selectedGame.Team1.TeamId) &&
               (((Team)gameEditData.cmbAway.SelectedItem).TeamId).Equals(selectedGame.Team2.TeamId))
            {
                gameEditData.dgvStats.Visible = true;
                gameEditData.dgvPlayersStats.Visible = false;
                gameEditData.lbl2.Visible = false;
                gameEditData.lbl3.Visible = false;
                gameEditData.lbl4.Visible = false;
                gameEditData.cmbPlayer.Visible = false;
                gameEditData.txtPoints.Visible = false;
                gameEditData.btnAddStats.Visible = false;
                gameEditData.txtAwayTeamPoints.Text = selectedGame.AwayTeamPoints + "";
                gameEditData.txtHomeTeamPoints.Text = selectedGame.HomeTeamPoints + "";
                
                fillDgvStats();

            }
            else 
            {
                gameEditData.dgvPlayersStats.Visible = true;
                gameEditData.dgvStats.Visible = false;
            }
            

        }
        private void fillDgvStats()
        {
            gameEditData.dgvStats.DataSource = selectedGame.PlayersStatsList;
            gameEditData.dgvStats.Columns[0].Visible = false;
            gameEditData.dgvStats.Columns[1].Visible = false;
            gameEditData.dgvStats.Columns[0].ReadOnly = true;
            gameEditData.dgvStats.Columns[1].ReadOnly = true;
            gameEditData.dgvStats.Columns[2].ReadOnly = true;
            //gameEditData.dgvStats.RowHeaderMouseClick += AllowDeleteGame;
            //gameEditData.dgvStats.CellMouseClick += NotAllowDeleteGame;
        }
       /* private void NotAllowDeleteGame(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                
            }
        }*/

        /*private void AllowDeleteGame(object sender, DataGridViewCellMouseEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete player's statistics?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool isDataGridViewEmpty = gameEditData.dgvStats.RowCount == 1;
                if (isDataGridViewEmpty)
                {
                    MessageBox.Show("You can't delete last one player because statistics will" +
                        "be empty.");
                    return;
                }
                var selectedRow = gameEditData.dgvStats.SelectedRows[0];
                int rowIndex = selectedRow.Index;
                
                statsListForDelete.Add(new PlayerStatistics()
                {
                    PlayerId = Convert.ToInt32(selectedRow.Cells["PlayerId"].Value),
                    GameId = selectedGame.GameId,
                    Player = new Player()
                    {
                        LastName = selectedRow.Cells["PlayerName"].Value.ToString()
                    },
                    PlayersPoints = Convert.ToInt32(selectedRow.Cells["PlayersPoints"].Value)
                });

                selectedGame.PlayersStatsList.RemoveAt(rowIndex);
                gameEditData.dgvStats.DataSource = null;
                gameEditData.dgvStats.DataSource = selectedGame.PlayersStatsList;
                gameEditData.dgvStats.Columns[0].Visible = false;
                gameEditData.dgvStats.Columns[1].Visible = false;
                gameEditData.dgvStats.Columns[0].ReadOnly = true;
                gameEditData.dgvStats.Columns[1].ReadOnly = true;
                gameEditData.dgvStats.Columns[2].ReadOnly = true;



                /* PlayerStatistics playerStats = new PlayerStatistics()
                 {
                     PlayerId = Convert.ToInt32(selectedRow.Cells["PlayerId"].Value),
                     GameId = selectedGame.GameId,
                     Player =new Player()
                     {
                         LastName=selectedRow.Cells["PlayerName"].Value.ToString()
                     },
                     PlayersPoints = Convert.ToInt32(selectedRow.Cells["PlayersPoints"].Value)
                 };
                 CommunicationHelper.Instance.DeletePlayerStats(playerStats);
                 gameEditData.dgvStats.DataSource = CommunicationHelper.Instance.
                     GetStatsForThatGame(selectedGame);

            }
            
        }*/
        private void FillCmbWithHomeAwayPlayers()
        {
            try
            {
                Team home = (Team)gameEditData.cmbHome.SelectedItem;
                Team away = (Team)gameEditData.cmbAway.SelectedItem;

                List<Team> teams = new List<Team>
                {
                    home,
                    away
                };

                List<Player> players = CommunicationHelper.Instance.GetHomeAwayPlayers(teams);
                gameEditData.cmbPlayer.Items.Clear();
                gameEditData.cmbPlayer.Items.AddRange(players.ToArray());
                gameEditData.cmbPlayer.DisplayMember = "LastName";

            }
            catch (Exception)
            {

                string message = "ComboBox with teams can't be empty";
                MessageBox.Show(message);
            }
        }
        private void BtnUpdateGame(object sender, EventArgs e)
        {
            try
            {
                Game gameToUpdate = new Game()
                {
                    GameId = selectedGame.GameId,
                    GameTime = DateTime.Parse(gameEditData.txtGameDateTime.Text),
                    Team1 = ((Team)gameEditData.cmbHome.SelectedItem),
                    Team2 = ((Team)gameEditData.cmbAway.SelectedItem),
                    HomeTeamPoints = int.Parse(gameEditData.txtHomeTeamPoints.Text),
                    AwayTeamPoints = int.Parse(gameEditData.txtAwayTeamPoints.Text)

                };
                if (string.IsNullOrEmpty(gameToUpdate.HomeTeamPoints + "") ||
                    string.IsNullOrEmpty(gameToUpdate.AwayTeamPoints + ""))
                {
                    MessageBox.Show("Invalid game points." +
                        " Please enter a valid points.");
                    return;
                }
                

                if (gameEditData.dgvPlayersStats.Visible)
                {

                    foreach (DataGridViewRow row in gameEditData.dgvPlayersStats.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            PlayerStatistics pstats = new PlayerStatistics()
                            {
                                PlayerId = Convert.ToInt32(row.Cells["PlayerId"].Value),
                                Player=new Player()
                                {
                                    LastName = row.Cells["Player"].Value.ToString()
                                },
                                PlayersPoints = Convert.ToInt32(row.Cells["PlayerPoints"].Value)
                            };
                            gameToUpdate.PlayersStatsList.Add(pstats);
                            
                        }
                    }
                    Game updatedGame = CommunicationHelper.Instance.UpdateGameWithDelete(gameToUpdate);
                }
                else
                {
                    foreach (DataGridViewRow row in gameEditData.dgvStats.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            PlayerStatistics pstats = new PlayerStatistics();

                            pstats.PlayerId = Convert.ToInt32(row.Cells["PlayerId"].Value);
                            pstats.Player = new Player()
                            {
                                LastName = row.Cells["Player"].Value.ToString()
                            };
                            pstats.PlayersPoints = Convert.ToInt32(row.Cells["PlayersPoints"].Value);
                            gameToUpdate.PlayersStatsList.Add(pstats);
                            
                        }
                    }
                    Game updatedGame = CommunicationHelper.Instance.UpdateGame(gameToUpdate);
                }
                

            }
            catch (Exception ex)
            {
                string message = "Team can't be null and" + " " + ex.Message;
                MessageBox.Show(message);
            }
        
        }
    }
}
