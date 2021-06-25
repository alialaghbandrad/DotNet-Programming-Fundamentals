using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01PeopleListInFile
{
    class Program
    {
        const string DataFileName = @"..\..\people.txt";

        static void AddPersonInfo() {
            try
            {
                Console.WriteLine("Adding a person.");
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter age: ");
                int age = int.Parse(Console.ReadLine()); // ex FormatException
                Console.Write("Enter city: ");
                string city = Console.ReadLine();
                Person person = new Person(name, age, city); // ex ArgumentException
                People.Add(person);
                Console.WriteLine("Person added.");
            } catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            } catch (FormatException ex)
            {
                Console.WriteLine("Error: invalid numerical input");
            }
        }
        static void ListAllPersonsInfo() {
            Console.WriteLine("Listing all persons");
            foreach(Person person in People)
            {
                Console.WriteLine(person);
            }
        }
        static void FindPersonByName() {
            Console.Write("Enter partial person name: ");
            string searchStr = Console.ReadLine();
            Console.WriteLine("Matches found:");
            var matchesList = People.Where(p => p.Name.Contains(searchStr)).ToList(); // LINQ
            if (matchesList.Count() > 0)
            {
                foreach (Person p in matchesList)
                {
                    Console.WriteLine(p);
                }
            } else
            {
                Console.WriteLine("No matches found");
            }

            /*
            foreach (Person p in People)
            {
                if (p.Name.Contains(searchStr))
                {
                    Console.WriteLine(p);
                }
            }*/

        }
        static void FindPersonYoungerThan() {
            Console.Write("Enter maximum age: ");
            if (!int.TryParse(Console.ReadLine(), out int maxAge))
            {
                Console.WriteLine("Invalid input");
                return;
            }
            // using a foreach loop with a condition
            Console.WriteLine("Peple at that age or younger:");
            foreach (Person p in People)
            {
                if (p.Age <= maxAge)
                {
                    Console.WriteLine(p);
                }
            }
            // using LINQ
            Console.WriteLine("Peple at that age or younger (using LINQ):");
            var youngerList = People.Where(p => p.Age <= maxAge);
            foreach (Person p in youngerList)
            {
                    Console.WriteLine(p);
            }

        }

        static void ReadAllPeopleFromFile() {
            try
            {
                if (!File.Exists(DataFileName)) {
                    return; // it's okay if the file does not exist yet
                }
                string[] linesArray = File.ReadAllLines(DataFileName); // ex IOException, SystemException
                foreach(string line in linesArray)
                {
                    try
                    {
                        string[] data = line.Split(';');
                        if (data.Length != 3)
                        {
                            throw new FormatException("Invalid number of items");
                            // or: Console.WriteLine("Error..."); continue;
                        }
                        string name = data[0];
                        int age = int.Parse(data[1]); // ex FormatException
                        string city = data[2];
                        Person person = new Person(name, age, city); // ex ArgumentException
                        People.Add(person);
                    } catch (Exception ex) when (ex is FormatException || ex is ArgumentException)
                    {
                        Console.WriteLine($"Error (skipping line): {ex.Message} in:\n  {line}");
                    }
                }
            }
            catch (Exception ex) when (ex is IOException || ex is SystemException)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
            }
        }

        static void SaveAllPeopleToFile() {
            try
            {
                List<string> linesList = new List<string>();
                foreach (Person person in People)
                {
                    linesList.Add($"{person.Name};{person.Age};{person.City}");
                }
                File.WriteAllLines(DataFileName, linesList); // ex IOException, SystemException
            } catch (Exception ex) when (ex is IOException || ex is SystemException)
            {
                Console.WriteLine("Error writing file: " + ex.Message);
            }
        }

        static List<Person> People = new List<Person>();

        static int getMenuChoice()
        {
            while (true)
            {
                Console.Write("What do you want to do?\n" +
                    "1.Add person info\n" +
                    "2.List persons info\n" +
                    "3.Find and list a person by name\n" +
                    "4.Find and list persons younger than age\n" +
                    "0.Exit\n" + "Choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    // 3 ways to get out of the loop: break, return, throw exception
                    return choice;
                }
                Console.WriteLine("Invalid input, must be numerical. Try again.");
            }
        }

        static void Main(string[] args)
        {
            ReadAllPeopleFromFile();
            while (true)
            {
                int choice = getMenuChoice();
                switch (choice)
                {
                    case 1:
                        AddPersonInfo();
                        break;
                    case 2:
                        ListAllPersonsInfo();
                        break;
                    case 3:
                        FindPersonByName();
                        break;
                    case 4:
                        FindPersonYoungerThan();
                        break;
                    case 0:
                        SaveAllPeopleToFile();
                        return; // exit program
                    default:
                        Console.WriteLine("No such option, try again.");
                        break;
                }
                Console.WriteLine();
            }


            /*
            try
            {
                Person p1 = new Person();
                //p1.Name = "Jer;ry"; // call to setter
                string n1 = p1.Name; // call to getter

                // object initializer, may not initialize all fields/properties
                Person p2 = new Person() { Name = "Eva", Age = 76 };

                string p2s = $"Person Name={p2.Name}, Age is {p2.Age}";
                Console.WriteLine(p2s);

                p1.SomeValue = 123;
                for (int i = 0; i < 5; i++)
                {
                    int val = p1.SomeValue;
                    Console.WriteLine(val);
                }

            } finally
            {
                Console.WriteLine("Press any key");
                Console.ReadKey();
            } */
        }

    }
}
