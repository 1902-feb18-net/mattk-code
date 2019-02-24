using System;
using System.Collections.Generic;
using System.Text;

namespace Project0Library
{
    public class Customer
    {
        private static int idIncrement = 0;

        private int Id { get; set; }
        private string firstName { get; set; }
        private string lastName { get; set; }
        private Location defaultStore { get; set; }
        private OrderHistory orderHistory { get; set; }

    }
}
