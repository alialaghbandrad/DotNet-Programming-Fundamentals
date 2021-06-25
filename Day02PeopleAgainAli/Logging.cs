using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02PeopleAgainAli
{
    // STEP 17: Logging
    class Logging
    {
        // STEP 17.1
        // delegate type declaration
        public delegate void LogFailedSetterDelegate(string reason);

        // STEP 17.2
        // reference variable of delegate type
        public static LogFailedSetterDelegate LogFailure;   // List of references (0, 1 or more methods)

        // STEP 17.5
        public static void LogToFile(string msg)
        {
            try
            {
                File.AppendAllText(@"..\..\log.txt", msg + "\n");
            }
            catch (Exception ex) when (ex is IOException || ex is SystemException)
            {
                Console.WriteLine("Error saving log message to file: " + ex.Message);
            }
        }

        // STEP 17.6
        public static void LogToScreen(string msg)
        {
            Console.WriteLine("*** LOG: " + msg);
        }

        // STEP 17.3
        public static void ChooseDelegateSetup()
        {
            LogFailure = LogToScreen;
            Console.Write("Where would you like to log setters errors?\n"
                + "1 - screen only\n2 - screen and file\n3 -do not log\nYour choice: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid option. Choosing default - log to screen");
            }
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Logging to screen only");
                    break;
                case 2:
                    LogFailure += LogToFile;
                    Console.WriteLine("Logging to screen and file");
                    break;
                case 3:
                    LogFailure = null;
                    Console.WriteLine("Logging disabled");
                    break;
                default:
                    Console.WriteLine("Invalid option. Choosing default - log to screen");
                    break;
            }
        }


    }
}
