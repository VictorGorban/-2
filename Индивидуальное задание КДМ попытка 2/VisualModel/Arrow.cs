using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static Индивидуальное_задание_КДМ_попытка_2.Algorythms;

namespace Индивидуальное_задание_КДМ_попытка_2.VisualModel
{
    public class Arrow
    {
        public Node FromNode { get; set; }

        public Node ToNode { get; set; }

        public Arrow(Node fromNode, Node toNode)
        {
            FromNode = fromNode;
            ToNode = toNode;
        }

        public bool DrawTo(PictureBox pb) //true - нарисовалось, false - нет.
        {
            if (DistanceBetweenTwoPoints(point1: FromNode.Center, point2: ToNode.Center) <= 2 * Node.R)
            {
                return false; //А чего рисовать, если стрелка все равно будет скрыта за этими вершинами?
            }

            var line = LineFromTwoPoints(point1: FromNode.Center, point2: ToNode.Center);
            var twop1 = IntersectionLineAndCircle(line: line, circle: new Circle(center: FromNode.Center, R: Node.R));
            var twop2 = IntersectionLineAndCircle(line: line, circle: new Circle(center: ToNode.Center, R: Node.R));

            PointF point1Arrow = default(PointF);
            PointF point2Arrow = default(PointF);

            {
//Здесь я узнаю, у какой пары расстояние минимальное.
                //варианты: 11 21  11 22  12 21  12 22
                var a = new[]
                {
                    DistanceBetweenTwoPoints(point1: twop1.point1, point2: twop2.point1),
                    DistanceBetweenTwoPoints(point1: twop1.point1, point2: twop2.point2),
                    DistanceBetweenTwoPoints(point1: twop1.point2, point2: twop2.point1),
                    DistanceBetweenTwoPoints(point1: twop1.point2, point2: twop2.point2)
                };
                var min = a.Min(); // double min
                var indexMin = Array.IndexOf(array: a, value: min);

                switch (indexMin)
                {
                    case 0:
                        point1Arrow = twop1.point1;
                        point2Arrow = twop2.point1;
                        break;
                    case 1:
                        point1Arrow = twop1.point1;
                        point2Arrow = twop2.point2;
                        break;
                    case 2:
                        point1Arrow = twop1.point2;
                        point2Arrow = twop2.point1;
                        break;
                    case 3:
                        point1Arrow = twop1.point2;
                        point2Arrow = twop2.point2;
                        break;
                }
                if (pb.Image == null)
                {
                    MessageBox.Show(text: "Нельзя нарисовать стрелку на изображении, которого нет. Сейчас должно вылететь исключение.", caption: @"Ошибка!");
                }
                var g = Graphics.FromImage(image: pb.Image);
                var pen = new Pen(color: Color.Black, width: 2);
                g.DrawLine(pen: pen, pt1: point1Arrow, pt2: point2Arrow);
                if (Arrows.Directed)
                {
                    //высчитываю пересечение с кругом R... 4 пикселя. Узнаю, какая точка ближе к началу. От этой точки - перпендикуляр, узнаю точки пересечения с кругом радиусом... 2 пкс. Строю от этих точек в начало линии. А также линию, соед. эти точки.
                    var twopForCalcArrowHead = IntersectionLineAndCircle(line: line, circle: new Circle(center: point2Arrow, R: 4));
                    var pointForArrowHead =
                        DistanceBetweenTwoPoints(point1: twopForCalcArrowHead.point1, point2: point1Arrow) <
                        DistanceBetweenTwoPoints(point1: twopForCalcArrowHead.point2, point2: point1Arrow)
                            ? twopForCalcArrowHead.point1
                            : twopForCalcArrowHead.point2;

                    var perpLine = PerpendicularInPoint(line: line, point: pointForArrowHead);
                    var twopApexArrowHead = IntersectionLineAndCircle(line: perpLine, circle: new Circle(center: pointForArrowHead, R: 2));

                    g.DrawLine(pen: pen, pt1: twopApexArrowHead.point1, pt2: point2Arrow);
                    g.DrawLine(pen: pen, pt1: twopApexArrowHead.point2, pt2: point2Arrow);
                }
            }


            return true;
        }

        public bool DrawTo(Graphics graphics)
        {
            if (DistanceBetweenTwoPoints(point1: FromNode.Center, point2: ToNode.Center ) <= 2 * Node.R)
            {
                return false; //А чего рисовать, если стрелка все равно будет скрыта за этими вершинами?
            }

            var line = LineFromTwoPoints(point1: FromNode.Center, point2: ToNode.Center );
            var twop1 = IntersectionLineAndCircle(line: line, circle: new Circle(center: FromNode.Center, R: Node.R));
            var twop2 = IntersectionLineAndCircle(line: line, circle: new Circle(center: ToNode.Center, R: Node.R));

            PointF point1Arrow = default(PointF);
            PointF point2Arrow = default(PointF);

            {
//Здесь я узнаю, у какой пары расстояние минимальное.
                //варианты: 11 21  11 22  12 21  12 22
                var a = new[]
                {
                    DistanceBetweenTwoPoints(point1: twop1.point1, point2: twop2.point1),
                    DistanceBetweenTwoPoints(point1: twop1.point1, point2: twop2.point2),
                    DistanceBetweenTwoPoints(point1: twop1.point2, point2: twop2.point1),
                    DistanceBetweenTwoPoints(point1: twop1.point2, point2: twop2.point2)
                };
                var min = a.Min(); // double min
                var indexMin = Array.IndexOf(array: a, value: min);

                switch (indexMin)
                {
                    case 0:
                        point1Arrow = twop1.point1;
                        point2Arrow = twop2.point1;
                        break;
                    case 1:
                        point1Arrow = twop1.point1;
                        point2Arrow = twop2.point2;
                        break;
                    case 2:
                        point1Arrow = twop1.point2;
                        point2Arrow = twop2.point1;
                        break;
                    case 3:
                        point1Arrow = twop1.point2;
                        point2Arrow = twop2.point2;
                        break;
                }

                var g = graphics;
                var pen = new Pen(color: Color.Black, width: 2);
                g.DrawLine(pen: pen, pt1: point1Arrow, pt2: point2Arrow);
                if (Arrows.Directed)
                {
                    //высчитываю пересечение с кругом R... 4 пикселя. Узнаю, какая точка ближе к началу. От этой точки - перпендикуляр, узнаю точки пересечения с кругом радиусом... 2 пкс. Строю от этих точек в начало линии. А также линию, соед. эти точки.
                    var twopForCalcArrowHead = IntersectionLineAndCircle(line: line, circle: new Circle(center: point2Arrow, R: 6));
                    var pointForArrowHead =
                        DistanceBetweenTwoPoints(point1: twopForCalcArrowHead.point1, point2: point1Arrow) <
                        DistanceBetweenTwoPoints(point1: twopForCalcArrowHead.point2, point2: point1Arrow)
                            ? twopForCalcArrowHead.point1
                            : twopForCalcArrowHead.point2;

                    var perpLine = PerpendicularInPoint(line: line, point: pointForArrowHead);
                    var twopApexArrowHead = IntersectionLineAndCircle(line: perpLine, circle: new Circle(center: pointForArrowHead, R: 4));

                    g.DrawLine(pen: pen, pt1: twopApexArrowHead.point1, pt2: point2Arrow);
                    g.DrawLine(pen: pen, pt1: twopApexArrowHead.point2, pt2: point2Arrow);
                    g.DrawLine(pen, twopApexArrowHead.point1, twopApexArrowHead.point2);
                }
            }


            return true;
        }
    }
}