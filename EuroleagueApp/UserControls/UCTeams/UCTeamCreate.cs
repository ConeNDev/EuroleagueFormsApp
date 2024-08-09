using EuroleagueApp.UIControllers;
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
	public partial class UCTeamCreate : UserControl
	{
		public UCTeamCreate()
		{
			InitializeComponent();
			
		}

		private void btnCreate_Click(object sender, EventArgs e)
		{

		}

		private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
		{
			TeamUIController teamCreateUIController = new TeamUIController();
			
		}

		private void txtEuroleagueTitles_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
			{
				e.Handled = true;
			}
		}
	}
}
