using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02PeopleAgainAli
{
    class Program
    {
        // STEP 5: const ReadDataFromFile()
        const string DataFileName = @"..\..\people.txt";

        // STEP 6: Create ReadDataFromFile()
        static void ReadDataFromFile()
        {
            // It is okay to read all data at once if the number of lines is reasonably small,
            // e.g. less than 10,000. Otherise use a loop to read one line at a time.
            try
            {
                string[] linesArray = File.ReadAllLines(DataFileName);
                foreach (string line in linesArray)
                {
                    try
                    {
                        PeopleList.Add(PeopleFactory.CreatePersonFromDataLine(line));
                        /*
                        string type = line.Split(';')[0];
                        switch (type)
                        {
                            case "Person":
                                Person p = new Person(line);
                                PeopleList.Add(p);
                                MessageHandler?.Invoke("Person created"); break;                // STEP 12.1: PARTIAL (call method of MessageHandler)
                            case "Teacher":                                                     // MessageHandler?.Invoke("Person created"); break; EQUEVALENT TO if (MessageHandler != null) {MessageHandler("Person created"); } break;
                                Teacher t = new Teacher(line);
                                PeopleList.Add(t);
                                MessageHandler?.Invoke("Teacher created"); break;              // STEP 12.1: PARTIAL (call method of MessageHandler)
                            case "Student":
                                Student s = new Student(line);
                                PeopleList.Add(s);
                                MessageHandler?.Invoke("Student created"); break;             // STEP 12.1: PARTIAL (call method of MessageHandler)
                            default:
                                break;
                        }*/
                    }
                    catch (InvalidParameterException ex)
                    {
                        Console.WriteLine($"Error parsing line: {ex.Message}\n >> {line}");
                        if (MessageHandler != null) { MessageHandler("Error creating object"); }      // STEP 12.1: PARTIAL (call method of MessageHandler)
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
            }
            catch (SystemException ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
            }
        }

        public static List<Person> PeopleList = new List<Person>();

        // End of STEP 6


        // STEP 11: Delegate

        // delegate type declaration
        public delegate void HandleLogMessageDelegateType(string msg);
        // reference variable of delegate type
        public static HandleLogMessageDelegateType MessageHandler;

        public static void JustPrintTheMessage(string m)
        {
            Console.WriteLine("MESSAGE: " + m);
        }

        public static void FancyMessagePrint(string m)
        {
            Console.WriteLine($"@@@@@@@@@@@@@@@ FANCY: {m} @@@@@@@@@@@");
        }
        // END OF STEP 11


        // STEP 13.2 PrintByType()
        static void PrintByType()
        {
            Console.WriteLine("=== Students only ===");
            foreach (Person p in PeopleList)
            {
                if (p is Student)
                {
                    Console.WriteLine(p);
                }
            }
            Console.WriteLine("=== Teachers only ===");
            foreach (Person p in PeopleList)
            {
                if (p is Teacher)
                {
                    Console.WriteLine(p);
                }
            }
            Console.WriteLine("=== Persons only ===");
            foreach (Person p in PeopleList)
            {
                // only and exactly Person
                if (p.GetType().Equals(typeof(Person)))    // Same as: if (p is Person && !(p is Student) && !(p is Teacher))
                {
                    Console.WriteLine(p);
                }
            }
        }

        // STEP 14: 14.1 PrintStatistics()
        static void PrintStatistics()
        {
            // get a subset of People - only Students and put them in studentsList
            List<Student> studentsList = PeopleList.Where(p => p is Student).Cast<Student>().ToList();
            double gpaSum = studentsList.Sum(s => s.GPA);
            double gpaAvg = gpaSum / studentsList.Count;
            // 3.983 => 3.98,   3.987 => 3.99
            Console.WriteLine("Average is {0:0.##}", gpaAvg);  // format with 2 decimal points
            // sort by GPA
            var sortedList = studentsList.OrderBy(s => s.GPA).ToList();
            double median;
            if (sortedList.Count % 2 == 1) // odd number of item
            {
                median = sortedList[sortedList.Count / 2].GPA;
            }
            else
            { // even number of items
                int middleIdx = sortedList.Count / 2;
                median = (sortedList[middleIdx - 1].GPA + sortedList[middleIdx].GPA) / 2;
            }
            Console.WriteLine("Median is {0:0.##}", median);
            // standard deviation
            double gpaSumOfSquares = studentsList.Sum(s => (s.GPA - gpaAvg) * (s.GPA - gpaAvg));
            double gpaStdDev = Math.Sqrt(gpaSumOfSquares / studentsList.Count);
            Console.WriteLine("Standard deviation is {0:0.##}", gpaStdDev);
        }

        // STEP 16.1
        static void SortByNameIntoFile()
        {
            try
            {
                var linesList = PeopleList.OrderBy(p => p.Name).Select(p => p.ToDataString());
                File.WriteAllLines(@"..\..\byname.txt", linesList); // IOException
                Console.WriteLine($"Data saved to file sorted by name. Written {linesList.Count()} items");
            }
            catch (Exception ex) when (ex is IOException || ex is SystemException)
            {
                Console.WriteLine("Error saving sorted names data to file: " + ex.Message);
            }
        }

        static void Main(string[] args)
        {
            // STEP 12: PARTIAL (define method of MessageHandler)
            MessageHandler = FancyMessagePrint;
            MessageHandler += JustPrintTheMessage;
            // MessageHandler -= FancyMessagePrint;

            // STEP 4: ReadDataFromFile()
            try
            {
                // STEP 17.4
                Logging.ChooseDelegateSetup();
                // Person p1 = new Person(); // won't work thanks to protected access to this constructor

                ReadDataFromFile();
                Console.WriteLine("=== ALL DATA ===");    // STEP 13.1
                foreach (Person p in PeopleList)
                {
                    Console.WriteLine(p.ToString());
                }

                PrintByType();            // STEP 13.3
                PrintStatistics();        // STEP 14.2
                SortByNameIntoFile();     // STEP 16.2
            }
            finally
            {
                Console.Write("Press any key.");
                Console.ReadKey();
            }

        }
    }
}
