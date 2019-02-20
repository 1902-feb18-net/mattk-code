using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Library
{
    public interface IShape
    {

        int ShapeId { get; set; }

        void Translate(int value);
        void Draw();
    }
}
