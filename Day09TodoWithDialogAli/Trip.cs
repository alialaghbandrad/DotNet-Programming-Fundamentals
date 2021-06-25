using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day09TodoWithDialogAli
{
    public class InvalidDataException : Exception
    {
        public InvalidDataException(string msg) : base(msg) { }
        public InvalidDataException(string msg, Exception inner) : base(msg, inner) { }
    }

    public class Task
    {
        public Task(string dataLine) // ex InvalidDataException
        {
            try
            {
                string[] data = dataLine.Split(';');
                if (data.Length != 4)
                {
                    throw new InvalidDataException("Invalid number of elements in line");
                }
                Desc = data[0];
                Diff = Double.Parse(data[1]);
                DateTime depDate = DateTime.ParseExact(data[2], "yyyy-MM-dd", CultureInfo.InvariantCulture); // ex
                Status = data[3];
            }
            catch (FormatException ex)
            {
                throw new InvalidDataException("Data format invalid in line", ex);
            }
        }

        public Task(string desc, double diff, DateTime departureDate, string status)
        {
            
            Desc = desc;
            Diff = diff;
            DepartureDate = departureDate;
            Status = status;
        }

        private string _desc;
        public string Desc
        {
            get
            {
                return _desc;
            }
            set
            {
                if (!Regex.IsMatch(value, @"^[a-zA-Z0-9 \.]{2,30}$"))
                {
                    throw new InvalidDataException("Destinatin must be 2-30 characters long");
                }
                _desc = value;
            }
        }

        private double _diff;
        public double Diff
        {
            get
            {
                return _diff;
            }
            set
            {
                _diff = value;
            }
        }

        private string _status;
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                
                _status = value;
            }
        }

        private DateTime _departureDate;
        public DateTime DepartureDate
        {
            get
            {
                return _departureDate;
            }
            set
            {
                _departureDate = value;
            }
        }
        
        

        public override string ToString()
        {
            return $"{Desc} ({Diff}) on {DepartureDate:d} with status {Status}";
        }

        public string ToDataString()
        {
            return $"{Desc};{Diff};{DepartureDate:yyyy-MM-dd};{Status}";
        }



    }
}
