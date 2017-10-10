using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer
{
    class Program
    {
        static void Main(string[] args)
        {

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3000));
            socket.Listen(0);
            var client = socket.Accept();
            var buffer = Encoding.UTF8.GetBytes("Hello nodejs I am c# server");
            client.Send(buffer, 0, buffer.Length, 0);
            buffer = new byte[255];
            int rec = client.Receive(buffer, 0, buffer.Length, 0);
            Array.Resize(ref buffer, rec);
            Console.WriteLine("Recived:" + Encoding.UTF8.GetString(buffer));
            client.Close();
            socket.Close();

           
        }

    }
}
