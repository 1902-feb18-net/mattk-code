using System;
using System.Collections.Generic;
using System.Text;

namespace Project0Library
{
    public class Order
    {
        private static int idIncrement = 0;

        private int Id { get; set; }
        private Dictionary<int, int> Cupcakes { get; set; }
        private DateTime orderTime { get; set; }



    }
}
