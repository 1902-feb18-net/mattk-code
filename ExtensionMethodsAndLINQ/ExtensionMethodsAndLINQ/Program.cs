using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethodsAndLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int result = 3.Pow(3);
            Console.WriteLine($"{result}");
            var list = new List<string>();
            list.Empty();
            var str = list.ToString();

            // LINQ
            // language-integrated-query
            list.ToList();

            list.AddRange(new string[] { "a", "b", "b", "asdfasdfasdfasdf" });

            int sum = 0;
            foreach (var s in list)
            {
                sum += s.Length;
            }
            double averageStringLength = sum/list.Count;

            Console.WriteLine(averageStringLength);

            averageStringLength = list.Average(s => s.Length);

            Console.WriteLine(averageStringLength);

            // a "lambda" is kind of like a method that's anonymous
            // and can be treated like an ordinary value/object
            Func<string, int> numberOfAs = x => x.Count(c => c == 'a');
            var numOfAllAs = list.Sum(numberOfAs);
            var numOfAllBs = list.Sum(NumberOfBs);
            // NumberOfBs is passed through the Sum function, it needs the function itself,
            // not a return value of the function.

            // LINQ has two syntaxes...
            // "method syntax"
            // and "query syntax" (SQL wannabe)

            var allEmptyStrings = from x in list
                                  where x == ""
                                  select x;
            allEmptyStrings = list.Where(x => x == "");

            bool anyStringsLongerThanFive = list.Any(s => s.Length > 5);
            bool allStringsLongerThanFive = list.All(s => s.Length > 5);

            var asdf = list.Distinct().Where(x => x[0] == 'a').Select(x => x[1]);
            // Select is a mapping
            // Select and Where are the most common ones.
            // Where filters a collection on some condition

            var allWithLengthThree = list.Where(s => s.Length == 3);

            // deferred execution

            asdf.Last();
            asdf.Last();
            asdf.Last();
            asdf.Last();


            
                

                
        }

        static int NumberOfBs(string x)
        {
            var count = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == 'b')
                {
                    count++;
                }

            }
            return count;
        }


    }
}
