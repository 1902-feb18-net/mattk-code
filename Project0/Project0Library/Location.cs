using System;
using System.Collections.Generic;
using System.Text;

namespace Project0Library
{
    public class Location
    {
        private static int idIncrement = 0;
        private static HashSet<string> nameUnique;

        private int Id { get; set; }
        private string Name { get; set; }
        private Inventory storeInv { get; set; }
        public OrderHistory orderHistory { get; set; }


    }
}
