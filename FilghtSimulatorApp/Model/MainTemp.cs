using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilghtSimulatorApp.Model
{
    class MainTemp
    {
        //private myModel newModel;
        static public void Main(string[] args)
        {
          IModel newModel = new myModel(new myTelnetClient());
            newModel.connect("127.0.0.1", 5402);
            newModel.start();
        }
 
    }
}
