using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01PeopleArray
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] namesArray = new string[4];
                int[] agesArray = new int[4];
                for (int i = 0; i < 4; i++)
                {
                    Console.Write("Enter name #{0}: ", i + 1);
                    string name = Console.ReadLine();
                    namesArray[i] = name;

                    Console.Write("Enter age #{0}: ", i + 1);
                    string ageStr = Console.ReadLine();
                    // parsing using output parameter
                    if (!int.TryParse(ageStr, out int age))
                    {
                        Console.WriteLine("Invalid input. Exiting.");
                        return; // Environment.Exit(1);
                    }
                    /* // parsing using try/catch
                    try
                    {
                        // alternative: int age = Convert.ToInt32(ageStr); // ex
                        int age = int.Parse(ageStr); // ex
                        agesArray[i] = age;
                    } catch (FormatException ex)
                    {
                        Console.WriteLine("Invalid input. Exiting.");
                        return; // Environment.Exit(1);
                    } */
                    agesArray[i] = age;
                }
                // print them back:
                Console.Write("You entered: ");
                for (int i = 0; i < 4; i++)
                {
                    Console.Write("{0}{1}({2}y/o)", i == 0 ? "" : ", ", namesArray[i], agesArray[i]);
                }
                Console.WriteLine();
            } finally
            {
                Console.Write("Press any key to finish");
                Console.ReadKey();
            }
        }
    }
}
