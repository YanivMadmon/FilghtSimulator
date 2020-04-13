﻿using FilghtSimulatorApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilghtSimulatorApp.ViewModels
{
    class ControlVM : Model.INotifyPropertyChanged
    {
        IModel model;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}