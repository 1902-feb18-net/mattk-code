using System;
using Animals.Library;

namespace Animals.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var dog = new Dog();
            dog.Name = "Fido";
            Console.WriteLine($"Dog's name is {dog.Name}");
            dog.GoTo("door");
            dog.MakeNoise();

            try
            {
                Console.WriteLine("What should the dog say?");
                string input = Console.ReadLine();
                if (input == "null")
                {
                    input = null;
                }
                dog.setNoise(input);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("caught ArgumentNullException! using fallback value");
                dog.setNoise("woof");
            }
            catch (ArgumentException e)
            {

                Console.WriteLine("caught ArgumentException! using fallback value");
                dog.setNoise("woof");
            }
            finally
            {

            }
            
            
        }
    }
}
