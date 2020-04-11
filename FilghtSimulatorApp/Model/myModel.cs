using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FilghtSimulatorApp.Model
{
    class myModel : IModel
    {
        ITelnetClient telnetClient;
        volatile Boolean stop;
        public event PropertyChangedEventHandler PropertyChanged;
        Mutex mut;

        private string indicatedHeadingDeg;
        private string gpsIndicatedGroundSpeedKt;
        private string gpsIndicatedVerticalSpeed;
        private string airspeedIndicatorIndicatedSpeedKt;
        private string gpsIndicatedAltitudeFt;
        private string attitudeIndicatorInternalRollDeg;
        private string attitudeIndicatorInternalPitchDeg;
        private string altimeterIndicatedAltitudeFt;

        public myModel(ITelnetClient telnetClient) { this.telnetClient = telnetClient; this.stop = false; this.mut = new Mutex(); }
        public void connect(string ip, int port) {
            this.telnetClient.connect(ip, port);
            this.stop = false;
        }
        public void disconnect() {
            this.stop = true;
            telnetClient.disconnect();
        }

        public void start()
        {
            List<string> nativs = new List<string>();
            nativs.Add("/instrumentation/heading-indicator/indicated-heading-deg");
            nativs.Add("/instrumentation/gps/indicated-vertical-speed");
            nativs.Add("/instrumentation/gps/indicated-ground-speed-kt");
            nativs.Add("/instrumentation/airspeed-indicator/indicated-speed-kt");
            nativs.Add("/instrumentation/gps/indicated-altitude-ft");
            nativs.Add("/instrumentation/attitude-indicator/internal-roll-deg");
            nativs.Add("/instrumentation/attitude-indicator/internal-pitch-deg");
            nativs.Add("/instrumentation/altimeter/indicated-altitude-ft");

            new Thread(delegate ()
            {
                while (!this.stop)
                {
                    foreach (string s in nativs)
                    {
                        mut.WaitOne();
                        telnetClient.write("get" + s + "\n");

                        switch (s)
                        {
                            case "/instrumentation/heading-indicator/indicated-heading-deg":
                                this.indicatedHeadingDeg = telnetClient.read();
                                break;

                            case "/instrumentation/gps/indicated-vertical-speed":
                                this.gpsIndicatedVerticalSpeed = telnetClient.read();
                                break;

                            case "/instrumentation/gps/indicated-ground-speed-kt":
                                gpsIndicatedGroundSpeedKt = telnetClient.read();
                                break;

                            case "/instrumentation/airspeed-indicator/indicated-speed-kt":
                                airspeedIndicatorIndicatedSpeedKt = telnetClient.read();
                                break;

                            case "/instrumentation/gps/indicated-altitude-ft":
                                gpsIndicatedAltitudeFt = telnetClient.read();
                                break;

                            case "/instrumentation/attitude-indicator/internal-roll-deg":
                                attitudeIndicatorInternalRollDeg = telnetClient.read();
                                break;

                            case "/instrumentation/attitude-indicator/internal-pitch-deg":
                                attitudeIndicatorInternalPitchDeg = telnetClient.read();
                                break;

                            case "/instrumentation/altimeter/indicated-altitude-ft":
                                altimeterIndicatedAltitudeFt = telnetClient.read();
                                break;
                        }
                        mut.ReleaseMutex();
                    }

                    Thread.Sleep(250);// read the data in 4Hz
                }
            }).Start();
        }

        public string IndicatedHeadingDeg
        {
            get { return this.indicatedHeadingDeg; }
            set
            {
                if (this.indicatedHeadingDeg != value)
                {
                    indicatedHeadingDeg = value;
                    this.NotifyPropertyChanged("IndicatedHeadingDeg");
                }
            }
        }
        public string GpsIndicatedVerticalSpeed
        {
            get { return this.gpsIndicatedVerticalSpeed; }
            set
            {
                if (this.gpsIndicatedVerticalSpeed != value)
                {
                    gpsIndicatedVerticalSpeed = value;
                    this.NotifyPropertyChanged("GpsIndicatedVerticalSpeed");
                }
            }
        }
        public string GpsIndicatedGroundSpeedKt
        {
            get { return this.gpsIndicatedGroundSpeedKt; }
            set
            {
                if (this.gpsIndicatedGroundSpeedKt != value)
                {
                    gpsIndicatedGroundSpeedKt = value;
                    this.NotifyPropertyChanged("GpsIndicatedGroundSpeedKt");
                }
            }
        }
        public string AirspeedIndicatorIndicatedSpeedKt
        {
            get { return this.airspeedIndicatorIndicatedSpeedKt; }
            set
            {
                if (this.airspeedIndicatorIndicatedSpeedKt != value)
                {
                    airspeedIndicatorIndicatedSpeedKt = value;
                    this.NotifyPropertyChanged("AirspeedIndicatorIndicatedSpeedKt");
                }
            }
        }
        public string GpsIndicatedAltitudeFt
        {
            get { return this.gpsIndicatedAltitudeFt; }
            set
            {
                if (this.gpsIndicatedAltitudeFt != value)
                {
                    gpsIndicatedAltitudeFt = value;
                    this.NotifyPropertyChanged("GpsIndicatedAltitudeFt");
                }
            }
        }
        public string AttitudeIndicatorInternalRollDeg
        {
            get { return this.attitudeIndicatorInternalRollDeg; }
            set
            {
                if (this.attitudeIndicatorInternalRollDeg != value)
                {
                    attitudeIndicatorInternalRollDeg = value;
                    this.NotifyPropertyChanged("AttitudeIndicatorInternalRollDeg");
                }
            }
        }
        public string AttitudeIndicatorInternalPitchDeg
        {
            get { return this.attitudeIndicatorInternalPitchDeg; }
            set
            {
                if (this.attitudeIndicatorInternalPitchDeg != value)
                {
                    attitudeIndicatorInternalPitchDeg = value;
                    this.NotifyPropertyChanged("AttitudeIndicatorInternalPitchDeg");
                }
            }
        }
        public string AltimeterIndicatedAltitudeFt
        {
            get { return this.altimeterIndicatedAltitudeFt; }
            set
            {
                if (this.altimeterIndicatedAltitudeFt != value)
                {
                    altimeterIndicatedAltitudeFt = value;
                    this.NotifyPropertyChanged("AltimeterIndicatedAltitudeFt");
                }
            }
        }

        public void NotifyPropertyChanged(string propName) {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}