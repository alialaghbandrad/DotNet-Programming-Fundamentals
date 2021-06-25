using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day01PeopleListInFileAli
{
    public class Person
    {

        public Person(string name, int age, string city) // throws ArgumentException
        {
            Name = name;
            Age = age;
            City = city;
        }


        // public String Name2 { get; set; } // property with storage and getters/setters no verification

        private string _name; // storage
        public string Name { // property

            get
            {
                return _name;
            }
            set
            {
                // if (value.Length < 2 || value.Length > 100 || value.Contains(";"))
                if (!Regex.IsMatch(value, @"^[^;]{2,100}$")) //, RegexOptions.IgnoreCase))
                {
                    throw new ArgumentException("Name must be 2-100 characters long, no semicolons");
                }
                _name = value;
            }
        }

        /*
        // a weird example of getter/setter
        private Random random = new Random();
        private int maxRandom = 100;
        public int SomeValue
        {
            get
            {
                return random.Next(1, maxRandom);
            }
            set
            {
                maxRandom = value;
            }
        } */

        private int _age; // storage
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 0 || value > 150)
                {
                    throw new ArgumentException("Age must be 0-150");
                }
                _age = value;
            }
        }

        private string _city;

        public string City // City 2-100 characters long, not containing semicolons
        { // property
            get
            {
                return _city;
            }
            set
            {
                //if (value.Length < 2 || value.Length > 100 || value.Contains(";"))
                if (!Regex.IsMatch(value, @"^[^;]{2,100}$")) //, RegexOptions.IgnoreCase))     // What does mean RegexOptions.IgnoreCase?
                {
                    throw new ArgumentException("City must be 0-100 characters long, no semicolons");
                }
                _city = value;

            }
        }

        public override string ToString()
        {
            return $"{Name} is {Age} from {City}";
        }
    }
}

