﻿
using FilghtSimulatorApp;
using FilghtSimulatorApp.Model;
using FilghtSimulatorApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public MainViewModel MainViewModel { get; internal set; }

        public void Application_Startup(object sender, StartupEventArgs e)
        {
            //initialize communication
            // TCPclient tcpclient = new...

            MyModel Model = new MyModel(new MyTelnetClient());
            MainViewModel = new MainViewModel(Model);

            // Create the startup window
            MainWindow wnd = new MainWindow
            {
                // Do stuff here, e.g. to the window
                Title = "FlightGear Simulator"
            };
            // Show the window
            wnd.Show();
        }
    }
}   
