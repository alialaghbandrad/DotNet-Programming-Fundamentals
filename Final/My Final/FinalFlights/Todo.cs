using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day09TodoWithDialog
{
    public class Todo
    {

        private string _task;
        private int _difficulty;
        private DateTime _dueDate;
        private Status _taskStatus;
        public enum Status
        {
            Pending,
            Done,
            Delegated
        }

        public Todo(string task, int difficulty, DateTime dueDate, Status taskStatus)
        {
            Task = task;
            Difficulty = difficulty;
            DueDate = dueDate;
            TaskStatus = taskStatus;
        }

        public Todo(string line)
        {
            try
            {
                var str = line.Split(';'); // ex ArgumentOutOfRangeException, ArgumentException
                if (str.Length == 4)
                {
                    Task = str[0];
                    try
                    {
                        Difficulty = int.Parse(str[1]); // ex 
                    }
                    catch (Exception ex) when (ex is ArgumentNullException || ex is ArgumentException || ex is FormatException || ex is OverflowException)
                    {
                        throw new InvalidInputException("Dificullty should an interger");
                    }
                    try
                    {
                        DueDate = DateTime.ParseExact(str[2], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    }
                    catch (Exception ex) when (ex is ArgumentNullException || ex is FormatException)
                    {
                        throw new InvalidInputException(ex.Message);
                    }
                    try
                    {
                        TaskStatus = (Status)Enum.Parse(typeof(Status), str[3], true);
                    }
                    catch (Exception ex) when (ex is ArgumentNullException || ex is ArgumentException || ex is OverflowException)
                    {
                        throw new InvalidInputException(ex.Message);
                    }
                }
                else
                {
                    throw new InvalidInputException("Data string should be 4 items long.");
                }
            }
            catch (Exception ex) when (ex is ArgumentOutOfRangeException || ex is ArgumentException)
            {
                throw new InvalidInputException("Data string is invalid");
            }
        }

        public string Task
        {
            get
            {
                return _task;
            }
            set
            {
                Match m = Regex.Match(value, @"[^;]{1,100}");
                if (!m.Success)
                {
                    throw new InvalidInputException("Task is 1-100 characters long and no semicolon. ");
                }
                _task = value;
            }
        }

        public int Difficulty
        {
            get
            {
                return _difficulty;
            }
            set
            {
                if (value < 1 || value > 5)
                {
                    throw new InvalidInputException("Difficulty is between 1 and 5.");
                }
                _difficulty = value;
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
                    throw new InvalidInputException("Due Date is between 1900 and 2100.");
                }
                _dueDate = value;
            }
        }

        public string DueDateCurrentCulture
        {
            get
            {
                return $"{_dueDate:d}";
            }
        }

        public Status TaskStatus
        {
            get
            {
                return _taskStatus;
            }
            set
            {
                _taskStatus = value;
            }
        }

        public override string ToString()
        {
            return $"{_task} by {_dueDate:d} / difficulty: {_difficulty}, {_taskStatus}";
        }

        public string ToDataString()
        {
            return $"{_task};{_difficulty};{_dueDate:yyyy-MM-dd};{_taskStatus}";
        }

    }
}
