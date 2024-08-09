using ClientEuroleague;
using Entity.Models;
using EuroleagueApp.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EuroleagueApp.UIControllers
{
    public class UserUIController
    {
        public LoginForm loginForm;

        public void Bind(LoginForm loginForm)
        {
            this.loginForm= loginForm;
            loginForm.btnLogin.Click += LoginOnClick;
        }

        private void LoginOnClick(object sender, EventArgs e)
        {
            ValidateAttempt();
            User user = new User()
            {
                Username = loginForm.txtUsername.Text,
                Password = loginForm.txtPass.Text
            };

            CommunicationHelper.Instance.User = CommunicationHelper.Instance.LoginUser(user);

            if (CommunicationHelper.Instance.User != null)
            {
                loginForm.Visible = false;
                MenuForm main = new MenuForm();
                main.ShowDialog();
            }
            else
            {
                loginForm.Refresh();
            }
        }

        private void ValidateAttempt()
        {
            if (string.IsNullOrEmpty(loginForm.txtUsername.Text) ||
                string.IsNullOrEmpty(loginForm.txtPass.Text))
                MessageBox.Show("Username or password can't be null or empty.");


            else if (string.IsNullOrWhiteSpace(loginForm.txtUsername.Text) ||
                string.IsNullOrWhiteSpace(loginForm.txtPass.Text))
                MessageBox.Show("Username or password can't be null or white space.");
        }
    }
}
