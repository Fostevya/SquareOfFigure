using NUnit.Framework;
using SquareOfFigure.Model;
using System;
using System.Collections.Generic;

namespace SquareOfFigureTests
{
    public class FigureTests
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void Triangle_CreatingShouldThrowExceptionIfSidesLessOrEqualsToZero(int caseNumber)
        {
            var testCase = FigureTestData.SquareShouldEqualsData[caseNumber];
            try
            {
                switch (testCase.Item1.Name)
                {
                    case "Circle":
                        new Circle(testCase.Item2[0]);
                        break;
                    case "Triangle":
                        new Triangle(testCase.Item2[0], testCase.Item2[1], testCase.Item2[2]);
                        break;
                    default:
                        Assert.False(true, "Не задан тип фигуры");
                        break;
                }
                Assert.False(true, "Фигура создана со сторонами меньше или равным 0");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Длина стороны не может быть меньше или равна 0", "Фигура создана со сторонами меньше или равным 0");
            }
        }

        private static class FigureTestData
        {
            public static Dictionary<int, Tuple<Type, List<double>>> SquareShouldEqualsData = new Dictionary<int, Tuple<Type, List<double>>>()
            {
                { 1, Tuple.Create(typeof(Circle),  new List<double>() { -1 }) },
                { 2, Tuple.Create(typeof(Circle),  new List<double>() { 0 }) },
                { 3, Tuple.Create(typeof(Triangle),  new List<double>() { -1, -4, -3 }) },
                { 4, Tuple.Create(typeof(Triangle),  new List<double>() { 4, 4, -3 }) },
                { 5, Tuple.Create(typeof(Triangle),  new List<double>() { 1, 0, 3}) },
            };
        }
    }
}
