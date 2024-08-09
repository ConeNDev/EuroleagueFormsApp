using Entity;
using Entity.Models;
using EuroleagueApp.Forms;
using EuroleagueApp.UIControllers;
using EuroleagueApp.UserControls.UCPlayers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EuroleagueApp.UserControls.UCTeams
{
	public partial class UCTeamSearch : UserControl
	{
        MenuForm menuForm;
		public UCTeamSearch()
		{
			InitializeComponent();
		}
        
        private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

        private void dgvTeams_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgvTeams_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
