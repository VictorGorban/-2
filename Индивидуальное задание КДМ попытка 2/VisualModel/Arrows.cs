using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Индивидуальное_задание_КДМ_попытка_2.VisualModel
{
    public static class Arrows
    {
        public static bool Directed;
        public static List<Arrow> ArrowsQueue = new List<Arrow>(capacity: 50);

        public static void Clear()
        {
            Directed = false;
            ArrowsQueue.Clear();
        }

        public static void DrawTo(Graphics g)
        {
            foreach (var i in ArrowsQueue)
            {
                i.DrawTo(graphics: g);
            }
        }

        public static void Add(Node fromNode, Node toNode) //From, To?
        {
            if (fromNode == null || toNode == null)
            {
                MessageBox.Show(text: @"Отдан null параметр в добавление стрелки", caption: @"Ошибка!");
                return;
            }
            //здесь еще нужно проверить, нет ли такой стрелки уже.

            var newArrow = new Arrow(fromNode: fromNode, toNode: toNode);
            if (!ArrowsQueue.Exists(match: x => (x.FromNode == fromNode && x.ToNode == toNode))) //exists такой, что
            {
                ArrowsQueue.Add(item: new Arrow(fromNode: fromNode, toNode: toNode));
            }
        }

        public static void Remove(Node fromNode, Node toNode)
        {
            if (fromNode == null || toNode == null)
            {
                MessageBox.Show(text: @"Отдан null параметр в удаление стрелки", caption: @"Ошибка!");
                return;
            }
            //здесь еще нужно проверить, нет ли такой стрелки уже.

            var removedArrow = new Arrow(fromNode: fromNode, toNode: toNode);


            ArrowsQueue.RemoveAll(match: x => x.FromNode == fromNode && x.ToNode == toNode);
        }

        public static void Remove ( Node itemNode )
        {
            if (itemNode == null)
            {
                MessageBox.Show ( text: @"Отдан null параметр в удаление стрелки при удалении вершины", caption: @"Ошибка!" );
                return;
            }
            //здесь еще нужно проверить, нет ли такой стрелки уже.

            ArrowsQueue.RemoveAll ( match: x => x.FromNode == itemNode || x.ToNode == itemNode );
        }
    }
}