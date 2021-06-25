using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03FirstIndexerAli
{
    // STEP 1
    class PrimeArray
    {
        // read-only property to assess the CPU effort required by computations
        private long _steps;
        public long Steps
        {
            get { return _steps; }
        }

        // STEP 2:
        // return true if index is a prime number, false otherwise

        public String this[int x, int y]
        {
            get
            {
                return "true";
            }
        }

        public Tuple<int, double, string> this[string index]
        {
            get
            {
                return new Tuple<int, double, string>(0, 0.333, "abc");
            }
        }
        // END OF STEP 2


        // STEP 3
        // key is N, value is the Nth prime number, sorty by N
        private SortedDictionary<int, long> cache = new SortedDictionary<int, long>();
        public long this[int wantedNth]
        {
            get
            {
                if (cache.ContainsKey(wantedNth))
                {
                    return cache[wantedNth];
                }

                int count = 0; // how many prime numbers have I found so far
                long currNum = 2;
                while (true)
                {
                    _steps++;
                    if (isPrime(currNum))
                    {
                        count++; // found another prime number
                        cache[count] = currNum; // save in dictionary
                        if (count == wantedNth) return currNum;
                    }
                    currNum++;
                }
            }
        }

        // STEP 1.1: isPrime method
        private bool isPrime(long num)
        {
            for (int div = 2; div <= num / 2; div++)
            {
                if (num % div == 0)
                {
                    return false;
                }
            }
            return true;
        }

    }

    class Program
    {
        // STEP 4
        static void Main(string[] args)
        {
            try
            {
                PrimeArray pa = new PrimeArray();
                for (int i = 1; i <= 20; i++)
                {
                    Console.Write($"{pa[i]}({pa.Steps})  ");
                }
                Console.WriteLine("=== 2nd run ===");
                for (int i = 1; i <= 21; i++)
                {
                    Console.Write($"{pa[i]}({pa.Steps})  ");
                }


                /*
                PrimeArray pa = new PrimeArray();
                for (int i = 2; i < 50; i++)
                {
                    bool result = pa[i];
                    if (result)
                    {
                        Console.WriteLine($"Number {i} is a prime number");
                    }
                }
                */
            }
            finally
            {
                Console.ReadKey();
            }

        }
    }
}
