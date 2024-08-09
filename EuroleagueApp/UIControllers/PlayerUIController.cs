using Entity;
using Entity.Models;
using EuroleagueApp.Forms;
using EuroleagueApp.UserControls.UCPlayers;
using EuroleagueApp.UserControls.UCTeams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EuroleagueApp.UIControllers
{
	public class PlayerUIController
	{
		private UCPlayerCreate playerCreate;
        private UCPlayerSearch playerSearch;
        private MenuForm menuForm;
        Player player;
        
        public UCPlayerCreate MakeCreatePlayerWindow()
		{
			playerCreate = new UCPlayerCreate();
			CmbTeamsFill();
            CmbPositionsFill();
			playerCreate.btnCreate.Click += BtnCreate;
            return playerCreate; 

		}
       
       
        public UCPlayerSearch MakeSearchPlayerWindow(MenuForm menuForm)
        {
            this.menuForm = menuForm;
            playerSearch = new UCPlayerSearch();
            List<Player> playerList = CommunicationHelper.Instance.GetAllPlayers();
            playerSearch.dgvPlayers.DataSource = playerList;
            playerSearch.dgvPlayers.Columns[0].Visible = false;
            playerSearch.dgvPlayers.Columns[0].ReadOnly = true;
            playerSearch.dgvPlayers.Columns[1].ReadOnly = true;
            playerSearch.dgvPlayers.Columns[2].ReadOnly = true;
            playerSearch.dgvPlayers.Columns[3].ReadOnly = true;
            playerSearch.dgvPlayers.Columns[4].ReadOnly = true;
            playerSearch.txtBoxSearch.TextChanged += PlayerSearch;
            playerSearch.dgvPlayers.RowHeaderMouseClick += AllowEditPlayer;
            playerSearch.dgvPlayers.CellMouseClick += NotAllowEditPlayer;
            return playerSearch;
        }

        private void NotAllowEditPlayer(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                menuForm.editPlayerToolStripMenuItem4.Enabled = false;
            }
        }

        private void AllowEditPlayer(object sender, DataGridViewCellMouseEventArgs e)
        {
            menuForm.editPlayerToolStripMenuItem4.Enabled = true;
            int rowIndex = playerSearch.dgvPlayers.SelectedRows[0].Index;
            DataGridViewRow selectedRow = playerSearch.dgvPlayers.Rows[rowIndex];
            Player selectedPlayerFromDgv = new Player()
            {
                PlayerId = Convert.ToInt32(selectedRow.Cells["PlayerId"].Value),
                FirstName = selectedRow.Cells["FirstName"].Value.ToString(),
                LastName = selectedRow.Cells["LastName"].Value.ToString(),
                Position = selectedRow.Cells["Position"].Value.ToString(),
                Team = (Team)selectedRow.Cells["Team"].Value
            };

            Player selectedPlayer = CommunicationHelper.Instance.
                GetSelectedPlayer(selectedPlayerFromDgv);
            menuForm.selectedPlayerFromDgv = selectedPlayer;
        }

        private void PlayerSearch(object sender, EventArgs e)
        {
            try
            {
                List<Player> filteredPlayers = CommunicationHelper.Instance.
                    GetFilteredPlayers(playerSearch.txtBoxSearch.Text);
                playerSearch.dgvPlayers.DataSource = filteredPlayers;
            }
            catch (Exception ex)
            {
                string message = "Filtered players can't be null and" + " " + ex.Message;
                MessageBox.Show(message);
            }
        }

        private void BtnCreate(object sender, EventArgs e)
        {
			try
			{
				Player player = new Player()
				{
					FirstName = playerCreate.txtFirstName.Text,
					LastName = playerCreate.txtLastName.Text,
					Position = playerCreate.cmbPositions.SelectedItem + "",
					Team = (Team)playerCreate.cmbTeams.SelectedItem
				};
                if (string.IsNullOrWhiteSpace(player.FirstName) 
					|| !player.FirstName.All(char.IsLetter))
                {
                    MessageBox.Show("Invalid player first name." +
						" Please enter a valid first name without numbers.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(player.LastName)
                    || !player.LastName.All(char.IsLetter))
                {
                    MessageBox.Show("Invalid player last name." +
                        " Please enter a valid last name without numbers.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(player.Position))
                {
                    MessageBox.Show("Invalid player position." +
                        " Please enter a valid position from combo box.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(playerCreate.cmbTeams.SelectedItem.ToString()))
                {
                    MessageBox.Show("Invalid player's team." +
                        " Please enter a valid team from combo box.");
                    return;
                }
                player = CommunicationHelper.Instance.InsertPlayer(player);
                this.player = player;
            }
			catch (Exception ex)
			{
                string message = "Player can't be null and" + " " + ex.Message;
                MessageBox.Show(message);
            }
        }
        private void CmbPositionsFill()
        {
            object[] positions = { 1, 2, 3, 4, 5 };
            playerCreate.cmbPositions.Items.Clear();
            playerCreate.cmbPositions.Items.AddRange(positions);
   
            
        }
        public void CmbTeamsFill()
        {
			try
			{
                List<Team> teams = CommunicationHelper.Instance.GetAllTeams();
                playerCreate.cmbTeams.Items.Clear();
                playerCreate.cmbTeams.Items.AddRange(teams.ToArray());
                playerCreate.cmbTeams.DisplayMember = "Name";
            }
			catch (Exception)
			{

				string message = "ComboBox with teams can't be empty";
				MessageBox.Show(message);
			}
        }
    }
}
