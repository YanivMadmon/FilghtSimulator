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
        public TcpClient clientSocket;
        private StreamWriter sw;
        private StreamReader sr;
        private Boolean isConnect = false;

        public void connect(string ip, int port)
        {
            try
            {
                if (!isConnect)
                {
                    clientSocket = new TcpClient();
                    var res = clientSocket.BeginConnect(ip, port, null, null);
                    var success = res.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));
                    if (!success)
                    {
                        throw new Exception("The connect is failed");
                    }

                    clientSocket.EndConnect(res);
                    sw = new StreamWriter(clientSocket.GetStream());
                    sr = new StreamReader(clientSocket.GetStream());
                    isConnect = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void disconnect()
        {
            sw.Close();
            sr.Close();
            clientSocket.Close();
            isConnect = false;
        }

        public string read()
        {
            string data = "";
            try
            {
                if (sr != null)
                {
                    data = sr.ReadLine(); ;
                    return data;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return data;
        }

        public void write(string command)
        {
            try
            {
                if (sw != null)
                {
                    sw.WriteLine(command);
                    sw.Flush();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}