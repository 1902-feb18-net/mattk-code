using System;
using System.Collections.Generic;
using System.Text;

namespace Project0Library
{
    public class Customer
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DefaultStore { get; set; }
        public List<Order> OrderHistory { get; set; } = new List<Order>();
        public DateTime LastOrder { get; set; }
        public int LastStoreOrder { get; set; }

    }
}
