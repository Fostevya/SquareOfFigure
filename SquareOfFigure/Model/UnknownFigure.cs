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

        //В целом, можно жестко ограничить создание фигуры оставив только конструктор по точкам. 
        //Вроде бы тогда и не нужно учитывать отсутствие координат при вычислении площади
        //Но что нам мешает вычислить периметр фигуры, если мы знаем размеры ее сторон?
        public UnknownFigure(List<double> sides) : base(sides)
        {
        }

        public void SetPoints(List<Point> points)//Метод не покрыт тестами, т.к. вызываемые в нем методы уже покрыты
        {
            //Тонкое место. Т.к. если фигура создана конструктором по сторонам, а затем заданы координаты - то размеры сторон могут измениться. (конкретно этот случай в тестах не рассмотрен)
            var sides = GetSidesByFigurePoints(points);
            ThrowIfSidesAreNotCorrect(sides);
            Sides = sides;
            this.points = points;
        }

        //определение площади по формуле Гаусса
        public override double GetSquare()
        {
            if (points == null)
            {
                throw new Exception("Необходимо задать координаты вершин фигуры");
            }
            var leftToRightSums = 0d;
            var rightToLeftSums = 0d;
            var lastIndex = 0;
            foreach (var point in points)
            {
                var pointIndex = points.FindIndex(lastIndex, p => p == point);
                lastIndex = pointIndex;
                if (pointIndex != points.Count - 1)
                {
                    leftToRightSums += point.X * points[pointIndex + 1].Y;
                    rightToLeftSums += point.Y * points[pointIndex + 1].X;
                }
                else
                {
                    leftToRightSums += point.X * points[0].Y;
                    rightToLeftSums += point.Y * points[0].X;
                }
            }
            return Math.Abs(leftToRightSums - rightToLeftSums) / 2;
        }
    }
}
