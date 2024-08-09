using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class Sender
    {
        Socket socket;
        NetworkStream stream;
        BinaryFormatter formatter;
        public Sender(Socket socket)
        {
            this.socket = socket;
            formatter = new BinaryFormatter();
            stream = new NetworkStream(socket);
        }
        public void Send<T>(T request)
        {
            formatter.Serialize(stream, request);
        }
    }
}
