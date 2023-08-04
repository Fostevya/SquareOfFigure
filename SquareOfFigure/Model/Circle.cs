using System;
using System.Collections.Generic;
using System.Linq;

namespace SquareOfFigure.Model
{
    public class Circle : Figure
    {
        public Circle(double radius) : base(new List<double>() { radius })
        {}

        public override double GetPerimeter()
        {
            return 2 * Sides.First() * Math.PI;
        }

        public override double GetSquare()
        {
            var radius = Sides.First();
            return radius * radius * Math.PI;
        }
    }
}
