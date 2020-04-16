using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FilghtSimulatorApp.Model
{
    public class myModel : IModel
    {
        ITelnetClient telnetClient;
        volatile Boolean stop;
        public event PropertyChangedEventHandler PropertyChanged;
        Mutex mut;

        private string error="test";
        private string indicatedHeadingDeg;
        private string gpsIndicatedGroundSpeedKt;
        private string gpsIndicatedVerticalSpeed;
        private string airspeedIndicatorIndicatedSpeedKt;
        private string gpsIndicatedAltitudeFt;
        private string attitudeIndicatorInternalRollDeg;
        private string attitudeIndicatorInternalPitchDeg;
        private string altimeterIndicatedAltitudeFt;
        private string latitude;
        private string longitude;
        private string location;



        public myModel(ITelnetClient telnetClient)
        {
            this.telnetClient = telnetClient;
            this.stop = false; this.mut = new Mutex();
        }
        public void connect(string ip, int port)
        {
            this.telnetClient.connect(ip, port);
            this.stop = false;
        }
        public void disconnect()
        {
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
            nativs.Add("/position/latitude-deg");
            nativs.Add("/position/longitude-deg");

            new Thread(delegate ()
            {
                while (!this.stop)
                {
                    foreach (string s in nativs)
                    {
                        mut.WaitOne();
                        Console.WriteLine("get " + s + "\n");
                        telnetClient.write("get " + s + "\n");

                        switch (s)
                        {
                            case "/instrumentation/heading-indicator/indicated-heading-deg":
                                this.IndicatedHeadingDeg = Read();
                                break;

                            case "/instrumentation/gps/indicated-vertical-speed":
                                this.GpsIndicatedVerticalSpeed = telnetClient.read();
                                break;

                            case "/instrumentation/gps/indicated-ground-speed-kt":
                                GpsIndicatedGroundSpeedKt = Read();
                                break;

                            case "/instrumentation/airspeed-indicator/indicated-speed-kt":
                                AirspeedIndicatorIndicatedSpeedKt = Read();
                                break;

                            case "/instrumentation/gps/indicated-altitude-ft":
                                GpsIndicatedAltitudeFt = Read();
                                break;

                            case "/instrumentation/attitude-indicator/internal-roll-deg":
                                AttitudeIndicatorInternalRollDeg = Read();
                                break;

                            case "/instrumentation/attitude-indicator/internal-pitch-deg":
                                AttitudeIndicatorInternalPitchDeg = Read();
                                break;

                            case "/instrumentation/altimeter/indicated-altitude-ft":
                                AltimeterIndicatedAltitudeFt = Read();
                                break;

                            case "/position/latitude-deg":
                                Latitiude = Read();
                                break;

                            case "/position/longitude-deg":
                                Longitude = Read();
                                break;

                            default: 
                                break;
                        }

                        mut.ReleaseMutex();


                    }
                    mut.WaitOne();
                    Location = Convert.ToDouble(Latitiude) + "," + Convert.ToDouble(Longitude);
                    mut.ReleaseMutex();
                    Thread.Sleep(250);// read the data in 4Hz
                }
            }).Start();
        }




        public string Read()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var data = telnetClient.read();
            if(sw.ElapsedMilliseconds>10000)
            {
                Error = "The server is not responding";
                return data;
            }
            return data;
            
        }

        public string Error
        {
            get { return this.error; }
            set
            {
                error = value;
                this.NotifyPropertyChanged("Error");
            }
        }
        public string IndicatedHeadingDeg
        {
            get { return this.indicatedHeadingDeg; }
            set
            {
                indicatedHeadingDeg = value;
                this.NotifyPropertyChanged("IndicatedHeadingDeg");
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
        public string Latitiude
        {
            get { return this.latitude; }
            set
            {
                if (this.latitude != value)
                {
                    latitude = value;
                    this.NotifyPropertyChanged("Latitiude");
                }
            }
        }
        public string Longitude
        {
            get { return this.longitude; }
            set
            {
                if (this.longitude != value)
                {
                    longitude = value;
                    this.NotifyPropertyChanged("Longitude");
                }
            }
        }
        public string Location
        {
            get { return this.location; }
            set
            {
                if (this.location != value)
                {
                    location = value;
                    this.NotifyPropertyChanged("Location");
                }
            }
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public string throttle;
        public string aileron;
        public string rudder;
        public string elevator;

        public void updateThrottle(String value)
        {
            throttle = value;
            telnetClient.write("set /controls/engines/current-engine/throttle " + value + "\n");
            telnetClient.read();
        }

        public void updateAileron(String value)
        {
            aileron = value;
            telnetClient.write("set /controls/flight/aileron " + value + "\n");
            telnetClient.read();
        }

        public void updateRudder(String value)
        {
            rudder = value;
            telnetClient.write("set /controls/flight/rudder " + value + "\n");
            telnetClient.read();
        }

        public void updateElevator(String value)
        {
            elevator = value;
            telnetClient.write("set /controls/flight/elevator " + value + "\n");
            telnetClient.read();
        }
    }
}