using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ServerEuroleague
{
    public class Server
    {
        private static Server instance;
        public static Server Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Server();
                }
                return instance;
            }
        }
        private Server()
        {

        }

        Socket socket;
        Receiver receiver;
        Sender sender;

        public bool isRunning = false;
        

        
        public void Stop()
        {
            try
            {
                if (socket != null)
                    socket.Close();

                isRunning = false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void Start()
        {
            try
            {
                if (!isRunning)
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
                    socket.Bind(ep);
                    socket.Listen(1000);

                    isRunning = true;

                    Thread thread1 = new Thread(new ThreadStart(AcceptingClients));
                    thread1.IsBackground = true;
                    thread1.Start();

                    Thread thread2 = new Thread(new ThreadStart(AcceptingClients));
                    thread1.IsBackground = true;
                    thread1.Start();
                }
                else
                {
                    MessageBox.Show("Server is already running");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        
        public void AcceptingClients()
        {
            try
            {
                Socket listeningSocket = socket.Accept();
                ClientHandler handler = new ClientHandler(listeningSocket);
                Thread thread2 = new Thread(new ThreadStart(handler.HandleRequest));
                thread2.IsBackground = true;
                thread2.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + "Accepting client failed");
            }
            
        }
    }
}
