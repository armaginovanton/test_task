using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace ClientServer_App
{
    class Program
    {
        static string path = "MessageList.txt";

        static void Main(string[] args)
        {
            var list = new List<string>();

            try
            {
                list = File.ReadLines(path).ToList();
            }
            catch { }

            MessageTurn messageTurn = new MessageTurn(list);

            Thread myThread = new Thread(new ThreadStart(messageTurn.Send));
            myThread.Start();

            while (true)
            {
                string message = Console.ReadLine();
                messageTurn.MessageList.Add(message);
                File.Delete(path);
                File.WriteAllLines(path, messageTurn.MessageList.ToArray());
            }
        }
    }
}
