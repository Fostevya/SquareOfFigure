﻿using SquareOfFigure.Extension;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SquareOfFigure.Model
{
    public abstract class Figure
    {
        public Figure(List<Point> points)
        {
            var sides = GetSidesByFigurePoints(points);
            ThrowIfSidesAreNotCorrect(sides);
            Sides = sides;
        }
        public Figure(List<double> sides)
        {
            ThrowIfSidesAreNotCorrect(sides);
            Sides = sides;
        }
        protected List<double> Sides { get; set; }
        /*Для известных фигур сделать вычисление площади возможно.
        Но как сделать его для неизвестной фигуры - не ясно.
        Максимум можно сделать для правильного многоугольника.

        Единственный вариант, создавать фигуру указывая не длину ее сторон, а координаты ее вершин.
        Тогда можно будет определить площадь по формуле Гаусса*/
        public abstract double GetSquare();
        public virtual double GetPerimeter() => Sides.Sum();

        protected static void ThrowIfSidesAreNotCorrect(List<double> sides)
        {
            if (sides.Count == 0)
            {
                throw new Exception("Невозможно определить фигуру");
            }
            if (sides.Any(side => side <= 0))
            {
                throw new Exception("Длина стороны не может быть меньше или равна 0");
            }
        }

        protected List<double> GetSidesByFigurePoints(List<Point> points)
        {
            var sides = new List<double>();
            var lastIndex = 0;
            foreach (var point in points)
            {
                var pointIndex = points.FindIndex(lastIndex, p => p == point);
                lastIndex = pointIndex;
                if (pointIndex != points.Count - 1)
                {
                    var sideLength = point.DistanceTo(points[pointIndex + 1]);
                    sides.Add(sideLength);
                }
                else
                {
                    var sideLength = point.DistanceTo(points[0]);
                    sides.Add(sideLength);
                }
            }
            return sides;
        }
    }
}
