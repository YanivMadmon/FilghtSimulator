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
using System.Threading;
using FilghtSimulatorApp.ViewModels;
using FlightSimulatorApp;

namespace FilghtSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for ViewControl.xaml
    /// </summary>
    public partial class ViewControl : UserControl
    {
        public ControlVM convm;

        public ViewControl()
        {
            InitializeComponent();
            DataContext = this.Joy;
        }
        public void Init()
        {
            convm = (Application.Current as App).MainViewModel.convm;
            DataContext = convm;
        }

    }

}
