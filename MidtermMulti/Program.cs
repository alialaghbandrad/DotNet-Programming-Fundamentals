using System;
using System.Collections.Generic;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MidtermMulti
{
    class Program
    {

        const string DataFileName = @"..\..\data.txt";
        static List<Airport> AirportsList = new List<Airport>();

        static int getMenuChoice()
        {
            while (true)
            {
                Console.Write("Menu:\n" +
                    "1.Add Airport\n" +  
                    "2.List all airports\n" +  
                    "3.Find nearest airport by code\n" +  
                    "4.Find airports elevation's standard deviation\n" + 
                    "5.Print Nth super-Fibonacci\n" +
                    "6.Change log delegates\n" +
                    "0.Exit\n" + 
                    "Choice: "
                    );
                if (int.TryParse(Console.ReadLine(), out int choice))     
                {
                    return choice;
                }
                Console.WriteLine("Invalid input, must be numerical. Try again.");
            }
        }

        static void ReadDataFromFile()
        {
            try
            {
                if (!File.Exists(DataFileName))
                {
                    return; // it's okay if the file does not exist yet
                }
                string[] linesArray = File.ReadAllLines(DataFileName); // ex IOException SystemException
                foreach (string line in linesArray)
                {
                    try
                    {
                        string[] data = line.Split(';'); 
                        if (data.Length != 5)
                        {
                            throw new FormatException("Invalid number of items");
                        }
                        string code = data[0];
                        string city = data[1];
                        double lat = double.Parse(data[2]);  // ex FormatException
                        double lng = double.Parse(data[3]);  // ex FormatException
                        int elevM = int.Parse(data[4]); // ex FormatException
                        Airport airport = new Airport(code, city, lat, lng, elevM); // ex ArguementException  
                        AirportsList.Add(airport);
                    }
                    catch (Exception ex) when (ex is FormatException || ex is ArgumentException)
                    {
                        Console.WriteLine($"Error (skipping line): {ex.Message} in:\n {line}");
                    }
                }
            }
            catch (Exception ex) when (ex is IOException || ex is SystemException)
            {
                Console.WriteLine("Error reading file :" + ex.Message);
            }
        }

        static void WriteDataToFile()
        {
            try
            {
                List<string> linesList = new List<string>();
                foreach (Airport airport in AirportsList)
                {
                    linesList.Add($"{airport.Code}; {airport.City}; {airport.Lat}; {airport.Lng}; {airport.ElevM}");
                }
                File.WriteAllLines(DataFileName, linesList); // IOException, SystemException
            }
            catch (Exception ex) when (ex is IOException || ex is SystemException)
            {
                Console.WriteLine("Error writing file: " + ex.Message);
            }
        }

        static void AddAirportInfo()
        {
            try
            {
                Console.WriteLine("Adding airport");
                Console.WriteLine("Enter code: ");
                string code = Console.ReadLine();
                Console.WriteLine("Enter city: ");
                string city = Console.ReadLine();
                Console.WriteLine("Enter latitude: "); // ex FormatException
                double lat = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter longitude: "); // ex FormatException
                double lng = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter elevation in meters: "); // ex FormatException
                int elevM = int.Parse(Console.ReadLine());
                Airport airport = new Airport(code, city, lat, lng, elevM); // ArguementException
                AirportsList.Add(airport);
                Console.WriteLine("Airport added.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            catch
            {
                Console.WriteLine("Error: Invalid numerical input");
            }
        }

        static void ListAllAirportsInfo()
        {
            Console.WriteLine("Listing all airports");
            foreach (Airport airport in AirportsList) 
            {
                Console.WriteLine(airport.ToString());
            }
        }


        
        static void FindNearestAirportByCode()
        {
            /*
            GeoCoordinate pin1 = new GeoCoordinate(lat, lng);
            GeoCoordinate pin2 = new GeoCoordinate(lat, lng);

            double distanceBetween = pin1.GetDistanceTo(pin2);
            */

        }
       

            static void FindAirportElevationStandardDeviation()
        {
            // calculate standard deviation
            double elevSum = AirportsList.Sum(s => s.ElevM);
            double elevAvg = elevSum / AirportsList.Count;         
            double elevSumOfSquares = AirportsList.Sum(s => (s.ElevM - elevAvg) * (s.ElevM - elevAvg));
            double elevStdDev = Math.Sqrt(elevSumOfSquares / AirportsList.Count);
            Console.WriteLine("Standard deviation is {0:0.##}", elevStdDev);
        }

        public static int[] Fibonacci(int number)
        {
            int[] a = new int[number];
            a[0] = 0;
            a[1] = 1;
            for (int i = 2; i < number; i++)
            {
                a[i] = a[i - 2] + a[i - 1];
            }
            return a;
        }

        static void PrintNthSuperFibonacci()
        {
            try
            {
                Console.WriteLine("Enter Nth number: "); // ex FormatException
                int n = int.Parse(Console.ReadLine());
                var b = Fibonacci(n);
                foreach (var elements in b)
                {
                    Console.WriteLine(elements);
                }
            }
            catch (InvalidDataException ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }


        static void Main(string[] args)
        {

            

            ReadDataFromFile();
            while (true)
            {
                int choice = getMenuChoice();
                switch (choice)
                {
                    case 1:
                        AddAirportInfo();
                        break;
                    case 2:
                        ListAllAirportsInfo();
                        break;
                    case 3:
                        FindNearestAirportByCode();
                        break;
                    case 4:
                        FindAirportElevationStandardDeviation();
                        break;
                    case 5:
                        PrintNthSuperFibonacci();
                        break;
                    case 6:
                        Logging.ChooseDelegateSetup();
                        break;
                    case 0:
                        WriteDataToFile();
                        return; // exit program
                    default:
                        Console.WriteLine("No such option, try again.");
                        break;
                }
                
                Console.Write("Press any key.");
                Console.ReadKey();
            }

















        }

        private class Location
        {
            private string v;

            public Location(string v)
            {
                this.v = v;
            }
        }
    }
}
