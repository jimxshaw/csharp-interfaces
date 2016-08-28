using System;

namespace Polygons.Library
{
    public class Hexagon : IRegularPolygon
    {
        public int NumberOfSides { get; set; }
        public int SideLength { get; set; }

        public Hexagon(int length)
        {
            NumberOfSides = 6;
            SideLength = length;
        }

        public double GetPerimeter()
        {
            return NumberOfSides * SideLength;
        }

        public double GetArea()
        {
            return (SideLength * SideLength) * (3 * Math.Sqrt(3)) / 2;
        }
    }
}
