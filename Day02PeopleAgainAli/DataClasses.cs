using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02PeopleAgainAli
{
    // STEP 13: Create PeopleFactory Class
    public static class PeopleFactory                 // Alternative for public Person(string dataLine) {...} , public Teacher(string dataLine) : base() {...} , public Student(string dataLine) {...}
    {
        public static Person CreatePersonFromDataLine(string line)
        {
            string[] data = line.Split(';');
            string type = data[0];
            switch (type)
            {
                case "Person":
                    {
                        if (data.Length != 3)
                        {
                            throw new InvalidParameterException("Person data line must have 3 fields");
                        }
                        string name = data[1]; // ex InvalidParameterException
                                               // out parameter cannot be a property
                        if (!int.TryParse(data[2], out int age))
                        {
                            throw new InvalidParameterException("Age in data line must be an integer");
                        }
                        return new Person(name, age);
                    }
                case "Teacher":
                    {
                        if (data.Length != 5)
                        {
                            throw new InvalidParameterException("Teacher data line must have 5 fields");
                        }
                        // some unfortunate code duplication here, we could remove it but not sure it's worth it
                        string name = data[1];
                        int age; // out parameter cannot be a property
                        if (!int.TryParse(data[2], out age))
                        {
                            throw new InvalidParameterException("Age in data line must be an integer");
                        }
                        // parse the rest of fields
                        string subject = data[3];
                        int yoe;
                        if (!int.TryParse(data[4], out yoe))
                        {
                            throw new InvalidParameterException("Years of experience in data line must be an integer");
                        }
                        return new Teacher(name, age, subject, yoe);
                    }

                case "Student":
                    {
                        if (data.Length != 5)
                        {
                            throw new InvalidParameterException("Student data line must have 5 fields");
                        }
                        // some unfortunate code duplication here, we could remove it but not sure it's worth it
                        string name = data[1];
                        int age; // out parameter cannot be a property
                        if (!int.TryParse(data[2], out age))
                        {
                            throw new InvalidParameterException("Age in data line must be an integer");
                        }
                        // parse the rest of fields
                        string program = data[3];
                        double gpa;
                        if (!double.TryParse(data[4], out gpa))
                        {
                            throw new InvalidParameterException("GPA in data line must be numerical");
                        }
                        return new Student(name, age, program, gpa);
                    }
                default:
                    throw new InvalidParameterException("Don't know how to make " + type);
            }
        }
    }


    // ** STEP 1.1: Partial, InvalidParameterException
    public class InvalidParameterException : Exception
    {
        public InvalidParameterException(string msg) : base(msg) { }         // P.S. base(msg) is the call to the constructor of parent class
    }

    // ** STEP 1: Class Person **
    public class Person
    {
        // STEP 9: Add protected Person() { } 
        protected Person() { }          // For Teacher : base() inheritence          // why we need an empty protected Person()????? Why do we need protected Person() { }  ??????
        // END OF STEP 9
        
        // ** STEP 1.3: Person constructor. Calls seters **
        public Person(string name, int age)     // InvalidParameterException        // How many Person()???????
        {
            Name = name;
            Age = age;
        }
        
        // STEP 7: Second constructor of Person() 
        public Person(string dataLine) {                                     // How many Person()??????
            string[] data = dataLine.Split(';');                             // What is split doing?????
            if (data.Length !=3)
            {
                Logging.LogFailure?.Invoke("Person data line must have 3 fields");     // STEP 17.7 
                throw new InvalidParameterException("Person data line must have 3 fields");
            }
            if (data[0] != "Person")   // double-check if this line describes a person      // Should data[0] be equal to string "Person" ?????
            {
                Logging.LogFailure?.Invoke("Data line does not describe Person");     // STEP 17.8 
                throw new InvalidParameterException("Data line does not describe Person");
            }
            Name = data[1]; // ex InvalidParamaterException
            // out parameter cannot be a property                             // What does this mean??????
            if (!int.TryParse(data[2], out int age))
            {
                Logging.LogFailure?.Invoke("Age in data line must be an integer");    // STEP 17.9 
                throw new InvalidParameterException("Age in data line must be an integer");
            }
            Age = age;  // Asigns output age to a property
        }
        // END OF STEP 7
        
        
        // ** STEP 1.1: Name get & set **
        private string _name; // storage
        public string Name
        {
            get
            { // 1-50 characters, no semicolons
                return _name;
            }
            set
            {
                if (value.Length < 1 || value.Length > 50 || value.Contains(";"))
                {
                    Logging.LogFailure?.Invoke("Name must be 1-50 characters, no semicolons");
                    throw new InvalidParameterException("Name must be 1-50 characters, no semicolons");
                }
                _name = value; 
            }
        }

        // ** STEP 1.2: Age get & set **
        private int _age;
        public int Age
        { // 0-150
            get
            {
                return _age;
            }
            set
            {
                if (value < 0 || value > 150)
                {
                    Logging.LogFailure?.Invoke("Age must be 0-150");
                    throw new InvalidParameterException("Age must be 0-150");
                }
                _age = value;
            }
        }

        // ** STEP 1.4: ToString **
        public override string ToString()
        {
            return $"Person: {Name} is {Age} y/o";
        }

        // STEP 15.1: ToDataString()
        public virtual string ToDataString()                  // Why virtual? not override????????
        {
            return $"Person;{Name};{Age}";
        }

    }
    // ** END OF STEP 1 **


    // ** STEP 2: Class Teacher : Person **
    class Teacher : Person
    {
        // STEP 8: Second constructor of Teacher
       public Teacher(string dataLine) : base()
        {
            string[] data = dataLine.Split(';');
            if (data.Length != 5)
            {
                throw new InvalidParameterException("Teacher data line must have 5 fields");
            }
            if (data[0] != "Teacher")
            {
                throw new InvalidParameterException("Data line does not describe Teacher");
            }
            // some unfortunate code duplication here, we could remove it but not sure it's worth it
            Name = data[1]; // Setter
            int age; // out parameter cannot be a property
            if (!int.TryParse(data[2], out age))
            {
                throw new InvalidParameterException("Age in data line must be an integer");
            }
            Age = age; // Setter
            // parse the rest of fields
            Subject = data[3];
            int yoe;
            if (!int.TryParse(data[4], out yoe))
            {
                throw new InvalidParameterException("Years of experience in data line must be an integer");
            }
            YearsOfExperience = yoe;
        }
        // ** END OF STEP 8 **


        // ** STEP 2.1: Teacher constructor **
        public Teacher(string name, int age, string subject, int yoe) : base(name, age)
        {
            Subject = subject;
            YearsOfExperience = yoe;
        }

        // ** STEP 2.2: Subject get & set **
        private string _subject;
        public string Subject
        { // 1-50 characters, no semicolons
            get
            {
                return _subject;
            }
            set
            {
                if (value.Length < 1 || value.Length > 50 || value.Contains(";"))
                {
                    throw new InvalidParameterException("Subject must be 1-50 characters, no semicolons");
                }
                _subject = value;
            }
        }

        // ** STEP 2.3: Experience get & set **
        private int _yearsOfExperience;
        public int YearsOfExperience
        { // 0-100
            get
            {
                return _yearsOfExperience;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new InvalidParameterException("Years of experience must be 0-100");
                }
                _yearsOfExperience = value;
            }
        }

        // ** STEP 2.4: ToString **
        public override string ToString()
        {
            return $"Teacher: {Name} is {Age} y/o, teaching {Subject} since {YearsOfExperience} years";
        }

        // STEP 15.2: ToDataString()
        public override string ToDataString()
        {
            return $"Teacher;{Name};{Age};{Subject};{YearsOfExperience}";
        }

    }
    // ** END OF STEP 2 **


    // ** STEP 3: Class Student : Person**
    class Student : Person
    {
        // ** STEP 3.1: Student constructor **
        public Student(string name, int age, string program, double gpa) : base(name, age)
        {
            Program = program;
            GPA = gpa;
        }
        
        // STEP 10: Second constructor of Student
        public Student(string dataLine)                  // Why doesn't have : base() ??????
        {
            string[] data = dataLine.Split(';');
            if (data.Length != 5)
            {
                throw new InvalidParameterException("Student data line must have 5 fields");
            }
            if (data[0] != "Student")
            {
                throw new InvalidParameterException("Data line does not describe Student");
            }
            // some unfortunate code duplication here, we could remove it but not sure it's worth it
            Name = data[1];
            int age; // out parameter cannot be a property
            if (!int.TryParse(data[2], out age))
            {
                throw new InvalidParameterException("Age in data line must be an integer");
            }
            Age = age;
            // parse the rest of fields
            Program = data[3];
            double gpa;
            if (!double.TryParse(data[4], out gpa))
            {
                throw new InvalidParameterException("GPA in data line must be numerical");
            }
            GPA = gpa;
        }
        // ** END OF STEP 10
        

        // ** STEP 3.2: Program get & set **
        private string _program;
        public string Program
        { // 1-50 characters, no semicolons
            get
            {
                return _program;
            }
            set
            {
                if (value.Length < 1 || value.Length > 50 || value.Contains(";"))
                {
                    throw new InvalidParameterException("Program must be 1-50 characters, no semicolons");
                }
                _program = value;
            }
        }

        // ** STEP 3.3: GPA get & set **
        private double _gpa;
        public double GPA
        { // 0-4.3
            get
            {
                return _gpa;
            }
            set
            {
                if (value < 0 || value > 4.3)
                {
                    throw new InvalidParameterException("GPA must be 0-4.3");
                }
                _gpa = value;
            }
        }

        // ** STEP 3.4: ToString **
        public override string ToString()
        {
            return $"Student: {Name} is {Age} y/o, studying {Program}, has {GPA} GPA";
        }

        // STEP 15.3: ToDataString()
        public override string ToDataString()
        {
            return $"Student;{Name};{Age};{Program};{GPA}";
        }

    }

}
