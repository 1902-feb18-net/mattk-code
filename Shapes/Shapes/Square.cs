﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Library
{
    public class Square : IShape
    {
        public int ShapeId { get; set; }
        public string Color;
        public int Size;

        public void Translate(int value)
        {
            Console.WriteLine($"Square has moved by {value}");
        }

        public void Draw()
        {
            Console.WriteLine("Look a square");
        }

    }
}
