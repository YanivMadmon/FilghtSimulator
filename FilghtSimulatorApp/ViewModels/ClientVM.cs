using FilghtSimulatorApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilghtSimulatorApp.ViewModels
{
     public class ClientVM
    {
       public IModel model;
        public ClientVM(myModel m)
        {
            this.model = m;
        }

     }
}
