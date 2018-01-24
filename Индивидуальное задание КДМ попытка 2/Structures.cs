using System.Drawing;

namespace Индивидуальное_задание_КДМ_попытка_2
{
    public struct TwoPoints
    {
        public PointF point1, point2;

        public new string ToString => point1 + ", " + point2;
    }

    public struct Line //по типу y=kx + b
    {
        public double k, b;

        public Line ( double k, double b )
        {
            this.k = k;
            this.b = b;
        }

        public new string ToString => "y = " + k.ToString ( format: "0.###" ) + "x + " + b.ToString ( format: "0.###" );
    }

    public struct Circle//по типу (x-x0)^2 + (y-y0)^2 = R^2
    {
        public double x0, y0, R;

        public Circle ( double x0, double y0, double R )
        {
            this.x0 = x0;
            this.y0 = y0;
            this.R = R;
        }

        public Circle(PointF center, double R)
        {
            x0 = center.X;
            y0 = center.Y;
            this.R = R;
        }

        public new string ToString => "(x - " + x0.ToString ( format: "0.###" ) + ") + (y - " + y0.ToString ( format: "0.###" ) + ") = " + R.ToString ( format: "0.###" ) + "^2";
    }
}
