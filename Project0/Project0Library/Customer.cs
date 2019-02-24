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
        private List<Order> OrderHistory { get; set; } = new List<Order>();

    }
}
