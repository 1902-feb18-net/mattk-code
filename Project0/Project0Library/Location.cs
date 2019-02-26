using System;
using System.Collections.Generic;
using System.Text;

namespace Project0Library
{
    public class Location
    {
        public int Id { get; set; }
        public double[] StoreInv { get; set; } = new double[18];
        public List<Order> OrderHistory { get; set; } = new List<Order>();

        public Location()
        {
            SetInv();
        }

        public void SetInv()
        {
            StoreInv[0] = 100; // Flour, lbs
            StoreInv[1] = 100; // BakingPowder, lbs
            StoreInv[2] = 100; // Salt, lbs
            StoreInv[3] = 100; // UnsaltedButter, lbs
            StoreInv[4] = 100; // GranulatedSugar, lbs
            StoreInv[5] = 100; // LargeEgg, each or individual units
            StoreInv[6] = 100; // VanillaExtract, gallons
            StoreInv[7] = 100; // SourCream, lbs
            StoreInv[8] = 100; // ConfectionerSugar, lbs
            StoreInv[9] = 100; // HeavyCream, lbs
            StoreInv[10] = 100; // CocoaPowder, lbs
            StoreInv[11] = 100; // Raspberry, each or individual units
            StoreInv[12] = 100; // PeanutButter, lbs
            StoreInv[13] = 100; // Peppermint, each or individual units
            StoreInv[14] = 100; // Oreo, lbs
            StoreInv[15] = 100; // CoconutMilk, gallons
            StoreInv[16] = 100; // Lemon, each or individual units
            StoreInv[17] = 100; // Amaretto, lbs
        }

        public bool CheckInv(CupcakeNum cupcakeType, int qnty)
        {
            double[] cupcakeRequirements = Cupcake.GetIngredients(cupcakeType);

            int i = 0;
            foreach (var item in StoreInv)
            {
                if (StoreInv[i] < (double) (cupcakeRequirements[i] * qnty))
                {
                    return false;
                }
                i++;
            }
            return true;
        }

        public void UpdateInv(CupcakeNum cupcakeType, int qnty)
        {
            double[] cupcakeRequirements = Cupcake.GetIngredients(cupcakeType);

            int i = 0;
            foreach (var item in StoreInv)
            {
                StoreInv[i] -= (double)(cupcakeRequirements[i] * qnty);
                i++;
            }
        }
    }
}
