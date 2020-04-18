using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FilghtSimulatorApp.Model
{
    public class MyTelnetClient : ITelnetClient
    {
        private TcpClient clientSocket;
        private StreamWriter sw;
        private StreamReader sr;

        public void connect(string ip, int port)
        {
            clientSocket = new TcpClient();
            clientSocket.Connect(ip, port);
            Console.WriteLine("connect");
            sw = new StreamWriter(clientSocket.GetStream());
            sr = new StreamReader(clientSocket.GetStream());
        }

        public void disconnect()
        {
            sw.Close();
            sr.Close();
            clientSocket.Close();
        }

        public string read()
        {
            string data = "";
            if (sr != null)
            {
                data = sr.ReadLine(); ;
                return data;
            }
            return data;

        }

        public void write(string command)
        {
            if (sw != null)
            {
                sw.WriteLine(command);
                sw.Flush();
            }
        }
    }
}