using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionTestingLibrary
{
    public class MyGenericCollection<T>
    {

        protected readonly List<T> _list = new List<T>();
        private int id;


        public MyGenericCollection() : this(null)
        {
            id = new Random().Next();
        }

        public MyGenericCollection(T[] initial)
        {
            _list.AddRange(initial);
        }



        public void Add(T value)
        {
            _list.Add(value);
        }

        public bool Contains(T value)
        {
            var result = (bool) _list.Contains(value);
            return result;
        }

    }
}
