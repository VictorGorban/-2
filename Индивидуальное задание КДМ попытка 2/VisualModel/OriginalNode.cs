using System.Drawing;
using System.Drawing.Drawing2D;

namespace Индивидуальное_задание_КДМ_попытка_2.VisualModel
{
    public class OriginalNode: Node
    {//разница с родителем только в DrawTo() и в допконструкторе;
        public OriginalNode(Node original)
        {
            _locationPoint = original.Location;
            _centerPoint = original.Center;
        }

        public void DrawTo(Graphics g)
        {
            var brushForBody = new HatchBrush( hatchstyle: HatchStyle.DiagonalCross, foreColor: Color.Wheat, backColor: Color.FromArgb ( alpha: 0, red: 0, green: 0, blue: 0 ) );
            var brushForPen = new HatchBrush(hatchstyle: HatchStyle.DiagonalCross, foreColor: Color.LimeGreen, backColor: Color.FromArgb(alpha: 0,red: 0,green: 0,blue: 0));
            var pen = new Pen(brush: brushForPen ,width: 2);
            g.FillPath ( brush: brushForBody,
                path: GraphPath );

            g.DrawPath ( pen: pen, path: GraphPath );
        }
  
    }
}