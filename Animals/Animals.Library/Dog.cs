using System;

namespace Animals.Library
{
    public class Dog 
    {

    public string Noise = "Woof!";

        public void GoTo(string location) 
        {
            //Console.WriteLine("Walking to " + location);

            Console.WriteLine($"Walking to {location}");

            
        }

        public void MakeNoise()
        {
            Console.WriteLine(Noise);
        }







    }
}