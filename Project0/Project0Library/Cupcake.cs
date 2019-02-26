using System;
using System.Collections.Generic;
using System.Text;

namespace Project0Library
{
    public static class Cupcake
    {
        public static double GetCost(CupcakeNum type)
        {
            switch ((int) type)
            {
                case 0: return 3.5; // Vanilla
                case 1: return 5.25; // Chocolate
                case 2: return 6.25; // ChocPeanutButter
                case 3: return 6; // RaspAmaretto
                case 4: return 6.5; // ChocPeppermint
                case 5: return 6; // MintOreo
                case 6: return 4; // Coconut
                case 7: return 4.7; // Lemon
                default: return 6;
            }
        } 

        public static double[] GetIngredients(CupcakeNum type)
        {
            double[] returnIngredients = new double[18];
            double[] ingredientHelper = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            switch ((int) type)
            {
                case 0: // Vanilla
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
                        0, // Raspberry
                        0, // PeanutButter
                        0, // Peppermint
                        0, // Oreo
                        0, // CoconutMilk
                        0, // Lemon
                        0 // Amaretto
                    };
                    break;
                case 1: // Chocolate
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
                        0.024, // CocoaPowder
                        0, // Raspberry
                        0, // PeanutButter
                        0, // Peppermint
                        0, // Oreo
                        0, // CoconutMilk
                        0, // Lemon
                        0 // Amaretto
                    };
                    break;
                case 2: // ChocPeanutButter
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
                        0.024, // CocoaPowder
                        0, // Raspberry
                        0.011, // PeanutButter
                        0, // Peppermint
                        0, // Oreo
                        0, // CoconutMilk
                        0, // Lemon
                        0 // Amaretto
                    };
                    break;
                case 3: // RaspAmaretto
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
                    break;
                case 4: // ChocPeppermint
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
                        0.024, // CocoaPowder
                        0, // Raspberry
                        0, // PeanutButter
                        1, // Peppermint
                        0, // Oreo
                        0, // CoconutMilk
                        0, // Lemon
                        0 // Amaretto
                    };
                    break;
                case 5: // MintOreo
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
                        0, // Raspberry
                        0, // PeanutButter
                        0.5, // Peppermint
                        0.5, // Oreo
                        0, // CoconutMilk
                        0, // Lemon
                        0 // Amaretto
                    };
                    break;
                case 6: // Coconut
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
                        0, // Raspberry
                        0, // PeanutButter
                        0, // Peppermint
                        0, // Oreo
                        0.0025, // CoconutMilk
                        0, // Lemon
                        0 // Amaretto
                    };
                    break;
                case 7: // Lemon
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
                        0, // Raspberry
                        0, // PeanutButter
                        0, // Peppermint
                        0, // Oreo
                        0, // CoconutMilk
                        0.15, // Lemon
                        0 // Amaretto
                    };
                    break;
                default:
                    break;
                }

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
