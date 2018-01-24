using System;
using System.Drawing;

namespace Индивидуальное_задание_КДМ_попытка_2
{
    internal class Algorythms
    {
        public static double Sqr(double x)
        {
            return Math.Pow(x: x, y: 2);
        }

        public static TwoPoints IntersectionLineAndCircle(Line line, Circle circle)
        {
            var x0 = circle.x0;
            var y0 = circle.y0;
            var r = circle.R;
            var k = line.k;
            var b = line.b;


            var _a = Math.Pow(x: 1, y: 2) + Math.Pow(x: k, y: 2);
            var _b = -x0 * 2 + 2 * k * (b - y0);
            var _c = Math.Pow(x: x0, y: 2) + Math.Pow(x: (b - y0), y: 2) - Math.Pow(x: r, y: 2);

            var D = Math.Pow(x: _b, y: 2) - 4 * _a * _c; //Дискриминант

            var point1 = new PointF();
            var point2 = new PointF();

            point1.X = (float) ((-_b + Math.Sqrt(d: D)) / (2 * _a));
            point2.X = (float) ((-_b - Math.Sqrt(d: D)) / (2 * _a));

            point1.Y = (float) (k * point1.X + b);
            point2.Y = (float) (k * point2.X + b);

            var result = new TwoPoints
            {
                point1 = point1,
                point2 = point2
            };

            return result;
        }

        public static Line PerpendicularInPoint(Line line, PointF point)
        {
            var kperp = -1 / line.k;
            var bperp = point.Y - kperp * point.X;
            var result = new Line
            {
                k = kperp,
                b = bperp
            };

            return result;
        }

        public static double DistanceBetweenTwoPoints(PointF point1, PointF point2)
        {
            var x1 = point1.X;
            var y1 = point1.Y;
            var x2 = point2.X;
            var y2 = point2.Y;

            var distance = Math.Sqrt(d: Sqr(x: x2 - x1) + Sqr(x: y2 - y1));

            return distance;
        }

        public static Line LineFromTwoPoints(PointF point1, PointF point2)
        {
            var X1 = point1.X;
            var Y1 = point1.Y;
            var X2 = point2.X;
            var Y2 = point2.Y;
            //общее уравнение прямой
            var A = Y1 - Y2;
            var B = X2 - X1;
            var C = X1 * Y2 - X2 * Y1;

            //y=kx+b
            var k = (double) A / -B; //оставляем y слева, переносим все вправо - появляется -.
            var b = (double) C / -B;

            return new Line(k: k, b: b);
        }
    }
}