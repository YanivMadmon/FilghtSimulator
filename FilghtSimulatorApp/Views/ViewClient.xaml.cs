using FilghtSimulatorApp.ViewModels;
using FlightSimulatorApp;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace FilghtSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for ViewClient.xaml
    /// </summary>
     partial class ViewClient : UserControl
    {
        public ClientVM cvm; 
        public ViewClient()
        {
            InitializeComponent();

        }

        private void ConnectBottom_Click(object sender, RoutedEventArgs e)
        {
                cvm.model.connect(IPTextBox.Text, Int32.Parse(PortTextBox.Text));
                cvm.model.start();   
        }
        public void Init()
        {
            cvm = (Application.Current as App).MainViewModel.cvm;
        }

        private void IPTextBox_Initialized(object sender, EventArgs e)
        {
            IPTextBox.Text = ConfigurationManager.AppSettings.Get("IP");
        }

        private void PortTextBox_Initialized(object sender, EventArgs e)
        {
            PortTextBox.Text = ConfigurationManager.AppSettings.Get("PORT");
        }

        private void DisconnectBottom_Click(object sender, RoutedEventArgs e)
        {
            cvm.model.disconnect();
        }
    }
}
