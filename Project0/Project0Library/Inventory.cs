using System;
using System.Collections.Generic;
using System.Text;

namespace Project0Library
{
    public class Inventory
    {
        private Dictionary<CupcakeNum, int> CupcakeInv = new Dictionary<CupcakeNum, int>();
        private Dictionary<Ingredient, int> IngredientInv = new Dictionary<Ingredient, int>();
    }
}
