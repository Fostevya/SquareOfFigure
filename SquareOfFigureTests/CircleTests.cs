using NUnit.Framework;
using SquareOfFigure.Model;
using System;

namespace SquareOfFigureTests
{
    public class CircleTests
    {
        [TestCase(2, 12.5663706, 7)]
        [TestCase(3, 28.2743339, 7)]
        public void Circle_SquareShouldEqualsValue(double radius, double value, int roundDigits)
        {
            var cicle = new Circle(radius);
            var cicleSquare = cicle.GetSquare();
            Assert.AreEqual(value, Math.Round(cicleSquare, roundDigits), $"Площадь круга ({cicleSquare}) не равна ожидаемому результату ({value})");
        }

        [TestCase(2, 12.5663706, 7)]
        [TestCase(3, 18.8495559, 7)]
        public void Circle_PerimeterShouldEqualsValue(double radius, double value, int roundDigits)
        {
            var cicle = new Circle(radius);
            var ciclePerimeter = cicle.GetPerimeter();
            Assert.AreEqual(value, Math.Round(ciclePerimeter, roundDigits), $"Периметр круга ({ciclePerimeter}) не равен ожидаемому результату ({value})");
        }
    }
}