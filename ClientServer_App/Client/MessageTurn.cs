using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientServer_App
{
    public class MessageTurn
    {
        public List<string> MessageList;
        private const string ip = "127.0.0.1";
        private const int port = 8080;

        public MessageTurn(List<string> messageList)
        {
            MessageList = messageList;
        }

        public void Send()
        {
            Socket socket;
            while (true)
            {
                if (MessageList.Count > 0)
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                        var message = MessageList.First<string>();

                        var data = Encoding.UTF8.GetBytes(message);

                        socket.Connect(tcpEndPoint);
                        socket.Send(data);

                        var buffer = new byte[256];
                        var size = 0;
                        var answer = new StringBuilder();

                        do
                        {
                            size = socket.Receive(buffer);
                            answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
                        } while (socket.Available > 0);

                        if (answer.ToString().Equals("1"))
                        {
                            Console.WriteLine("Сообщение <<{0}>> доставлено", message);
                            MessageList.RemoveAt(0);
                            File.Delete("MessageList.txt");
                            File.WriteAllLines("MessageList.txt", MessageList.ToArray());
                        }
                        socket.Shutdown(SocketShutdown.Both);
                    }
                    catch
                    {

                    }
                    finally
                    {
                        socket.Close();
                    }
                }
            }
        }
    }
}
