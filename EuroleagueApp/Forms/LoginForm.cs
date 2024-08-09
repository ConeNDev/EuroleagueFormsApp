using Common;
using EuroleagueApp;
using EuroleagueApp.Forms;
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

namespace ClientEuroleague
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            
            InitializeComponent();
            this.txtUsername.Text = "Nemanja123";
            this.txtPass.Text = "Nemanja123";
            UserUIController userUIController = new UserUIController();
            userUIController.Bind(this);
            CommunicationHelper.Instance.Connect();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
        }
    }
}
