
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

namespace FilghtSimulatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void ViewDashboard_Loaded(object sender, RoutedEventArgs e)
        {
           this.ViewDashboard.Init();
        }

        private void ViewClient_Loaded(object sender, RoutedEventArgs e)
        {
            this.ViewClient.Init();
        }

        private void ViewMap_Loaded(object sender, RoutedEventArgs e)
        {
            this.ViewMap.Init();

        }

        private void ViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.ViewControl.Init();
        }
    }
}
