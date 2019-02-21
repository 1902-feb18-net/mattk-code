using System;
using System.Collections.Generic;

namespace CollectionTestingLibrary
{
    public class MyStringCollection : MyGenericCollection<string>
    {
        // store a list of string to handle all of the list operations
        //private List<string> _list = new List<string>();

        public MyStringCollection() : base(new string[] { })
        {

        }

        public MyStringCollection(string[] initial) : base(initial)
        {

        }

        // then implement some collection methods like Add, Contains, Remove, and some
        // others that are not already on the List.
        public void Add(string input)
        {
            _list.Add(input);
        }

        public static void Contains(string input)
        {
            //_stringList.Contains(input);
        }

        public static void Remove(string input)
        {
            //_stringList.Remove(input);
        }

        public static void Concatenate()
        {

        }

        public static void RemoveAtIndex()
        {

        }

        public void MakeLowercase()
        {

        }

        public void RemoveEmpty()
        {

        }

        public string GetFirst()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("list is empty");

            }
            return _list[0];
        }
    }


}
