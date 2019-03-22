using System;
using System.Collections.Generic;
using System.Text;

namespace MoreAnimals.Library
{
    public interface IAnimal
    {

        int AnimalId { get; set; }
        string Name { get; set; }

        void MakeNoise();
        void GoTo(string location);

    }
}
