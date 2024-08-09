using Common;
using Common.Communication;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerEuroleague
{
    public class ClientHandler
    {
        Socket socket;
        Receiver receiver;
        Sender sender;
        
        public ClientHandler(Socket socket)
        {
            this.socket = socket;
            receiver = new Receiver(this.socket);
            sender = new Sender(this.socket);
        }
        public void HandleRequest()
        {
            try
            {
                while (Server.Instance.isRunning)
                {
                    Request request = (Request)receiver.Receive();
                    Response response = Controller.Instance.HandleSingleRequest(request);
                    sender.Send(response);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Debug.WriteLine(ex.Message);
            }
        }
        internal void Check()
        {
            throw new NotImplementedException();
        }
    }
}
