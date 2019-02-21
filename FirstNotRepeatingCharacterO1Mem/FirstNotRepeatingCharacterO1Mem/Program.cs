using System;
using System.Collections.Generic;

namespace FirstNotRepeatingCharacterO1Mem
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abacabaabacaba";
            bool repeatFlag = false;
            char c;
            HashSet<char> chList = new HashSet<char>();

            for (int i = 0; i < s.Length; i++)
            {
                c = s[i];
                if (chList.Contains(c))
                {
                    break;
                }
                else
                {
                    for (int j = i + 1; j < s.Length; j++)
                    {
                        if (s[j] == s[i])
                        {
                            chList.Add(s[i]);
                            repeatFlag = true;
                            break;
                        }

                    }
                    if (!repeatFlag)
                    {
                        Console.WriteLine($"{s[i]}");
                        //return s[j];
                    }
                    repeatFlag = false;
                }
                

            }

            //return '_';




            Console.WriteLine("_");

            Console.WriteLine("Hello World!");
        }
    }
}
