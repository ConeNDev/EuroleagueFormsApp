using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common
{
    [Serializable]
    public class Receiver
    {
        Socket socket;
        NetworkStream stream;
        BinaryFormatter formatter;
        public Receiver(Socket socket)
        {
            this.socket = socket;
            formatter = new BinaryFormatter();
            stream = new NetworkStream(socket);
        }
        public object Receive()
        {
            return formatter.Deserialize(stream);
        }
    }
}
