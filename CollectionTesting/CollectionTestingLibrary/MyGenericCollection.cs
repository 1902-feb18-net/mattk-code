using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionTestingLibrary
{
    class MyGenericCollection<T>
    {

        private readonly List<T> _list = new List<T>();
        private int id;


        public MyGenericCollection() : this(null)
        {
            id = new Random().Next();
        }

        public MyGenericCollection(T[] initial) : this()
        {
            _list.AddRange(initial);
        }



        public void Add(T value)
        {
            _list.Add(value);
        }

        public T Contains(T value)
        {
            return _list.Contains(value);
        }

    }
}
