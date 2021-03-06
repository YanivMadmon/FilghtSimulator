﻿using FilghtSimulatorApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilghtSimulatorApp.ViewModels
{
    public class ControlVM : INotifyPropertyChanged
    {
        private MyModel model;

        public ControlVM(MyModel m)
        {
            this.model = m;
            this.model.PropertyChanged +=
            delegate (Object sender, PropertyChangedEventArgs e) {
            NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        public string VM_throttle
        {
            set { if (model.throttle != value) { model.UpdateThrottle(value);} }
        }

        public string VM_aileron
        {
            set { if (model.aileron != value) { model.UpdateAileron(value); } }
        }

        public string VM_elevator
        {
            set { if (model.elevator != value) { model.UpdateElevator(value); } }
        }

        public string VM_rudder
        {
            set { if (model.rudder != value) { model.UpdateRudder(value); } }
        }
    }
}