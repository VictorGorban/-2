using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Индивидуальное_задание_КДМ_попытка_2
{
    public partial class Form1 : Form
    {
        private Acts CurrentAct;
        private VisualModel.Node pointedNode;
        private readonly Image _defaultImg;
        private bool isChangedImage = false;
        private Image oldPathImage;
        private Image oldImage;

        private Point _startDragPoint;
        //private Rectangle RedrawingArea;

        public Form1()
        {
            InitializeComponent();
            _defaultImg = new Bitmap(width: pbDrawing.Width, height: pbDrawing.Height);
            oldPathImage = _defaultImg; //по умолчанию такой, потом, может, изменится.
            pbDrawing.Image = new Bitmap(pbDrawing.Width, pbDrawing.Height);
            pictureBox1.Image = new Bitmap(pbDrawing.Width, pbDrawing.Height);
            pictureBox1.BackColor =
                Color.FromArgb(35,
                    Color.DarkRed); //Что???? Задавание Сolor.FromArgb делает контрол прокликиваемым, серьезно???
            pictureBox1.Parent = pbDrawing;
            pictureBox1.Image = new Bitmap(pbDrawing.Width, pbDrawing.Height);
        }


        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void NewNode_Click(object sender, EventArgs e)
        {
            CurrentAct = Acts.AddNode;
            VisualModel.Nodes.ClearSelection();
            VisualModel.Nodes.DrawTo(pbDrawing);

            tbAct.Text = @"Укажите, куда добавить вершину";
        }

        private void ConnectNodesButton_Click(object sender, EventArgs e)
        {
            CurrentAct = Acts.ConnectNodes;
            VisualModel.Nodes.ClearSelection();
            VisualModel.Nodes.DrawTo(pbDrawing);

            tbAct.Text = @"Укажите соединяемые вершины";
        }

        private void ButtonMove_Click(object sender, EventArgs e)
        {
            CurrentAct = Acts.MoveNode;
            VisualModel.Nodes.ClearSelection();
            VisualModel.Nodes.DrawTo(pbDrawing);
            tbAct.Text = @"Потяните вершину";

            //само действие
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            CurrentAct = Acts.Delete;
            VisualModel.Nodes.ClearSelection();
            VisualModel.Nodes.DrawTo(pbDrawing);
            tbAct.Text = @"Укажите, что удалить";

            //само действие
        }

        public enum Acts
        {
            Nothing,
            AddNode,
            ConnectNodes,
            MoveNode,
            Delete
        };

        private void newFileButton_Click(object sender, EventArgs e)
        {
            DataModel.Nodes.Clear();
            VisualModel.Nodes.Clear();
            VisualModel.Arrows.Clear();
            pbDrawing.Enabled = true;
            tbAct.Text = string.Empty;
            pbDrawing.Image = new Bitmap(pbDrawing.Width, pbDrawing.Height);

            if (MessageBox.Show(text: "Создать ориентрированный граф?", caption: "",
                    buttons: MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                VisualModel.Arrows.Directed = true;
            }
            else
            {
                VisualModel.Arrows.Directed = false;
            }

            foreach (var i in toolStrip1.Items)
            {
                if ((i as ToolStripItem).Enabled == false)
                {
                    (i as ToolStripItem).Enabled = true;
                }
            }
        }

        private void pbDrawing_MouseClick(object sender, MouseEventArgs e)
        {
            switch (CurrentAct)
            {
                case Acts.AddNode:
                    var key = (DataModel.Nodes.Count + 1).ToString();
                    DataModel.Nodes.Add(
                        key: key, value: new DataModel.Node(key: key)); //+1 - чтобы шло с единицы, а не с нуля
                    //1.2 VisualModel
                    var visNode =
                        new VisualModel.Node(
                            centerPoint: e.Location); //так, ну это Location относительно угла pictureBox
                    VisualModel.Nodes.Add(key: key, value: visNode);
                    VisualModel.Nodes.DrawTo(pbDrawing);
                    break;


                case Acts.ConnectNodes:

                    //Так, ну прежде всего надо разобраться с кликом. Хотя бы на уровне выделения вершин.
                    //Ну что это такое, серьезно, после добавления стрелки клик как будто нажимается еще раз, 
                    //но уже для вершины, которая за этой??? Непорядок.
                    for (var i = VisualModel.Nodes.QueueVisList.Count - 1;
                        i >= 0;
                        i--) //типа иду с конца, т.к. добавляю я новую вершину в конец, и мне надо найти самую "верхнюю вершину" с подходящим graphpath
                    {
                        if (VisualModel.Nodes.QueueVisList[index: i].GraphPath.IsVisible(point: e.Location)
                        ) //нашли-таки эту вершину
                        {
                            var itemNode = VisualModel.Nodes.QueueVisList[index: i];
                            //VisualModel.Nodes.ToTop(item: itemNode);//Хм, а зачем это? и так будет видно выглядывающий кусок желтизны.
                            if (VisualModel.Nodes.SelectedNode != null)
                            {
                                if (VisualModel.Nodes.SelectedNode != itemNode)
                                {
                                    //добавляем стрелку
                                    VisualModel.Arrows.Add(fromNode: VisualModel.Nodes.SelectedNode, toNode: itemNode);

                                    //а еще связать вершины в DataModel...
                                    var list = VisualModel.Nodes.NodesList;
                                    var listKeys = list.Keys;
                                    var firstKey =listKeys[list.IndexOfValue(VisualModel.Nodes.SelectedNode)]; 
                                    var secondKey = listKeys[list.IndexOfValue(itemNode)];

                                    DataModel.Nodes.TryConnect(firstKey, secondKey);

                                    VisualModel.Nodes.ClearSelection(); //все, выделения больше нет.
                                }
                            }
                            else
                            {
                                VisualModel.Nodes.SelectedNode = itemNode;
                            }
                            
                            break;
                        }
                    }
                    //Вызов прорисовки
                    VisualModel.CommonVisual.DrawTo ( pbDrawing );

                    /*if (VisualModel.Nodes.SelectedNode != null)
                    {
                        //ну вот зачем я это делаю здесь, не пойму? Я ж так не могу добавить стрелку! Каждый клик - Selected==null.
                        VisualModel.Nodes.ClearSelection(); //в конце события все равно все обновится
                    }*/
                    break;


                case Acts.Delete: //Ураа, это тоже рабочее
                    for (var i = VisualModel.Nodes.QueueVisList.Count - 1;
                        i >= 0;
                        i--) //типа иду с конца, т.к. добавляю я новую вершину в конец, и мне надо найти самую "верхнюю вершину" с подходящим graphpath
                    {
                        if (VisualModel.Nodes.QueueVisList[index: i].GraphPath.IsVisible(point: e.Location)
                        ) //нашли-таки эту вершину
                        {
                            var itemNode = VisualModel.Nodes.QueueVisList[index: i];
                            if (VisualModel.Nodes.SelectedNode != null)
                            {
                                if (VisualModel.Nodes.SelectedNode != itemNode)
                                {
                                    //удаляем стрелку
                                    VisualModel.Arrows.Remove(fromNode: VisualModel.Nodes.SelectedNode,
                                        toNode: itemNode);

                                    //а еще удалить из DataModel...
                                    var list = VisualModel.Nodes.NodesList;
                                    var listKeys = list.Keys;
                                    var firstKey = listKeys[list.IndexOfValue(VisualModel.Nodes.SelectedNode)];
                                    var secondKey = listKeys[list.IndexOfValue(itemNode)];

                                    DataModel.Nodes.TryDisconnect(firstKey, secondKey);

                                    VisualModel.Nodes.ClearSelection(); //все, выделения больше нет.
                                }
                            }
                            else
                            {
                                VisualModel.Nodes.SelectedNode = itemNode;
                            }
                            //Вызов прорисовки
                            VisualModel.CommonVisual.DrawTo ( pbDrawing );
                            break;
                        }
                    }
                    

                    break;
            }
            
        }

        private void pbDrawing_MouseDoubleClick(object sender, MouseEventArgs e)
        {//Ладно, это - рабочее.
            if (CurrentAct == Acts.Delete)
            {
                for (var i = VisualModel.Nodes.QueueVisList.Count - 1;
                    i >= 0;
                    i--) //типа иду с конца, т.к. добавляю я новую вершину в конец, и мне надо найти самую "верхнюю вершину" с подходящим graphpath
                {
                    if (VisualModel.Nodes.QueueVisList[index: i].GraphPath.IsVisible(point: e.Location)
                    ) //нашли-таки эту вершину
                    {
                        var itemNode = VisualModel.Nodes.QueueVisList[index: i];
                        //удаляем вершину
                        var list = VisualModel.Nodes.NodesList;
                        
                        var firstKey = list.Keys[list.IndexOfValue(itemNode)];

                        DataModel.Nodes.Remove(firstKey);

                        VisualModel.Nodes.ClearSelection(); //все, выделения больше нет.

                        VisualModel.Nodes.Remove(itemNode);
                        VisualModel.Arrows.Remove(itemNode);
                    }
                }
                VisualModel.CommonVisual.DrawTo(pbDrawing);
            }
        }

        private void pbDrawing_MouseMove(object sender, MouseEventArgs e)
        {
            if (CurrentAct != Acts.AddNode)
            {
                var list = VisualModel.Nodes.QueueVisList;

                if (isChangedImage)
                {
                    pictureBox1.Image = new Bitmap(pbDrawing.Width, pbDrawing.Height); //прозрачный типа
                    isChangedImage = false;
                }

                for (var i = list.Count - 1; i >= 0; i--)
                {
                    if (list[index: i].GraphPath.IsVisible(point: e.Location))
                    {
//нашли самую верхнюю, что туда входит
                        if (list[index: i] != VisualModel.Nodes.SelectedNode)
                        {
                            var currVisNode = list[index: i];
                            isChangedImage = true;

                            using (var g = Graphics.FromImage(pictureBox1.Image))
                            {
                                g.FillPath(brush: Brushes.Orange, path: currVisNode.GraphPath);
                                g.DrawPath(pen: Pens.LimeGreen, path: currVisNode.GraphPath);


                                var text = VisualModel.Nodes.NodesList.Keys[
                                    index: VisualModel.Nodes.NodesList.IndexOfValue(value: currVisNode)];
                                var widthFont = SystemFonts.DefaultFont.Size; //возвращает ширину, надо же
                                var shiftLeft = widthFont * text.Length / 2;
                                g.DrawString(s: text, font: SystemFonts.DefaultFont, brush: Brushes.Red,
                                    x: currVisNode.Center.X - shiftLeft, y: currVisNode.Center.Y - 3);
                                pictureBox1.Update();
                            }
                            pointedNode = currVisNode;
                        }
                        break;
                    }
                }
                pointedNode = null;
            }

            if (CurrentAct == Acts.MoveNode)
            {//реализую перемещение
                
            }
        }

        private void pbDrawing_MouseLeave(object sender, EventArgs e)
        {
            if (isChangedImage)
            {
                pictureBox1.Image = new Bitmap(pbDrawing.Width, pbDrawing.Height);
                isChangedImage = false;
            }
        }
    }
}