using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilghtSimulatorApp.Model
{
    public interface IModel : INotifyPropertyChanged
    {
        void connect(string ip, int port);
        void disconnect();
        void start();

        string IndicatedHeadingDeg { get; set; }
        string GpsIndicatedVerticalSpeed { get; set; }
        string GpsIndicatedGroundSpeedKt { get; set; }
        string AirspeedIndicatorIndicatedSpeedKt { get; set; }
        string GpsIndicatedAltitudeFt { get; set; }
        string AttitudeIndicatorInternalRollDeg { get; set; }
        string AttitudeIndicatorInternalPitchDeg { get; set; }
        string AltimeterIndicatedAltitudeFt { get; set; }
    }
}
