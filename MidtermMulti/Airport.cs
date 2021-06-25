using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MidtermMulti
{
    class Airport
    {
        public Airport(string code, string city, double lat, double lng, int elevM) // throws ArgumentException
        {
            Code = code;
            City = city;
            Lat = lat;
            Lng = lng;
            ElevM = elevM;
        }

        private string _code; // storage
        public string Code
        { // property

            get
            {
                return _code;
            }
            set
            {
                if (!Regex.IsMatch(value, @"^[A-Z]{3}$"))
                {
                    throw new ArgumentException("Code must be exactly 3 uppercase letters");
                }
                _code = value;
            }
        }

        private string _city; // storage
        public string City
        { // property

            get
            {
                return _city;
            }
            set
            {
                // if (value.Length < 1 || value.Length > 50 || value.Contains(";"))
                if (!Regex.IsMatch(value, @"^[^;]{1,50}$")) 
                {
                    throw new ArgumentException("City must be 1-50 characters long, no semicolons");
                }
                _city = value;
            }
        }


        private double _lat; // storage
        public double Lat
        {
            get
            {
                return _lat;
            }
            set
            {
                if (value < -90 || value > 90)
                {
                    throw new ArgumentException("Latitudee must be from -90 to 90");
                }
                _lat = value;
            }
        }

        private double _lng; // storage
        public double Lng
        {
            get
            {
                return _lng;
            }
            set
            {
                if (value < -180 || value > 180)
                {
                    throw new ArgumentException("Longitude must be from -90 to 90");
                }
                _lng = value;
            }
        }


        private int _elevM; // storage
        public int ElevM
        {
            get
            {
                return _elevM;
            }
            set
            {
                if (value < -1000 || value > 1000)
                {
                    throw new ArgumentException("Elevation must be from -1000 to 1000 meters");
                }
                _elevM = value;
            }
        }


        public Airport(string dataLine)
        {                                     
            string[] data = dataLine.Split(';');                             
            if (data.Length != 5)
            {
                Logging.LogFailure?.Invoke("Airport data line must have 5 fields");     
                throw new InvalidDataException("Airport data line must have 5 fields");
            }
            Code = data[0]; // ex InvalidDataException
            City = data[1]; // ex InvalidDataException
            // out parameter cannot be a property                             
            if (!double.TryParse(data[2], out double lat))
            {
                Logging.LogFailure?.Invoke("Latitude in data line must be a double");    
                throw new InvalidDataException("Latitude in data line must be a double");
            }
            Lat = lat;  // Asigns output lat to a property
            // out parameter cannot be a property                             
            if (!double.TryParse(data[3], out double lng))
            {
                Logging.LogFailure?.Invoke("Longitude in data line must be a double");
                throw new InvalidDataException("Longitude in data line must be a double");
            }
            Lng = lng;  // Asigns output lng to a property
            // out parameter cannot be a property                             
            if (!int.TryParse(data[4], out int elevM))
            {
                Logging.LogFailure?.Invoke("Longitude in data line must be an int");
                throw new InvalidDataException("Longitude in data line must be an int");
            }
            ElevM = elevM;  // Asigns output lng to a property
        }

        public class InvalidDataException : Exception
        {
            public InvalidDataException(string msg) : base(msg) { }     
        }

        public override string ToString()
        {
            return $"{Code} is {City} at {Lat} lat / {Lng} lng at {ElevM} elevation";
        }

        // STEP 15.1: ToDataString()
        public virtual string ToDataString()                  
        {
            return $"{Code};{City};{Lat};{Lng};{ElevM}";
        }
    }
}
