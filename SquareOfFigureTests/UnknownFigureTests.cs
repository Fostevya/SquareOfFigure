using NUnit.Framework;
using SquareOfFigure.Model;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SquareOfFigureTests
{
    public class UnknownFigureTests
    {
        [TestCase(1, 2)]
        [TestCase(2, 2)]
        public void UnknownFigure_SquareShouldEqualsValue(int caseNumber, int roundDigits)
        {
            var testCase = UnknownFigureTestData.SquareShouldBe[caseNumber];
            var unknownFigure = new UnknownFigure(testCase.Item1);
            var unknownFigureSquare = unknownFigure.GetSquare();
            Assert.AreEqual(testCase.Item2, Math.Round(unknownFigureSquare, roundDigits), $"Периметр фигуры ({unknownFigureSquare}) не равен ожидаемому результату ({testCase.Item2})");
        }

        [TestCase(1)]
        [TestCase(2)]
        public void UnknownFigure_PerimeterShouldEqualsValue(int caseNumber)
        {
            var testCase = UnknownFigureTestData.PerimeterShouldBe[caseNumber];
            var unknownFigure = new UnknownFigure(testCase.Item1);
            var unknownFigurePerimeter = unknownFigure.GetPerimeter();
            Assert.AreEqual(testCase.Item2, unknownFigurePerimeter, $"Периметр фигуры ({unknownFigurePerimeter}) не равен ожидаемому результату ({testCase.Item2})");
        }


        [Test]
        public void UnknownFigure_SquareCalculatingShouldThrowIfFigureCreatedNotByPoints()
        {
            var unknownFigure = new UnknownFigure(new List<double>() { 8, 8, 8 });
            Assert.Throws<Exception>(() => unknownFigure.GetSquare(), "Площадь фигуры расчитана при неизвестных координатах");
        }

        private static class UnknownFigureTestData
        {
            public static Dictionary<int, Tuple<List<Point>, double>> SquareShouldBe = new Dictionary<int, Tuple<List<Point>, double>>()
            {
                { 1, Tuple.Create(new List<Point>() { new Point(0, 0), new Point(0, 4), new Point(4, 4), new Point(4, 0) }, 16d) },
                { 2, Tuple.Create(new List<Point>() { new Point(0, 0), new Point(0, 5), new Point(4, 5), new Point(4, 0) }, 20d) },
            };
            public static Dictionary<int, Tuple<List<Point>, double>> PerimeterShouldBe = new Dictionary<int, Tuple<List<Point>, double>>()
            {
                { 1, Tuple.Create(new List<Point>() { new Point(0, 0), new Point(0, 4), new Point(4, 4), new Point(4, 0) }, 16d) },
                { 2, Tuple.Create(new List<Point>() { new Point(0, 0), new Point(0, 5), new Point(4, 5), new Point(4, 0) }, 18d) },
            };
        }
    }
}
