using System;
using System.Collections.Generic;
using System.Drawing;

namespace SquareOfFigure.Model
{
    public class UnknownFigure : Figure
    {
        private List<Point> points;
        //тип фигуры не знаем, поэтому стороны задаем координатами
        public UnknownFigure(List<Point> points) : base(points)
        {
            this.points = points;
        }

        public void SetPoints(List<Point> points)
        {
            this.points = points;
        }

        //определение площади по формуле Гаусса
        public override double GetSquare()
        {
            if (points == null)
            {
                throw new Exception("Необходимо задать координаты вершин фигуры");
            }
            double leftToRightSums = 0;
            double rightToLeftSums = 0;
            foreach (var point in points)
            {
                var pointIndex = points.IndexOf(point);
                if (pointIndex != points.Count - 1)
                {
                    leftToRightSums += point.X + points[pointIndex + 1].Y;
                    rightToLeftSums += point.Y + points[pointIndex + 1].X;
                }
                else
                {
                    leftToRightSums += point.X + points[0].Y;
                    rightToLeftSums += point.Y + points[0].X;
                }
            }
            return Math.Abs(leftToRightSums - rightToLeftSums) / 2;
        }
    }
}
