﻿using FilghtSimulatorApp.ViewModels;
using FilghtSimulatorApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlightSimulatorApp;

namespace FilghtSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for ViewDashboard.xaml
    /// </summary>
    public partial class ViewDashboard : UserControl
    {
         public DashboardVM dvm;
        public ViewDashboard()
        {

            InitializeComponent();

        }
        public void Init()
        {
            dvm = (Application.Current as App).MainViewModel.dvm;
            DataContext = dvm;
        }
    }
}

