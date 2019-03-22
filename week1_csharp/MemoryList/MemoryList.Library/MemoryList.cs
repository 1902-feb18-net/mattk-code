using System;
using System.Collections.Generic;

namespace ML.Library
{
    public class MemoryList<T>
    {
        private List<T> memList = new List<T>();
        private HashSet<T> hasContained = new HashSet<T>();


        public void Add(T value)
        {
            //throw new NotImplementedException();
            memList.Add(value);
            if (!hasContained.Contains(value))
            {
                hasContained.Add(value);
            }

        }

        public void Remove(T value)
        {
            //throw new NotImplementedException();
            memList.Remove(value);
        }
        
        public bool Contains(T value)
        {
            //throw new NotImplementedException();
            return (bool) memList.Contains(value);
        }

        public bool HasEverContained(T value)
        {
            //throw new NotImplementedException();
            return (bool) hasContained.Contains(value);
        }

    }
}
