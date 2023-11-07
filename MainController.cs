using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace Client
{
    internal class MainController
    {
        string Host = Dns.GetHostName();
        TcpClient client = null;
        IPAddress serverAddr;
        Int32 port = 8888;
        List<string> numbers = new List<string>() { "1", "2", "3" };
        int i = 0;
        public MainController()
        {
            serverAddr = IPAddress.Loopback;
            client = new TcpClient();
            Task task = Task.Factory.StartNew(Connect);
        }

        public void OnButtonPush(object sender, RoutedEventArgs e)
        {
            if (client.Connected)
            {
                NetworkStream stream = client.GetStream();

                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine(numbers[i]);
                writer.Flush();
                i++;
                if (i == numbers.Count)
                    i = 0;
            }
        }

        public void SetHostByName(string name)
        {
            Host = name;
            try
            {
                serverAddr = IPAddress.Parse(Dns.GetHostEntry(Host).AddressList[1].ToString());
            }
            catch { }

        }

        public void ClearHost()
        {         
            serverAddr = IPAddress.Loopback;
        }

        void Connect()
        {
            while (true)
            {
                if (!client.Connected)
                {
                    try
                    {
                        client.Connect(serverAddr, port);
                    }
                    catch { }
                }
            }
        }
    }
}
