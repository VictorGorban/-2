using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Индивидуальное_задание_КДМ_попытка_2.VisualModel
{
    [Serializable]
    public class Node 
    {
        public const int R = 22; //const уже static. Окей.

        protected Point _locationPoint; 

        protected Point _centerPoint;
        public GraphicsPath GraphPath ;

        public Point Location
        {
            get => _locationPoint;
            set
            {
                _locationPoint = value;
                CalcCenterUsingLocation();

                var gp = new GraphicsPath();
                gp.AddEllipse(
                    rect: new Rectangle(location: _locationPoint, size: new Size(width: R * 2, height: R * 2)));
                GraphPath = gp;
            }
        }

        public Point Center
        {
            get => _centerPoint;
            set
            {
                _centerPoint = value;
                CalcLocationUsingCenter();

                var gp = new GraphicsPath();
                gp.AddEllipse(
                    rect: new Rectangle(location: _locationPoint, size: new Size(width: R * 2, height: R * 2)));
                GraphPath = gp;
            }
        }

        protected Node() //чисто чтобы можно было реализовать наследование
        {
            _locationPoint = _centerPoint = new Point(x: 0, y: 0);
        }

        public Node(Point centerPoint)
        {
            Center = centerPoint; 
        }

        private void CalcCenterUsingLocation()
        {
            _centerPoint.X = _locationPoint.X + R;
            _centerPoint.Y = _locationPoint.Y + R;
        }

        private void CalcLocationUsingCenter()
        {
            _locationPoint.X = _centerPoint.X - R;
            _locationPoint.Y = _centerPoint.Y - R;
        }

    }

}