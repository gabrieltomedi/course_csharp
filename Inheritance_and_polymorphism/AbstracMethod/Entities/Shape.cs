using System;
using System.Collections.Generic;
using AbstracMethod.Entities.Enums;

namespace AbstracMethod.Entities
{
    internal abstract class Shape
    {
        public Color Color { get; set; }

        public Shape()
        {

        }

        public Shape(Color color)
        {
            Color = color;
        }

        public abstract double Area();
    }
}
