using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day07TravelListAli
{
    public class InvalidDataException : Exception
    {
        public InvalidDataException(string msg) : base(msg) { }
        public InvalidDataException(string msg, Exception inner) : base(msg, inner) { }
    }

    public class Trip
    {

        public Trip(string dataLine) // ex InvalidDataException
        {
            try
            {
                string[] data = dataLine.Split(';');
                if (data.Length != 5)
                {
                    throw new InvalidDataException("Invalid number of elements in line");
                }
                Destination = data[0];
                TravellerName = data[1];
                TravellerPassport = data[2];
                DateTime depDate = DateTime.ParseExact(data[3], "yyyy-MM-dd", CultureInfo.InvariantCulture); // ex
                DateTime retDate = DateTime.ParseExact(data[4], "yyyy-MM-dd", CultureInfo.InvariantCulture); // ex
                SetDepartureReturnDates(depDate, retDate);
            }
            catch (FormatException ex)
            {
                throw new InvalidDataException("Data format invalid in line", ex);
            }
        }

        public Trip(string destination, string travellerName, string travellerPassport, DateTime departureDate, DateTime returnDate)
        {
            Destination = destination;
            TravellerName = travellerName;
            TravellerPassport = travellerPassport;
            SetDepartureReturnDates(departureDate, returnDate);
        }

        private string _destination;
        public string Destination
        {
            get
            {
                return _destination;
            }
            set
            {
                if (!Regex.IsMatch(value, @"^[a-zA-Z0-9 \.]{2,30}$"))
                {
                    throw new InvalidDataException("Destinatin must be 2-30 characters long");
                }
                _destination = value;
            }
        }

        private string _travellerName;
        public string TravellerName
        {
            get
            {
                return _travellerName;
            }
            set
            {
                if (!Regex.IsMatch(value, @"^[a-zA-Z0-9 \.]{2,30}$"))
                {
                    throw new InvalidDataException("Traveller name must be 2-30 characters long");
                }
                _travellerName = value;
            }
        }

        private string _travellerPassport;
        public string TravellerPassport
        {
            get
            {
                return _travellerPassport;
            }
            set
            {
                if (!Regex.IsMatch(value, @"^[A-Z]{2}[0-9]{6}$"))
                {
                    throw new InvalidDataException("Passport must be in AA123456 format");
                }
                _travellerPassport = value;
            }
        }


        private DateTime _departureDate, _returnDate;
        public DateTime DepartureDate
        {
            get { return _departureDate; }
        }
        public DateTime ReturnDate
        {
            get { return _returnDate; }
        }

        public void SetDepartureReturnDates(DateTime dep, DateTime ret)
        {
            if (ret < dep)
            {
                throw new InvalidDataException("Return can't be before departure");
            }
            _departureDate = dep;
            _returnDate = ret;
        }


        public override string ToString()
        {
            return $"{TravellerName} ({TravellerPassport}) to {Destination} from {DepartureDate:d} to {ReturnDate:d}";
        }

        public string ToDataString()
        {
            return $"{Destination};{TravellerName};{TravellerPassport};{DepartureDate:yyyy-MM-dd};{ReturnDate:yyyy-MM-dd}";
        }


    }
}
