using System;

namespace Animals.UI
{
    internal class Dog 
    {

    internal string Noise = "Woof!";

        internal void GoTo(string location) 
        {
            //Console.WriteLine("Walking to " + location);

            Console.WriteLine($"Walking to {location}");

            
        }

        internal void MakeNoise()
        {
            Console.WriteLine(Noise);
        }







    }
}