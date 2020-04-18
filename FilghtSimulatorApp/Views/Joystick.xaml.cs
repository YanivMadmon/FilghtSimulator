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
using System.Windows.Media.Animation;

namespace FilghtSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for Joystick.xaml
    /// </summary>
    public partial class Joystick : UserControl, INotifyPropertyChanged
    {
        public Point startPoint = new Point();

        public static readonly DependencyProperty RudderValProperty = DependencyProperty.Register("RudderVal", typeof(double), typeof(Joystick), null);
        public double RudderVal
        {
            get { return Convert.ToDouble(GetValue(RudderValProperty)); }
            set { SetValue(RudderValProperty, value); }
        }

        public static readonly DependencyProperty ElevatorValProperty = DependencyProperty.Register("ElevatorVal", typeof(double), typeof(Joystick), null);
        public double ElevatorVal
        {
            get { return Convert.ToDouble(GetValue(ElevatorValProperty)); }
            set { SetValue(ElevatorValProperty, value); }
        }


        public Joystick()
        {
            InitializeComponent();

        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        public void centerKnob_Completed(object sender, EventArgs e) {
            Storyboard sb = this.Knob.FindResource("CenterKnob") as Storyboard;
            sb.Stop(this);
            knobPosition.X = 0; 
            knobPosition.Y = 0;
            RudderVal = 0;
            ElevatorVal = 0;
        }


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
                Knob.CaptureMouse();
                double x = e.GetPosition(this).X - startPoint.X;
                double y = e.GetPosition(this).Y - startPoint.Y;
                if (Math.Sqrt(x * x + y * y) < ((Base.Width / 2) - (KnobBase.Width / 2)))
                {
                    knobPosition.X = x;
                    knobPosition.Y = y;
                    Normal();
                }
            }
        }

        private void Knob_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Knob.ReleaseMouseCapture();
            Storyboard sb = this.Knob.FindResource("CenterKnob") as Storyboard;
            sb.Begin(this,true);
            knobPosition.X = 0;
            knobPosition.Y = 0;
            RudderVal = 0;
            ElevatorVal = 0;
        }

        private void Knob_MouseLeave(object sender, MouseEventArgs e)
        {
            Knob.ReleaseMouseCapture();
            Storyboard sb = this.Knob.FindResource("CenterKnob") as Storyboard;
            sb.Begin(this, true);
            knobPosition.X = 0;
            knobPosition.Y = 0;
            RudderVal = 0;
            ElevatorVal = 0;
        }
        public void Normal()
        {
            double radKn = (Base.Width / 2) - (KnobBase.Width / 2);
            double x = knobPosition.X / radKn;
            double y = -(knobPosition.Y / radKn);
            RudderVal = x;
            ElevatorVal = y;


        }
    }
}
