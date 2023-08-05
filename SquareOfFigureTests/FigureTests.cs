using NUnit.Framework;
using SquareOfFigure.Model;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SquareOfFigureTests
{
    public class FigureTests
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        public void Figure_CreatingShouldThrowExceptionIfSidesLessOrEqualsToZero(int caseNumber)
        {
            var testCase = FigureTestData.CreatingShouldThrowException[caseNumber];
            try
            {
                switch (testCase.Item1.Name)
                {
                    case nameof(Circle):
                        new Circle(testCase.Item2[0]);
                        break;
                    case nameof(Triangle):
                        new Triangle(testCase.Item2[0], testCase.Item2[1], testCase.Item2[2]);
                        break;
                    case nameof(UnknownFigure):
                        new UnknownFigure(testCase.Item2);
                        break;
                    default:
                        Assert.False(true, "Не задан тип фигуры");
                        break;
                }
                Assert.False(true, "Фигура создана со сторонами меньше или равными 0");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Длина стороны не может быть меньше или равна 0", "Фигура создана со сторонами меньше или равными 0");
            }
        }

        [Test]
        public void UnknownFigure_CreatingShouldThrowExceptionIfSidesLessOrEqualsToZero()
        {
            try
            {
                //Проверить отрицательную длину сторон по координатам - не являтся возможным. Расстояние между точками всегда будет неотрицательным
                new UnknownFigure(new List<Point>() { new Point(0, 0), new Point(0, 4), new Point(4, 4), new Point(0, 0) });
                Assert.False(true, "Фигура создана со сторонами меньше или равными 0");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Длина стороны не может быть меньше или равна 0", "Фигура создана со сторонами меньше или равными 0");
            }
        }

        private static class FigureTestData
        {
            public static Dictionary<int, Tuple<Type, List<double>>> CreatingShouldThrowException = new Dictionary<int, Tuple<Type, List<double>>>()
            {
                { 1, Tuple.Create(typeof(Circle),  new List<double>() { -1 }) },
                { 2, Tuple.Create(typeof(Circle),  new List<double>() { 0 }) },
                { 3, Tuple.Create(typeof(Triangle),  new List<double>() { -1, -4, -3 }) },
                { 4, Tuple.Create(typeof(Triangle),  new List<double>() { 4, 4, -3 }) },
                { 5, Tuple.Create(typeof(Triangle),  new List<double>() { 1, 0, 3}) },
                { 6, Tuple.Create(typeof(UnknownFigure),  new List<double>() { 4, 4, -3 }) },
                { 7, Tuple.Create(typeof(UnknownFigure),  new List<double>() { 1, 0, 3}) },
            };
        }
    }
}
