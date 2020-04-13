﻿using FilghtSimulatorApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilghtSimulatorApp.ViewModels
{
     public class MainViewModel
    {
       public  DashboardVM dvm;
       public ClientVM cvm;
         public MainViewModel(myModel m)
        {
            dvm = new DashboardVM(m);
            cvm = new ClientVM(m);
        }
    }
}
