using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalFlights
{
    public class Filght
    {
        private DateTime _dueDate;
        private string _fromCode;
        private string _toCode;
        private Type _typeStatus;
        private int _passengers;
        
        public enum Type
        {
            Domestic,
            International
        }

        public Filght(DateTime dueDate, string fromCode, string toCode, Type typeStatus, int passengers)
        {
            DueDate = dueDate;
            FromCode = fromCode;
            ToCode = toCode;
            Passengers = passengers;
            TypeStatus = typeStatus;
        }

        public Filght(string line)
        {
            try
            {
                var str = line.Split(';'); // ex ArgumentOutOfRangeException, ArgumentException
                if (str.Length == 5)
                {
                    
                    try
                    {
                        DueDate = DateTime.ParseExact(str[0], "yyyy-MM-dd", CultureInfo.InvariantCulture); // ex 
                    }
                    catch (Exception ex) when (ex is ArgumentNullException || ex is FormatException)
                    {
                        throw new InvalidInputException(ex.Message);
                    }

                    FromCode = str[1];

                    ToCode = str[2];           

                    try
                    {
                        TypeStatus = (Type)Enum.Parse(typeof(Type), str[3], true);
                    }
                    catch (Exception ex) when (ex is ArgumentNullException || ex is ArgumentException || ex is OverflowException)
                    {
                        throw new InvalidInputException(ex.Message);
                    }
  
                    try
                    {
                        Passengers = int.Parse(str[4]); // ex 
                    }
                    catch (Exception ex) when (ex is ArgumentNullException || ex is ArgumentException || ex is FormatException || ex is OverflowException)
                    {
                        throw new InvalidInputException("Passengers should an interger");
                    }
                    
                }
                else
                {
                    throw new InvalidInputException("Data string should be 5 items long.");
                }
            }
            catch (Exception ex) when (ex is ArgumentOutOfRangeException || ex is ArgumentException)
            {
                throw new InvalidInputException("Data string is invalid");
            }
        }

        public string FromCode
        {
            get
            {
                return _fromCode;
            }
            set
            {
                Match m = Regex.Match(value, @"[^;]{3,5}");
                if (!m.Success)
                {
                    throw new InvalidInputException("From Code is 3-5 characters long and no semicolon. ");
                }
                _fromCode = value;
            }
        }

        public string ToCode
        {
            get
            {
                return _toCode;
            }
            set
            {
                Match m = Regex.Match(value, @"[^;]{3,5}");
                if (!m.Success)
                {
                    throw new InvalidInputException("To Code is 3-5 characters long and no semicolon. ");
                }
                _toCode = value;
            }
        }

        public int Passengers
        {
            get
            {
                return _passengers;
            }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new InvalidInputException("Passengers is between 1 and 200.");
                }
                _passengers = value;
            }
        }

        public DateTime DueDate
        {
            get
            {
                return _dueDate;
            }
            set
            {
                if (value.Year < 1900 || value.Year > 2100)
                {
                    throw new InvalidInputException("Date is between 1900 and 2100.");
                }
                _dueDate = value;
            }
        }

        public string DateCurrentCulture
        {
            get
            {
                return $"{_dueDate:d}";
            }
        }

        public Type TypeStatus
        {
            get
            {
                return _typeStatus;
            }
            set
            {
                _typeStatus = value;
            }
        }

        public override string ToString()
        {
            return $"from {_fromCode} to {_toCode} on {_dueDate:d} with {_passengers} passengers, {_typeStatus}";
        }

        public string ToDataString()
        {
            return $"{_dueDate:yyyy-MM-dd};{_fromCode};{_toCode};{_typeStatus};{_passengers}";
        }

    }
}
