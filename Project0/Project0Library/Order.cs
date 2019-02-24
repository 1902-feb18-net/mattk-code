using System;
using System.Collections.Generic;
using System.Text;

namespace Project0Library
{
    public class Order
    {

        public int Id { get; set; }
        public int OrderLocation { get; set; }
        public int OrderCustomer { get; set; }
        public DateTime OrderTime { get; set; }
        private Dictionary<Cupcake, int> Cupcakes { get; set; }



    }
}
