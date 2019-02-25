using System;
using System.Collections.Generic;
using System.Text;

namespace Project0Library
{
    public class Location
    {
        public int Id { get; set; }
        public Dictionary<Ingredient, double> StoreInv { get; set; } = new Dictionary<Ingredient, double>();
        public List<Order> OrderHistory { get; set; } = new List<Order>();

        public Location()
        {
            SetInv();
        }

        public void SetInv()
        {
            StoreInv[(Ingredient) 0] = 1; // Flour, lbs
            StoreInv[(Ingredient) 1] = 1; // BakingPowder, lbs
            StoreInv[(Ingredient) 2] = 1; // Salt, lbs
            StoreInv[(Ingredient) 3] = 1; // UnsaltedButter, lbs
            StoreInv[(Ingredient) 4] = 1; // GranulatedSugar, lbs
            StoreInv[(Ingredient) 5] = 1; // LargeEgg, each or individual units
            StoreInv[(Ingredient) 6] = 1; // VanillaExtract, gallons
            StoreInv[(Ingredient) 7] = 1; // SourCream, lbs
            StoreInv[(Ingredient) 8] = 1; // ConfectionerSugar, lbs
            StoreInv[(Ingredient) 9] = 1; // HeavyCream, lbs
            StoreInv[(Ingredient) 10] = 1; // CocoaPowder, lbs
            StoreInv[(Ingredient) 11] = 1; // Raspberry, each or individual units
            StoreInv[(Ingredient) 12] = 1; // PeanutButter, lbs
            StoreInv[(Ingredient) 13] = 1; // Peppermint, each or individual units
            StoreInv[(Ingredient) 14] = 1; // Oreo, lbs
            StoreInv[(Ingredient) 15] = 1; // CoconutMilk, gallons
            StoreInv[(Ingredient) 16] = 1; // Lemon, each or individual units
        }

    }
}
