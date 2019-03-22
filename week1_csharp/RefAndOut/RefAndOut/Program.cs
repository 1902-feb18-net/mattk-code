using NLog;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RefAndOut
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("Enter number: ");

            var input = Console.ReadLine();

            //int number;
            //try
            //{
            //    number = int.Parse(input);

            //    Console.WriteLine($"Number entered: {number}");

            //}
            //catch
            //{
            //    Console.WriteLine("Invalid input.");
            //    return;
            //}


            // out parameters are declared outside the method call, and then the method fills in
            // that vlaue
            // acts a lot like passing by reference

            int number;
            if (int.TryParse(input, out number))
            {
                Console.WriteLine($"Number entered: {number}");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

            int.TryParse(input, out var num);

            var dict = new Dictionary<string, int>();
            if (dict.TryGetValue("nick", out var value))
            {

            }

            int x = 40;
            ChangeMyInt(ref x);
            Console.WriteLine(x);

            unsafe
            {
                int x2 = 20;
                int* pointer = &x2;
                Console.WriteLine((int)pointer);
                ChangeMyIntTwo(pointer);

                Console.WriteLine(*pointer);

            }

            ILogger logger = LogManager.GetCurrentClassLogger();

            logger.Debug("logger created successfully");

            try
            {
                int.Parse("abc");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            var logline = "2019-02-22 10:31:22.2436 DEBUG logger created successfully";
            var match = Regex.Match(logline, @"([\d-]+) ([\d:.]+) (\w+)");


            // regex syntax:
            // "character classes": \d for all digits, 
            // \w for all "word character" (letters, numbers, and underscotre)
            // \s for all whitespace, most of these have a "oppostie" version with uppsercase
            // \S for all non-whitespace

            // [abcd] means, one character, EITHER a, b, c, or d. 

            // a* means 0 to many a chars
            // a+ means 1 to many a chars

            // () are for surrounding groups of characters that you want to extract later

            string logLevel = match.Groups[3].Value;
            string dateStr = match.Groups[1] + " " + match.Groups[2];
            if (DateTime.TryParse(dateStr, out var date))
            {
                Console.WriteLine(date);

            }
            else
            {
                Console.WriteLine($"Couldn't parse date {dateStr}");
            }

            Console.WriteLine(logLevel);
            

            Console.ReadLine();
        }

        public static void ChangeMyIntDoesntWork(int number)
        {
            number = 10;
        }

        public static void ChangeMyInt(ref int number)
        {
            number = 10;
        }

        public static unsafe void ChangeMyIntTwo(int* number)
        {
            *number = 5;
        }
    }
}
