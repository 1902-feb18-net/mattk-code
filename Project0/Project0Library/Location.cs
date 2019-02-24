using System;
using System.Collections.Generic;
using System.Text;

namespace Project0Library
{
    public class Location
    {

        public int Id { get; set; }
        private Inventory StoreInv { get; set; }
        private OrderHistory OrderHistory { get; set; }


    }
}
