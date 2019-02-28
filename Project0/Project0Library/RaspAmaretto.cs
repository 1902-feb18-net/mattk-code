using System;
using System.Collections.Generic;
using System.Text;

namespace Project0Library
{
    public class RaspAmaretto : Cupcake
    {
        public override double Cost { get; set; } = 6;

        public override double[] GetIngredients()
        {
            double[] returnIngredients = new double[18];
            double[] ingredientHelper = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            ingredientHelper = new double[] {
                        0.028, // Flour
                        0.00094, // BakingPowder
                        0.00045, // Salt
                        0.054, // UnsaltedButter
                        0.031, // GranulatedSugar
                        0.14, // LargeEgg
                        0.0004, // VanillaExtract
                        0.019, // SourCream
                        0.057, // ConfectionerSugar
                        0.0045, // HeavyCream
                        0, // CocoaPowder
                        7, // Raspberry
                        0, // PeanutButter
                        0, // Peppermint
                        0, // Oreo
                        0, // CoconutMilk
                        0, // Lemon
                        0.014 // Amaretto
                    };

            int i = 0;
            foreach (var item in returnIngredients)
            {
                returnIngredients[i] = ingredientHelper[i];
                i++;
            }

            return returnIngredients;
        }
    }
}
