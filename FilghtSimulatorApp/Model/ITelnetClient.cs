﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilghtSimulatorApp.Model
{
    public interface ITelnetClient
    {
        void Connect(string ip, int port);
        void Write(string command);
        string Read();  // blocking call
        void Disconnect();
    }
}
