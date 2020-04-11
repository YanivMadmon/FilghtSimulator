using FilghtSimulatorApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilghtSimulatorApp.ViewModels
{
    public class MainViewModel
    {
       private DashboardVM dvm;
        public MainViewModel(IModel m)
        {
            dvm = new DashboardVM(m);
        }
    }
}
