using System;
using System.Collections.Generic;

namespace CodeSignalFirstDuplicate
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 5, 5 };
            int number = a.Length + 2;
            int i = 0;
            var dictionary = new Dictionary<int, int>();

            bool duplicateVal = false;

            HashSet<int> se = new HashSet<int>();
            foreach (var t in a)
            {
                if (se.Contains(t))
                {
                    if (i < number)
                    {
                        duplicateVal = true;
                        number = i;
                    }
                } else
                {
                    se.Add(t);
                }
                i++;
            }

            if (duplicateVal)
            {
                Console.WriteLine($"{number - 1}");
                //return number;
            } else
            {
                Console.WriteLine("-1");
                //return -1;
            }

            
            //for (int i = 0; i < a.Length; i++)
            //{
            //    number = a[i];
            //    for (int j = i + 1; j < a.Length; j++)
            //    {
            //        if (a[j] == a[i])
            //        {
                        
            //            if (!dictionary.ContainsValue(a[j]))
            //            {
            //                dictionary[a[j]] = j;
            //            }
            //        }
            //    }
            //}
            
            //if (dictionary.Count == 0)
            //{
            //    Console.WriteLine("-1");
            //    //return -1;
            //}
            //else
            //{
            //    int value = a.Length + 1;
            //    foreach (var item in dictionary)
            //    {
            //        if (item.Value < value)
            //        {
            //            value = item.Value;
            //        }
            //    }
            //    Console.WriteLine($"{value}");
            //}
            //Console.WriteLine("Hello World!");
        }
    }
}
