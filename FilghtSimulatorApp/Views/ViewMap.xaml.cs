using FilghtSimulatorApp.ViewModels;
using FlightSimulatorApp;
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

namespace FilghtSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for ViewMap.xaml
    /// </summary>
    public partial class ViewMap : UserControl
    {
        public MapVM mvm;
        public ViewMap()
        {
            InitializeComponent();
        }
        public void Init()
        {
            mvm = (Application.Current as App).MainViewModel.mvm;
            DataContext = mvm;
        }
    }


}
