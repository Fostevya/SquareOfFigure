using NUnit.Framework;
using SquareOfFigure.Model;
using System;
using System.Collections.Generic;

namespace SquareOfFigureTests
{
    public class TriangleTestscs
    {
        [TestCase(2, 10, 4)]
        [TestCase(4, 5, 10)]
        public void Triangle_CreatingShouldThrowExceptionIfTriangleNotExists(double side1, double side2, double side3)
        {
            try
            {
                new Triangle(side1, side2, side3);
                Assert.False(true, "Создан треугольник, не удовлетворяющий основному требованию треугольника");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Треугольник не существует", "Создан треугольник, не удовлетворяющий основному требованию треугольника");
            }
        }

        [TestCase(12, 20, 16)]
        public void Triangle_IsRightTriangle_True(double side1, double side2, double side3)
        {
            var triangle = new Triangle(side1, side2, side3);
            Assert.True(triangle.IsRightTriangle(), "Прямоугольный треугольник не определен таковым");
        }

        [TestCase(12, 14, 16)]
        public void Triangle_IsRightTriangle_False(double side1, double side2, double side3)
        {
            var triangle = new Triangle(side1, side2, side3);
            Assert.False(triangle.IsRightTriangle(), "Треугольник не является прямоугольным");
        }

        [TestCase(1, 3)]
        [TestCase(2, 3)]
        public void Triangle_SquareShouldEqualsValue(int caseNumber, int roundDigits)
        {
            var testCase = TriangleTestData.SquareShouldEqualsData[caseNumber];
            var triangle = new Triangle(testCase.Item1[0], testCase.Item1[1], testCase.Item1[2]);
            var triangleSquare = triangle.GetSquare();
            Assert.AreEqual(testCase.Item2, Math.Round(triangleSquare, roundDigits), $"Периметр треугольника ({triangleSquare}) не равен ожидаемому результату ({testCase.Item2})");
        }

        [TestCase(3, 4, 5, 12)]
        [TestCase(8, 8, 8, 24)]
        public void Triangle_PerimeterShouldEqualsValue(double side1, double side2, double side3, double value)
        {
            var triangle = new Triangle(side1, side2, side3);
            var trianglePerimeter = triangle.GetPerimeter();
            Assert.AreEqual(value, trianglePerimeter, $"Периметр треугольника ({trianglePerimeter}) не равен ожидаемому результату ({value})");
        }

        private static class TriangleTestData
        {
            public static Dictionary<int, Tuple<List<double>, double>> SquareShouldEqualsData = new Dictionary<int, Tuple<List<double>, double>>()
            {
                { 1, Tuple.Create(new List<double>() { 3, 4, 5 },  6d) },
                { 2, Tuple.Create(new List<double>() { 8, 8, 8 },  27.713) }
            };
        }
    }
}
