using System;
using System.Drawing;

namespace SquareOfFigure.Extension
{
    static class PointExtensions
    {
        public static double DistanceTo(this Point firstPoint, Point secondPoint)
        {
            return Math.Sqrt(Math.Pow(firstPoint.X - secondPoint.X, 2) + Math.Pow(firstPoint.Y - secondPoint.Y, 2));
        }
    }
}
