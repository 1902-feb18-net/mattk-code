using System;
using System.Collections.Generic;
using System.Text;

namespace Project0Library
{
    public class Cupcake
    {
        public virtual double Cost { get; set; } = 6;

        public virtual double[] GetIngredients()
        {
            double[] returnIngredients = new double[18];
            double[] ingredientHelper = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            int i = 0;
            foreach (var item in returnIngredients)
            {
                returnIngredients[i] = ingredientHelper[i];
                i++;
            }

            return returnIngredients;
        }

        public static Cupcake FindCupcake(CupcakeNum type)
        {
            Cupcake returnCupcake = new Vanilla();
            switch ((int) type)
            {
                case 0:
                    return returnCupcake;
                case 1:
                    returnCupcake = new Chocolate();
                    return returnCupcake;
                case 2:
                    returnCupcake = new ChocPeanutButter();
                    return returnCupcake;
                case 3:
                    returnCupcake = new RaspAmaretto();
                    return returnCupcake;
                case 4:
                    returnCupcake = new ChocPeppermint();
                    return returnCupcake;
                case 5:
                    returnCupcake = new MintOreo();
                    return returnCupcake;
                case 6:
                    returnCupcake = new Coconut();
                    return returnCupcake;
                case 7:
                    returnCupcake = new Lemon();
                    return returnCupcake;
                default:
                    return returnCupcake;
            }

        }
    }
}
