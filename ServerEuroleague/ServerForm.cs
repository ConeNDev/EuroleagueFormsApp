    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerEuroleague
{
    public partial class ServerForm : Form
    {
        Server server;
        public ServerForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                Server.Instance.Start();
                ChangeLabelStatus(true);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                Server.Instance.Stop();
                ChangeLabelStatus(false);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private void ChangeLabelStatus(bool isServerOnline)
        {
            if (isServerOnline)
            {
                lblStanje.Text = "Server status: online";
                lblStanje.ForeColor = Color.LightGreen;
            }
            else
            {
                lblStanje.Text = "Server status: offline";
                lblStanje.ForeColor = Color.DarkGray;
            }
        }
    }
}
