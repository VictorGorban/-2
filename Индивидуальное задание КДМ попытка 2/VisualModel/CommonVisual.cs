using System.Drawing;
using System.Windows.Forms;

namespace Индивидуальное_задание_КДМ_попытка_2.VisualModel
{
    static class CommonVisual
    {
        public static void DrawTo(PictureBox picBox)
        {
            picBox.Image = new Bitmap(width: picBox.Width, height: picBox.Height);
            var g = Graphics.FromImage(image: picBox.Image);//вот почему здесь все ок, обновляется, а в другом случае, когда я вызываю это из NewNode_Click - нет, приходится писать refresh???
            Arrows.DrawTo(g: g);
            Nodes.DrawTo(g: g);
            picBox.Update();
        }
    }
}
