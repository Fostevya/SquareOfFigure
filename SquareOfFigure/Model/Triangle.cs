using System;
using System.Collections.Generic;
using System.Linq;

namespace SquareOfFigure.Model
{
    public class Triangle : Figure
    {
        public Triangle(double side1, double side2, double side3) : base(new List<double>() { side1, side2, side3 })
        {
            ThrowIfTriangleIsNotCorrect(side1, side2, side3);
        }
        public override double GetSquare()
        {
            var halfPerimeter = Sides.Sum()/2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - Sides[0]) * (halfPerimeter - Sides[1]) * (halfPerimeter - Sides[2]));
        }

        public bool IsRightTriangle()
        {
            var sideSqrts = Sides.ConvertAll(side => side * side);
            var hypotenuseSqrt = sideSqrts.Max();
            return hypotenuseSqrt == (sideSqrts.Sum() - hypotenuseSqrt);
        }

        private static void ThrowIfTriangleIsNotCorrect(double side1, double side2, double side3)
        {
            if (side1 + side2 > side3)
            {
                if (side2 + side3 > side1)
                {
                    if (side1 + side3 > side2)
                    {
                        return;
                    }
                }
            }
            throw new Exception("Треугольник не существует");
        }
    }
}
