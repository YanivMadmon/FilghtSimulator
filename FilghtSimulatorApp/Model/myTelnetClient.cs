using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FilghtSimulatorApp.Model
{
    class myTelnetClient : ITelnetClient
    {
        private TcpClient clientSocket;
        private StreamWriter sw;
        private StreamReader sr;
        //string dataRead = null;

        public void connect(string ip, int port)
        {
            clientSocket = new TcpClient();
            clientSocket.Connect(ip, port);
            sw = new StreamWriter(clientSocket.GetStream());
            sr = new StreamReader(clientSocket.GetStream());
        }

        public void disconnect()
        {
            clientSocket.Close();
        }

        public string read()
        {
            string data= sr.ReadLine();
            return data;
        }

        public void write(string command)
        {
            sw.WriteLine(command);
            sw.Flush();
            //dataRead = sr.ReadLine();
        }
    }
}
