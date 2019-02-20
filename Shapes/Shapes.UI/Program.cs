using Shapes.Library;
using System;

namespace Shapes.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var shapes = new IShape[2];

            shapes[0] = new Circle
            {
                ShapeId = 2,
                Color = "Blue",
                Size = 3
            };
            shapes[1] = new Square
            {
                ShapeId = 24,
                Color = "Green",
                Size = 6
            };


            foreach (var item in shapes)
            {
                item.Draw();
            }
        }




        
	

	


    }
}
