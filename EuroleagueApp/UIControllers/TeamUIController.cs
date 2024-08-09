using Entity;
using Entity.Models;
using EuroleagueApp.Forms;
using EuroleagueApp.UserControls.UCGames;
using EuroleagueApp.UserControls.UCTeams;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EuroleagueApp.UIControllers
{
	public class TeamUIController
	{
		private UCTeamCreate teamCreate;
		private UCTeamSearch teamSearch;
		private Team team;
		private MenuForm menuForm;
        

        public UCTeamCreate MakeCreateTeamWindow()
		{
			teamCreate = new UCTeamCreate();
			CmbFill();
			teamCreate.btnCreate.Click += BtnCreateTeam;
			return teamCreate;
		}

		private void CmbFill()
		{
			try
			{
				List<City> cities = CommunicationHelper.Instance.GetAllCities();
				teamCreate.cmbCity.Items.Clear();
				teamCreate.cmbCity.Items.AddRange(cities.ToArray());
				teamCreate.cmbCity.DisplayMember = "Name";
			}
			catch(Exception)
			{
				string message = "ComboBox with citites can't be empty";
				MessageBox.Show(message);
			}
		}

		private void BtnCreateTeam(object sender, EventArgs e)
		{
			try
			{
				Team team = new Team()
				{
					
					Name = teamCreate.txtName.Text,
					EuroleagueChampionsTitles = int.Parse(teamCreate.txtEuroleagueTitles.Text),
					Coach = teamCreate.txtCoach.Text,
					Arena = teamCreate.txtArena.Text,
					City = (City)teamCreate.cmbCity.SelectedItem
					
				};
                if (string.IsNullOrEmpty(team.Name) 
					|| !team.Name.All(c => char.IsLetter(c) || c == ' '))
                {
                    MessageBox.Show("Invalid team name." +
						" Please enter a valid name without numbers.");
                    return; 
                }

                if (string.IsNullOrEmpty(team.Coach) 
					|| !team.Coach.All(c => char.IsLetter(c) || c == ' '))
                {
                    MessageBox.Show("Invalid coach name." +
						" Please enter a valid name without numbers.");
                    return;
                }
                team = CommunicationHelper.Instance.InsertTeam(team);
				this.team = team;
			}
			catch(Exception ex)
			{
				string message = "Team can't be null and" + " "+ex.Message;
				MessageBox.Show(message);

			}
			
		}
        
        
        public UCTeamSearch MakeSearchTeamWindow(MenuForm menuForm)
		{
			this.menuForm = menuForm;
			teamSearch=new UCTeamSearch();
			List<Team> teamList=CommunicationHelper.Instance.GetAllTeams();
			teamSearch.dgvTeams.DataSource = teamList;
			teamSearch.dgvTeams.Columns[0].Visible = false;
            teamSearch.dgvTeams.Columns[0].ReadOnly = true;
            teamSearch.dgvTeams.Columns[1].ReadOnly = true;
            teamSearch.dgvTeams.Columns[2].ReadOnly = true;
            teamSearch.dgvTeams.Columns[3].ReadOnly = true;
            teamSearch.dgvTeams.Columns[4].ReadOnly = true;
            teamSearch.dgvTeams.Columns[5].ReadOnly = true;
            teamSearch.txtBoxSearch.TextChanged += TeamSearch;
            teamSearch.dgvTeams.RowHeaderMouseClick += AllowEditTeam;
			teamSearch.dgvTeams.CellMouseClick += NotAllowEditTeam;
            return teamSearch;
		}

        private void NotAllowEditTeam(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                menuForm.editTeamToolStripMenuItem.Enabled = false;
            }
        }
        private void AllowEditTeam(object sender, DataGridViewCellMouseEventArgs e)
        {
            menuForm.editTeamToolStripMenuItem.Enabled = true;
            int rowIndex = teamSearch.dgvTeams.SelectedRows[0].Index;
            DataGridViewRow selectedRow = teamSearch.dgvTeams.Rows[rowIndex];
			Team selectedTeamFromDgv = new Team()
			{
				TeamId = Convert.ToInt32(selectedRow.Cells["TeamId"].Value),
				Name = selectedRow.Cells["Name"].Value.ToString(),
				EuroleagueChampionsTitles = Convert.ToInt32(selectedRow.Cells["EuroleagueChampionsTitles"].Value),
				Coach = selectedRow.Cells["Coach"].Value.ToString(),
				Arena = selectedRow.Cells["Arena"].Value.ToString(),
				City = (City)selectedRow.Cells["City"].Value
			};

			Team selectedTeam = CommunicationHelper.Instance.
				GetSelectedTeam(selectedTeamFromDgv);
			menuForm.selectedTeamFromDgv = selectedTeam;
            

        }

        private void TeamSearch(object sender, EventArgs e)
		{
			try
			{
				List<Team> filteredTeams=CommunicationHelper.Instance.
					GetFilteredTeams(teamSearch.txtBoxSearch.Text);
				teamSearch.dgvTeams.DataSource=filteredTeams;
			}
			catch (Exception ex)
			{
				string message = "Filtered teams can't be null and" + " " + ex.Message;
				MessageBox.Show(message);
			}
			
		}
	}
}
