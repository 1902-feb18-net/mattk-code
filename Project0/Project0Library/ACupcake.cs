using System;
using System.Collections.Generic;
using System.Text;

namespace Project0Library
{
    public abstract class ACupcake
    {
        private int Id { get; set; }

        public abstract Dictionary<Ingredient, int> GetIngredients();
        public abstract void BakeCupcake(int qnty);
    }

    public enum Cupcake
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
