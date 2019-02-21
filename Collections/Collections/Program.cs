using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            Arrays();
            Lists();
            Sets();
            StringEquality();

            new Stack<int>(); // LIFO
            new Queue<int>(); // FIFO
        }

        static void Arrays()
        {
            int[] ints = new int[5];
            int[] ints2 = new int[] { 1, 2, 3, 9, 50 };
            
            int[][] twodarray = new int[9][];
            twodarray[0] = new int[4];
            twodarray[1] = new int[4];

            int[,] multiDArray = new int[5, 5];
            multiDArray[0, 0] = 8;
            int[,,,] fourDArray = new int[5, 5, 4, 2];

            // Arrays have less overhead

            
        }

        static void Lists()
        {
            var list = new ArrayList();
            list.Add(5);
            list.Add(8);
            list.Add(1);
            list.AddRange(new int[] { 4, 5, 6, 7, 8 });
            list.Remove(8);
            list.Add("asdf");


            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
                list[i] = 4;
            }

            //foreach (var item in list)
            //{

            //}

            var genericList = new List<int> { 1, 2, 3};
            //genericList.Add("abc");

            foreach (var item in genericList)
            {
                Console.WriteLine(item * 2);
            }
        }

        static void Sets()
        {
            var set = new HashSet<string>();
            set.Add("abc");
            set.Add("abc");
            set.Add("abcdef");


            Console.WriteLine(set.Count);
            var list = new List<int> { 1, 2, 2, 2, 3 };
            var withoutDupes = new List<int>(new HashSet<int>(list));

        }
        
        static void Maps()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary["classroom"] = "room where classes are held.";

            var grades = new Dictionary<string, double>();

         
            grades["Nick"] = 80;

            foreach (KeyValuePair<string, double> item in grades)
            {
                //item.Key;
                //item.Value;
            }

            

        }

        static void StringEquality()
        {
            string a = "asdf";
            string b = "asdf";
            Console.WriteLine(a == b);

            int n1 = 5;
            int n2 = n1; // n2 gets a copy of the value of n1

            var dummy1 = new Dummy();
            var dummy2 = dummy1;

            dummy1.Data = 10;
            if (dummy2.Data == 10)
            {
                Console.WriteLine("reference type");
            }
            else
            {
                Console.WriteLine("value type");
            }

            var vDummy1 = new ValueDummy();
            var vDummy2 = vDummy1;

            vDummy1.Data = 10;
            if (vDummy2.Data == 10)
            {
                Console.WriteLine("reference type");
            }
            else
            {
                Console.WriteLine("value type");
            }

            // reference types need to be "garbage collected" because we don't know right away
            // when the LAST variable pointing to it has passed out of scope

            Console.WriteLine(new Dummy() == new Dummy());

            int i1 = 5;
            object o2 = i1;
            // This is called "boxing" - the int is wrapped inside a reference type

            int i2 = (int)o2; // extract that value from inside the object wrapper

        }

    }

    class Dummy
    {
        public int Data { get; set; }
    }

    struct ValueDummy
    {
        public int Data { get; set; }
    }


}
