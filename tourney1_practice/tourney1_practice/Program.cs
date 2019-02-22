using System;

namespace tourney1_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int fact_accumulate = 1;
            int i = 1;
            int n = 120;
            while (n < fact_accumulate)
            {
                Console.WriteLine($"{fact_accumulate}");
                fact_accumulate *= i;
                if (fact_accumulate == n)
                {
                    //return true;
                }
                i++;
            }
            //return false;
            Console.WriteLine("Hello World!");
        }
    }
}
