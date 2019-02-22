using System;
using System.Collections.Generic;

namespace FirstNotRepeatingCharacterO1Mem
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abacabad";
            bool repeatFlag = false;
            HashSet<char> chList = new HashSet<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!chList.Contains(s[i]))
                {
                    for (int j = i + 1; j < s.Length; j++)
                    {
                        if (s[j] == s[i])
                        {
                            Console.WriteLine($"{s[i]}");
                            chList.Add(s[i]);
                            repeatFlag = true;
                            break;
                        }

                    }
                    Console.WriteLine($"{s[i]}");
                    Console.WriteLine($"{repeatFlag}");
                    if (!repeatFlag)
                    {
                        Console.WriteLine($"s[i]");
                        //return s[i];
                    }
                    repeatFlag = false;
                }

            }

            Console.WriteLine("_");


        }


    }

 
}
