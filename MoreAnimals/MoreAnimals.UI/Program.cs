using MoreAnimals.Library;
using System;

namespace MoreAnimals.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var fido1 = new Dog();
            fido1.AnimalId = 1;
            fido1.Name = "Fido";
            fido1.Breed = "Doberman";

            var fido2 = new Dog
            {
                AnimalId = 1,
                Name = "Fido",
                Breed = "Doberman"
            };

            fido1.GoTo("park");
            fido1.MakeNoise();

            IAnimal animal = fido1;

            //animal.Breed = "";

            //Bird bird = (Bird)animal;
            Dog dog3 = (Dog)animal;

            int integer = (int)3.4;
            double num = integer;

            var animals = new IAnimal[2];
            animals[0] = fido1;
            animals[1] = new Eagle
            {
                AnimalId = 3,
                Name = "Bill"
            };

            foreach (var item in animals)
            {
                Console.WriteLine(item.Name);
                item.MakeNoise();
                item.GoTo("park");
            }

            Eagle eagle1 = (Eagle)animals[1];
            //eagle.GoTo

            MakeNoise(dog3);

            // use camelcase for local variables and private fields
            // TitleCase aka PascalCase for everything else
        }

        static void MakeNoise(IAnimal animal)
        {
            animal.MakeNoise();
        }
    }
}
