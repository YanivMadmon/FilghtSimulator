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
using System.ComponentModel;
using FilghtSimulatorApp.ViewModels;
using FlightSimulatorApp;

namespace FilghtSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for Joystick.xaml
    /// </summary>
    public partial class Joystick : UserControl, INotifyPropertyChanged
    {
        public Point startPoint = new Point();
        private string xstring;
        private string ystring;
        public string yDouble;


        public string xString
        {
            get { return this.xstring; }
            set
            {
                if (this.xstring != value)
                {
                    this.xstring = value;
                    this.NotifyPropertyChanged("xString");
                }
            }
        }
        public string yString
        {
            get { return this.ystring; }
            set
            {
                if (this.ystring != value)
                {
                    this.ystring = value;
                    this.NotifyPropertyChanged("yString");
                }
            }

        }

        public ControlVM convm;

        public Joystick()
        {
            InitializeComponent();
            xString = "0.00";
            yString = "0.00";


        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        public void centerKnob_Completed(object sender, EventArgs e) { }


        private void Knob_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                startPoint = e.GetPosition(this);
            }
        }

        private void Knob_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                double x = e.GetPosition(this).X - startPoint.X;
                double y = e.GetPosition(this).Y - startPoint.Y;
                if (Math.Sqrt(x * x + y * y) < ((Base.Width / 2) - (KnobBase.Width / 2)))
                {
                    knobPosition.X = x;
                    knobPosition.Y = y;
                    normal();
                }
            }
        }

        private void Knob_MouseUp(object sender, MouseButtonEventArgs e)
        {
            knobPosition.X = 0;
            knobPosition.Y = 0;
            xString = "0.00";
            yString = "0.00";
        }

        private void Knob_MouseLeave(object sender, MouseEventArgs e)
        {
            knobPosition.X = 0;
            knobPosition.Y = 0;
            xString = "0.00";
            yString = "0.00";
        }
        public void normal()
        {
            double radKn = (Base.Width / 2) - (KnobBase.Width / 2);
            double x = knobPosition.X / radKn;
            double y = -(knobPosition.Y / radKn);
            xString = System.Math.Round(x, 2).ToString();
            yString = System.Math.Round(y, 2).ToString();

        }
    }
}
