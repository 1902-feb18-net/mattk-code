using System;
using System.Collections.Generic;
using System.Text;

namespace Project0Library
{
    public class Inventory
    {
        private Dictionary<ACupcake, int> CupcakeInv = new Dictionary<ACupcake, int>();
        private Dictionary<Ingredient, int> IngredientInv = new Dictionary<Ingredient, int>();
    }
}
