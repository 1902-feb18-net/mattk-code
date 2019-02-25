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

        public static Dictionary<Ingredient, int> GetIngredients(CupcakeNum type)
        {
            Dictionary<Ingredient, int> returnIngredients = new Dictionary<Ingredient, int>();

            switch ((int) type)
            {
                case 0: return returnIngredients; // Vanilla
                case 1: return returnIngredients; // Chocolate
                case 2: return returnIngredients; // ChocPeanutButter
                case 3: return returnIngredients; // RaspAmaretto
                case 4: return returnIngredients; // ChocPeppermint
                case 5: return returnIngredients; // MintOreo
                case 6: return returnIngredients; // Coconut
                case 7: return returnIngredients; // Lemon
                default: return returnIngredients;
            }
            
        }
        
    }

    public enum CupcakeNum
    {
        Vanilla,
        Chocolate,
        ChocPeanutButter,
        RaspAmaretto,
        ChocPeppermint,
        MintOreo,
        Coconut,
        Lemon
    }
}
