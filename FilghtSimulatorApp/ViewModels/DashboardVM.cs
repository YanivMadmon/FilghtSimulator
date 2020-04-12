using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilghtSimulatorApp.Model;
using INotifyPropertyChanged = FilghtSimulatorApp.Model.INotifyPropertyChanged;

namespace FilghtSimulatorApp.ViewModels
{


     public class DashboardVM : INotifyPropertyChanged
    {
        public IModel model;
        public event PropertyChangedEventHandler PropertyChanged;
       public DashboardVM(IModel m)
        {
            this.model = m;
            this.model.PropertyChanged +=
            delegate (Object sender, PropertyChangedEventArgs e) {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
        public string VM_IndicatedHeadingDeg
        {
            get { return model.IndicatedHeadingDeg; }
        }
        public string VM_GpsIndicatedVerticalSpeed
        {
            get { return model.GpsIndicatedVerticalSpeed; }
        }
        public string VM_GpsIndicatedGroundSpeedKt
        {
            get { return model.GpsIndicatedGroundSpeedKt; }
        }
        public string VM_AirspeedIndicatorIndicatedSpeedKt
        {
            get { return model.AirspeedIndicatorIndicatedSpeedKt; }
        }
        public string VM_GpsIndicatedAltitudeFt
        {
            get { return model.GpsIndicatedAltitudeFt; }
        }
        public string VM_AttitudeIndicatorInternalRollDeg
        {
            get { return model.AttitudeIndicatorInternalRollDeg; }
        }
        public string VM_AttitudeIndicatorInternalPitchDeg
        {
            get { return model.AttitudeIndicatorInternalPitchDeg; }
        }
        public string VM_AltimeterIndicatedAltitudeFt
        {
            get { return model.AltimeterIndicatedAltitudeFt; }
        }


        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }

    internal class pucbic
    {
    }
}
