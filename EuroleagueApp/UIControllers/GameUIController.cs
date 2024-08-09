using Entity;
using EuroleagueApp.Forms;
using EuroleagueApp.UserControls.UCGames;
using EuroleagueApp.UserControls.UCPlayers;
using EuroleagueApp.UserControls.UCTeams;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EuroleagueApp.UIControllers
{
    public class GameUIController
    {
        private MenuForm menuForm;
        private UCGameCreate gameCreate;
        private UCGameSearch gameSearch;
        
        public UCGameCreate MakeCreateGameWindow()
        {
            gameCreate = new UCGameCreate();
            CmbFillAwayAndHomeTeams();
            gameCreate.btnShowPlayers.Click += BtnShowPlayers;
            gameCreate.btnAddStats.Click += BtnAddStats;
            gameCreate.btnCreateGame.Click += BtnCreateGame;
            return gameCreate;
        }
        public UCGameSearch MakeSearchGameWindow(MenuForm menuForm)
        {
            this.menuForm = menuForm;
            gameSearch = new UCGameSearch();
            List<Game> gameList = CommunicationHelper.Instance.GetAllGames();
            gameSearch.dgvGames.DataSource = gameList;
            gameSearch.dgvGames.Columns[0].Visible = false;
            gameSearch.dgvGames.Columns[0].ReadOnly = true;
            gameSearch.dgvGames.Columns[1].ReadOnly = true;
            gameSearch.dgvGames.Columns[2].ReadOnly = true;
            gameSearch.dgvGames.Columns[3].ReadOnly = true;
            gameSearch.dgvGames.Columns[4].ReadOnly = true;
            gameSearch.dgvGames.Columns[5].ReadOnly = true;
            gameSearch.txtBoxSearch.TextChanged += GameSearch;
            gameSearch.dgvGames.RowHeaderMouseClick += AllowEditGame;
            gameSearch.dgvGames.CellMouseClick += NotAllowEditGame;
            return gameSearch;
        }

        
        private void NotAllowEditGame(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                menuForm.editGameToolStripMenuItem.Enabled = false;
            }
        }

        private void AllowEditGame(object sender, DataGridViewCellMouseEventArgs e)
        {
            menuForm.editGameToolStripMenuItem.Enabled = true;

            int rowIndex = gameSearch.dgvGames.SelectedRows[0].Index;
            DataGridViewRow selectedRow = gameSearch.dgvGames.Rows[rowIndex];
            Game selectedGameFromDgv = new Game()
            {
                GameId = Convert.ToInt32(selectedRow.Cells["GameId"].Value),
                GameTime = (DateTime)selectedRow.Cells["GameTime"].Value,
                HomeTeamPoints = Convert.ToInt32(selectedRow.Cells["HomeTeamPoints"].Value),
                AwayTeamPoints = Convert.ToInt32(selectedRow.Cells["HomeTeamPoints"].Value),
                Team1 = (Team)(selectedRow.Cells["Team1"].Value),
                Team2 = (Team)(selectedRow.Cells["Team2"].Value),
                
            };

            Game selectedGame = CommunicationHelper.Instance.
                 GetSelectedGame(selectedGameFromDgv);

            selectedGame.PlayersStatsList = CommunicationHelper.Instance
                .GetStatsForThatGame(selectedGame);

            menuForm.selectedGameFromDgv = selectedGame;

        }


        private void GameSearch(object sender, EventArgs e)
        {
            try
            {
                List<Game> filteredGames = CommunicationHelper.Instance.
                    GetFilteredGames(gameSearch.txtBoxSearch.Text);
                gameSearch.dgvGames.DataSource = filteredGames;
            }
            catch (Exception ex)
            {
                string message = "Filtered teams can't be null and" + " " + ex.Message;
                MessageBox.Show(message);
            }
        }

        private void BtnCreateGame(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(gameCreate.txtHomeTeamPoints.Text))
                {
                    MessageBox.Show("Home team's points are null, please enter team points.");
                    return;
                }
                if (string.IsNullOrEmpty(gameCreate.txtAwayTeamPoints.Text))
                {
                    MessageBox.Show("Away team's points are null, please enter team points.");
                    return;
                }

                Game game = new Game()
                {
                    GameTime = DateTime.Parse(gameCreate.txtGameDateTime.Text),
                    HomeTeamPoints = int.Parse(gameCreate.txtHomeTeamPoints.Text),
                    AwayTeamPoints = int.Parse(gameCreate.txtAwayTeamPoints.Text),
                    Team1 = (Team)gameCreate.cmbHome.SelectedItem,
                    Team2 = (Team)gameCreate.cmbAway.SelectedItem
                };
                bool isDataGridViewEmpty = gameCreate.dgvPlayersStats.RowCount == 0;
                if (isDataGridViewEmpty)
                {
                    MessageBox.Show("Player's statistics is empty.");
                    return;
                }
                
                foreach (DataGridViewRow row in gameCreate.dgvPlayersStats.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        PlayerStatistics playerStatistics = new PlayerStatistics();

                        playerStatistics.PlayerId = Convert.ToInt32(row.Cells["PlayerId"].Value);
                        playerStatistics.GameId = game.GameId;
                        playerStatistics.Player = new Player()
                        {
                            LastName = row.Cells["LastName"].Value.ToString()
                        };
                        playerStatistics.PlayersPoints = Convert.ToInt32(row.Cells["Points"].Value);


                        game.PlayersStatsList.Add(playerStatistics);
                    }
                }
                game = CommunicationHelper.Instance.InsertGame(game);
            }
            catch (Exception ex)
            {
                string message = "Game can't be null and" + " " + ex.Message;
                MessageBox.Show(message);
            }
        }
        private void BtnAddStats(object sender, EventArgs e)
        {
            try
            {
                Player player = gameCreate.cmbPlayer.SelectedItem as Player;
                if (player == null)
                {
                    MessageBox.Show("Invalid player." +
                        " Please select a player from combo box.");
                    return;
                }
                if (string.IsNullOrEmpty(gameCreate.txtPoints.Text))
                {
                    MessageBox.Show("Invalid points field." +
                        " Please enter a valid value, enter a number.");
                    return;
                }

                // Provera da li igrač već postoji u DataGridView
                foreach (DataGridViewRow row in gameCreate.dgvPlayersStats.Rows)
                {
                    if (row.Cells["FirstName"].Value == player.FirstName &&
                        row.Cells["LastName"].Value == player.LastName)
                    {
                        MessageBox.Show("Statistics for this player has already added.");
                        return;
                    }
                }
                PlayerStatistics playerStatistics = new PlayerStatistics();
                playerStatistics.PlayersPoints = int.Parse(gameCreate.txtPoints.Text);
                //dodajemo prazan red i on vraca njegov indeks
                int rowIndex = gameCreate.dgvPlayersStats.Rows.Add();

                // Popunjavanje novog reda podacima
                gameCreate.dgvPlayersStats.Rows[rowIndex].Cells["FirstName"].
                    Value = player.FirstName;
                gameCreate.dgvPlayersStats.Rows[rowIndex].Cells["LastName"].
                    Value = player.LastName;
                gameCreate.dgvPlayersStats.Rows[rowIndex].Cells["Points"].
                    Value = playerStatistics.PlayersPoints;
                gameCreate.dgvPlayersStats.Rows[rowIndex].Cells["PlayerId"].
                    Value = player.PlayerId;

            }
            catch (Exception ex)
            {
                string message = "Player can't be null and" + " " + ex.Message;
                MessageBox.Show(message);
            }


        }

        private void BtnShowPlayers(object sender, EventArgs e)
        {

            DateTime dateValue;
            bool isValidDateFormat = DateTime.TryParseExact(gameCreate.txtGameDateTime.Text,
                "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue);
            if (!isValidDateFormat)
            {
                MessageBox.Show("Game DateTime format is not valid, please enter valid " +
                    "format like this: MM/dd/yyyy");
                return;
            }
            if (gameCreate.cmbHome.SelectedItem == null)
            {
                MessageBox.Show("Home team hasn't selected, please select team.");
                return;
            }
            if (gameCreate.cmbAway.SelectedItem == null)
            {
                MessageBox.Show("Away team hasn't selected, please select team.");
                return;
            }
            if (gameCreate.cmbAway.SelectedItem.Equals(gameCreate.cmbHome.SelectedItem))
            {
                MessageBox.Show("Home team and Away team are equal, please select 2 diff" +
                    "erent teams.");
                return;
            }
            
            gameCreate.txtGameDateTime.Enabled = false;
            gameCreate.cmbAway.Enabled = false;
            gameCreate.cmbHome.Enabled = false;
            gameCreate.lbl1.Visible = true;
            gameCreate.lbl2.Visible = true;
            gameCreate.lbl3.Visible = true;
            gameCreate.lbl4.Visible = true;
            gameCreate.lbl5.Visible = true;
            gameCreate.lbl6.Visible = true;
            gameCreate.dgvPlayersStats.Visible = true;
            gameCreate.cmbPlayer.Visible = true;
            gameCreate.txtPoints.Visible = true;
            gameCreate.txtHomeTeamPoints.Visible = true;
            gameCreate.txtAwayTeamPoints.Visible = true;
            gameCreate.btnAddStats.Visible = true;
            gameCreate.btnCreateGame.Visible = true;
            FillCmbWithHomeAwayPlayers();
        }

        private void FillCmbWithHomeAwayPlayers()
        {
            try
            {
                Team home = (Team)gameCreate.cmbHome.SelectedItem;
                Team away = (Team)gameCreate.cmbAway.SelectedItem;

                List<Team> teams = new List<Team>
                {
                    home,
                    away
                };
                List<Player> players = CommunicationHelper.Instance.GetHomeAwayPlayers(teams);
                gameCreate.cmbPlayer.Items.Clear();
                gameCreate.cmbPlayer.Items.AddRange(players.ToArray());
                gameCreate.cmbPlayer.DisplayMember = "LastName";

            }
            catch (Exception)
            {

                string message = "ComboBox with teams can't be empty";
                MessageBox.Show(message);
            }
        }

        private void CmbFillAwayAndHomeTeams()
        {
            try
            {
                List<Team> teams = CommunicationHelper.Instance.GetAllTeams();
                gameCreate.cmbAway.Items.Clear();
                gameCreate.cmbAway.Items.AddRange(teams.ToArray());
                gameCreate.cmbAway.DisplayMember = "Name";
                gameCreate.cmbHome.Items.Clear();
                gameCreate.cmbHome.Items.AddRange(teams.ToArray());
                gameCreate.cmbHome.DisplayMember = "Name";
            }
            catch (Exception)
            {

                string message = "ComboBox with teams can't be empty";
                MessageBox.Show(message);
            }
        }


    }
}
