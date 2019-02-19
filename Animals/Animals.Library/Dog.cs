using System;

namespace Animals.Library
{
    public class Dog
    {

        internal string Noise = "Woof!";
        public string getNoise()
        {
            return Noise;
        }

        public void setNoise(string newValue)
        {
            if (newValue == null || newValue.Length == 0)
            {
                throw new ArgumentException("value must not be null or empty");
            }

            Noise = newValue;
        }

        

        private string _name;

        public string Name 
        { 
            get 
            {
                return _name;
            }
            set
            {
                _name = value;
            } 
        }

        public string Color { get; } = "brown";
        public string Breed { get; set; }

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