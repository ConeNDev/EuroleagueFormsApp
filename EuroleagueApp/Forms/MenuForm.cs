using Entity;
using EuroleagueApp.UIControllers;
using EuroleagueApp.UserControls.UCGames;
using EuroleagueApp.UserControls.UCPlayers;
using EuroleagueApp.UserControls.UCTeams;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EuroleagueApp.Forms
{
    public partial class MenuForm : Form
    {
		public Team selectedTeamFromDgv;
		public Player selectedPlayerFromDgv;
		public Game selectedGameFromDgv;
        public MenuForm()
        {
            InitializeComponent();
        }
		public void ChangePanel(Control control)
		{

			pnlMenu.Controls.Clear();

			if (control.GetType() == typeof(UCTeamCreate) ||
				control.GetType() == typeof(UCPlayerCreate) ||
				control.GetType() == typeof(UCTeamEditData) ||
				control.GetType() == typeof(UCPlayerEditData))
			{
				this.toolStripMenuItem1.Padding = new Padding(34, 0, 5, 0);
				this.toolStripMenuItem2.Padding = new Padding(34, 0, 5, 0);
				this.toolStripMenuItem3.Padding = new Padding(34, 0, 5, 0);
				this.Size = new System.Drawing.Size(341, 512);
				pnlMenu.Size = new System.Drawing.Size(366, 522);
			}
			if (control.GetType() == typeof(UCTeamSearch) ||
				control.GetType() == typeof(UCPlayerSearch) ||
                control.GetType() == typeof(UCGameSearch)) 
			{
				this.toolStripMenuItem1.Padding = new Padding(201, 0, 5, 0);
				this.toolStripMenuItem2.Padding = new Padding(201, 0, 5, 0);
				this.toolStripMenuItem3.Padding = new Padding(201, 0, 5, 0);
				this.Size = new System.Drawing.Size(834, 600);
				pnlMenu.Size = new System.Drawing.Size(898, 585);

			}
			if (control.GetType() == typeof(UCGameCreate) ||
                control.GetType() == typeof(UCGameEditData))
			{
                this.toolStripMenuItem1.Padding = new Padding(128, 0, 5, 0);
                this.toolStripMenuItem2.Padding = new Padding(128, 0, 5, 0);
                this.toolStripMenuItem3.Padding = new Padding(128, 0, 5, 0);
                this.Size = new System.Drawing.Size(634, 600);
                pnlMenu.Size = new System.Drawing.Size(698, 575);
            }
			control.Dock = DockStyle.Fill;
			pnlMenu.Controls.Add(control);
		}

		private void searchTeamToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TeamUIController teamUIController = new TeamUIController();
			ChangePanel(teamUIController.MakeSearchTeamWindow(this));
		}

		private void createPlayerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PlayerUIController playerUIController = new PlayerUIController();
			ChangePanel(playerUIController.MakeCreatePlayerWindow());
		}
        private void createTeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeamUIController teamUIController = new TeamUIController();
            ChangePanel(teamUIController.MakeCreateTeamWindow());
        }

        private void editTeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
			ChangesUIController changesUIController = new ChangesUIController();
			ChangePanel(changesUIController.
				MakeTeamEditWindow(selectedTeamFromDgv,this));
        }
        private void editPlayerToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ChangesUIController changesUIController = new ChangesUIController();
            ChangePanel(changesUIController.
               MakePlayerEditWindow(selectedPlayerFromDgv, this));
        }
        private void searchPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
			PlayerUIController playerUIController = new PlayerUIController();
			ChangePanel(playerUIController.MakeSearchPlayerWindow(this));
        }

        private void createGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
			GameUIController gameUIController = new GameUIController();
			ChangePanel(gameUIController.MakeCreateGameWindow());
        }

        private void gameSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameUIController gameUIController = new GameUIController();
            ChangePanel(gameUIController.MakeSearchGameWindow(this));
        }

        private void editGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangesUIController changesUIController = new ChangesUIController();
            ChangePanel(changesUIController.
               MakeGameEditWindow(selectedGameFromDgv, this));
        }
    }
}
