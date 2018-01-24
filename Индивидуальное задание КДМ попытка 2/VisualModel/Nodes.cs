using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Индивидуальное_задание_КДМ_попытка_2.VisualModel
{
    public static class Nodes
    {
        public static Node SelectedNode;

        //просто список вершин
        public static SortedList<string, Node> NodesList = new SortedList<string, Node>(capacity: 30);

        public static List<Node> QueueVisList = new List<Node>(capacity: 30);

        public static int Count => NodesList.Count;

        public static void Clear()
        {
            ClearSelection();
            NodesList.Clear();
            QueueVisList.Clear();
        }

        public static void ClearSelection()
        {
            SelectedNode = null;
        }

        public static void AddSelected(Node item)
        {
            SelectedNode = item;
        }

        public static void ToTop(string key)
        {
            var item = NodesList[key: key];
            QueueVisList.Remove(item: item);
            QueueVisList.Add(item: item);
        }

        public static void ToTop(Node item)
        {
            QueueVisList.Remove(item: item);
            QueueVisList.Add(item: item);
        }

        public static void Add(string key, Node value)
        {
            NodesList.Add(key: key, value: value);
            QueueVisList.Add(item: value);
        }

        public static void Remove(string key)
        {
            var itemRemove = NodesList[key: key];
            var indexRemove = NodesList.IndexOfKey(key: key);
            NodesList.Remove(key: key);
            ReindexingAfterRemove(nodesListIndexFrom: indexRemove);

            QueueVisList.Remove(item: itemRemove);
        }

        public static void Remove(Node item)
        {
            var indexRemove = NodesList.IndexOfValue(value: item);
            NodesList.RemoveAt(index: indexRemove);
            ReindexingAfterRemove(nodesListIndexFrom: indexRemove);

            QueueVisList.Remove(item: item);
        }

        private static void ReindexingAfterRemove(int nodesListIndexFrom)
        {
            if (nodesListIndexFrom >= NodesList.Count)
                return;
            //NodesList
            var a = NodesList.Keys;
            var firstNumber = int.Parse(s: a[index: nodesListIndexFrom]); //это я просто пропарсил ключ.
            var number = firstNumber;

            for (var i = nodesListIndexFrom; i < a.Count; i++)
            {
                var deletedItem = NodesList[key: a[index: i]];
                NodesList.Remove(key: a[index: i]); //хмм, а удалится ли самый последний?
                NodesList.Add(key: (number - 1).ToString(), value: deletedItem); //дважды ключа не будет.

                number++;
            }
        }

        public static void DrawTo(Graphics g)
        {
            var a = QueueVisList;
            var widthFont = SystemFonts.DefaultFont.Size; //возвращает ширину, надо же


            foreach (var currVisNode in a)
            {
                g.FillPath(brush: SelectedNode == currVisNode ? Brushes.Orange : Brushes.OrangeRed,
                    path: currVisNode
                        .GraphPath); //ух ты, даже лучше получилось, благодаря затемнению, которое дает верхняя панель!

                g.DrawPath(pen: SelectedNode == currVisNode ? Pens.LimeGreen : Pens.Black, path: currVisNode.GraphPath);
                //теперь текст. Он идет из Списка вершин, который с ключами.
                //смещение текста влево от центра
                var text = NodesList.Keys[index: NodesList.IndexOfValue(value: currVisNode)];
                var shiftLeft = widthFont * text.Length / 2;
                g.DrawString(s: text, font: SystemFonts.DefaultFont, brush: Brushes.Black,
                    x: currVisNode.Center.X - shiftLeft, y: currVisNode.Center.Y - 3);
            }
        }

        public static void DrawTo(PictureBox picBox)
        {
            //теперь я типа рисую на этой bitmap. Каждое изменение в g - на BitMap.
            var g = Graphics.FromImage(image: picBox.Image);
            var a = QueueVisList;
            var widthFont = SystemFonts.DefaultFont.Size; //возвращает ширину, надо же


            foreach (var currVisNode in a)
            {
                g.FillPath(brush: SelectedNode == currVisNode ? Brushes.Orange : Brushes.OrangeRed,
                    path: currVisNode
                        .GraphPath); //ух ты, даже лучше получилось, благодаря затемнению, которое дает верхняя панель!

                g.DrawPath(pen: SelectedNode == currVisNode ? Pens.LimeGreen : Pens.Black, path: currVisNode.GraphPath);
                //теперь текст. Он идет из Списка вершин, который с ключами.
                //смещение текста влево от центра
                var text = NodesList.Keys[index: NodesList.IndexOfValue(value: currVisNode)];
                var shiftLeft = widthFont * text.Length / 2;
                g.DrawString(s: text, font: SystemFonts.DefaultFont, brush: Brushes.Black,
                    x: currVisNode.Center.X - shiftLeft, y: currVisNode.Center.Y - 3);
            }
            picBox.Refresh();
        }
    }
}