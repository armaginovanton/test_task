using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientServer_App
{
    class Program
    {
        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        const string ip = "127.0.0.1";
        const int port = 8080;

        static void Main(string[] args)
        {
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            socket.Bind(tcpEndPoint);
            socket.Listen(5);

            while (true)
            {
                Socket client = socket.Accept();
                Console.WriteLine("Клиент подключился");
                var buffer = new byte[256];
                var size = 0;
                var data = new StringBuilder();

                do
                {
                    size = client.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (client.Available > 0);

                Message message = new Message
                {
                    Id = 0,
                    Text = data.ToString(),
                    Ip = client.RemoteEndPoint.ToString(),
                    GetDateTime = DateTime.Now
                };

                DataBaseServer db = new DataBaseServer();
                int MessageID = db.Save(message);

                if (MessageID > 0)
                {
                    client.Send(Encoding.UTF8.GetBytes("1"));
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                    var commandKey = Console.ReadLine();
                    if (commandKey == "print")
                    {
                        Message msg = db.Get(MessageID);
                        Console.WriteLine("{1}>>> {0} ({2})", msg.Text, msg.Ip, msg.GetDateTime);
                    }
                }
                else
                {
                    client.Send(Encoding.UTF8.GetBytes("0"));
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                    Console.ReadLine();                    
                }                
            }
        }
    }
}
