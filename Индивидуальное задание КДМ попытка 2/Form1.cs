using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Индивидуальное_задание_КДМ_попытка_2
{
    public partial class Form1 : Form
    {
        private Acts CurrentAct;
        private VisualModel.OriginalNode originalNode;
        private string _defaultFilePath = null;
        private bool isChangedImage;
        private Image oldImage;

        private Point _startDragPoint;

        public Form1()
        {
            InitializeComponent();
            new Bitmap(width: pbDrawing.Width, height: pbDrawing.Height);
            pbDrawing.Image = new Bitmap(width: pbDrawing.Width, height: pbDrawing.Height);
            pictureBox1.Image = new Bitmap(width: pbDrawing.Width, height: pbDrawing.Height);
            pictureBox1.BackColor =
                Color.FromArgb(alpha: 35,
                    baseColor: Color
                        .DarkRed); //Что???? Задавание Сolor.FromArgb делает контрол прокликиваемым, серьезно???
            pictureBox1.Parent = pbDrawing;
            pictureBox1.Image = new Bitmap(width: pbDrawing.Width, height: pbDrawing.Height);
        }


        private void NewNode_Click(object sender, EventArgs e)
        {
            CurrentAct = Acts.AddNode;
            tbAct.Text = @"Укажите, куда добавить вершину";
        }

        private void ConnectNodesButton_Click(object sender, EventArgs e)
        {
            CurrentAct = Acts.ConnectNodes;
            tbAct.Text = @"Укажите соединяемые вершины";
        }

        private void ButtonMove_Click(object sender, EventArgs e)
        {
            CurrentAct = Acts.MoveNode;
            tbAct.Text = @"Потяните вершину";
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            CurrentAct = Acts.Delete;
            tbAct.Text = @"Укажите, что удалить";
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
            pbDrawing.Image = new Bitmap(width: pbDrawing.Width, height: pbDrawing.Height);

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
                    VisualModel.Nodes.DrawTo(picBox: pbDrawing);
                    break;


                case Acts.ConnectNodes:

                    for (var i = VisualModel.Nodes.QueueVisList.Count - 1;
                        i >= 0;
                        i--) 
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

                                    if (!VisualModel.Arrows.Directed)
                                    {
                                        VisualModel.Arrows.Add(fromNode: itemNode,
                                            toNode: VisualModel.Nodes.SelectedNode);
                                    }

                                    //а еще связать вершины в DataModel...
                                    var list = VisualModel.Nodes.NodesList;
                                    var listKeys = list.Keys;
                                    var firstKey =
                                        listKeys[index: list.IndexOfValue(value: VisualModel.Nodes.SelectedNode)];
                                    var secondKey = listKeys[index: list.IndexOfValue(value: itemNode)];

                                    DataModel.Nodes.TryConnect(first: firstKey, second: secondKey);
                                    if (!VisualModel.Arrows.Directed)
                                    {
                                        DataModel.Nodes.TryConnect(first: secondKey, second: firstKey);
                                    }

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
                    VisualModel.CommonVisual.DrawTo(picBox: pbDrawing);

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
                                    if (!VisualModel.Arrows.Directed)
                                    {
                                        VisualModel.Arrows.Remove(fromNode: itemNode,
                                            toNode: VisualModel.Nodes.SelectedNode);
                                    }

                                    //а еще удалить из DataModel...
                                    var list = VisualModel.Nodes.NodesList;
                                    var listKeys = list.Keys;
                                    var firstKey =
                                        listKeys[index: list.IndexOfValue(value: VisualModel.Nodes.SelectedNode)];
                                    var secondKey = listKeys[index: list.IndexOfValue(value: itemNode)];

                                    DataModel.Nodes.TryDisconnect(first: firstKey, second: secondKey);
                                    if (!VisualModel.Arrows.Directed)
                                    {
                                        DataModel.Nodes.TryDisconnect(first: secondKey, second: firstKey);
                                    }
                                    VisualModel.Nodes.ClearSelection(); //все, выделения больше нет.
                                }
                            }
                            else
                            {
                                VisualModel.Nodes.SelectedNode = itemNode;
                            }
                            //Вызов прорисовки
                            VisualModel.CommonVisual.DrawTo(picBox: pbDrawing);
                            break;
                        }
                    }


                    break;
            }
        }

        private void pbDrawing_MouseDoubleClick(object sender, MouseEventArgs e)
        {
//Ладно, это - рабочее.
            if (CurrentAct == Acts.Delete)
            {
                for (var i = VisualModel.Nodes.QueueVisList.Count - 1;
                    i >= 0;
                    i--) 
                {
                    if (VisualModel.Nodes.QueueVisList[index: i].GraphPath.IsVisible(point: e.Location)
                    ) //нашли-таки эту вершину
                    {
                        var itemNode = VisualModel.Nodes.QueueVisList[index: i];
                        //удаляем вершину
                        var list = VisualModel.Nodes.NodesList;

                        var firstKey = list.Keys[index: list.IndexOfValue(value: itemNode)];

                        DataModel.Nodes.Remove(key: firstKey);

                        VisualModel.Nodes.ClearSelection(); //все, выделения больше нет.

                        VisualModel.Nodes.Remove(item: itemNode);
                        VisualModel.Arrows.Remove(itemNode: itemNode);
                        break;
                    }
                }
                VisualModel.CommonVisual.DrawTo(picBox: pbDrawing);
            }
        }

        private void pbDrawing_MouseMove(object sender, MouseEventArgs e)
        {
            if (CurrentAct == Acts.MoveNode && VisualModel.Nodes.SelectedNode != null)
            {
//реализую "перемещение"
                //присваиваю ей новые координаты и вывожу на picBox1.
                originalNode.Center = e.Location;

                pictureBox1.Image = new Bitmap(width: pbDrawing.Width, height: pbDrawing.Height); //прозрачный типа
                originalNode.DrawTo(g: Graphics.FromImage(image: pictureBox1.Image));
                return;
            }

            if (CurrentAct != Acts.AddNode)
            {
                var list = VisualModel.Nodes.QueueVisList;

                if (isChangedImage)
                {
                    pictureBox1.Image = new Bitmap(width: pbDrawing.Width, height: pbDrawing.Height); //прозрачный типа
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

                            using (var g = Graphics.FromImage(image: pictureBox1.Image))
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
                        }
                        break;
                    }
                }
            }

            if (CurrentAct == Acts.MoveNode)
            {
//реализую перемещение
            }
        }

        private void pbDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            if (CurrentAct == Acts.MoveNode && VisualModel.Nodes.SelectedNode != null)
            {
                pictureBox1.Image = new Bitmap(width: pictureBox1.Width, height: pictureBox1.Height);
                VisualModel.Nodes.SelectedNode.Center = originalNode.Center;
                VisualModel.Nodes.ClearSelection();
                VisualModel.CommonVisual.DrawTo(picBox: pbDrawing);
            }
        }

        private void pbDrawing_MouseDown(object sender, MouseEventArgs e)
        {
            if (CurrentAct == Acts.MoveNode)
            {
                var list = VisualModel.Nodes.QueueVisList;

                for (var i = list.Count - 1; i >= 0; i--)
                {
                    if (list[index: i].GraphPath.IsVisible(point: e.Location))
                    {
                        //нашли самую верхнюю, что туда входит
                        VisualModel.Nodes.AddSelected(item: list[index: i]);
                        VisualModel.Nodes.DrawTo(picBox: pbDrawing);

                        //делаю эту самую недопрозрачную вершину.
                        originalNode = new VisualModel.OriginalNode(original: VisualModel.Nodes.SelectedNode);
                        break;
                    }
                }
            }
        }

        private void pbDrawing_MouseLeave(object sender, EventArgs e)
        {
            if (isChangedImage)
            {
                pictureBox1.Image = new Bitmap(width: pbDrawing.Width, height: pbDrawing.Height);
                isChangedImage = false;
            }
            VisualModel.Nodes.ClearSelection();
            VisualModel.Nodes.DrawTo(picBox: pbDrawing);
        }

        private void AdjoinStructButton_Click(object sender, EventArgs e)
        {
            //такс, я должен где-нибудь в MessageBox вывести эти строки.
            var list = DataModel.Nodes.NodesList;
            var ms = new StringBuilder[list.Count];

            for (var i = 0; i < list.Count; i++)
            {
                ms[i] = new StringBuilder(capacity: list.Count * 2);
                var currListNodes = list.Values[index: i].AdjoiningNodes;
                ms[i].Append(value: (i + 1) + ": ");
                foreach (var node in currListNodes)
                {
                    ms[i].Append(value: node.Key + ", ");
                }
                if (currListNodes.Count > 0)
                {
                    ms[i].Remove(startIndex: ms[i].Length - 2, length: 2);
                }

            }


            var reslength = 0;
            foreach (var i in ms) //linq я не пойму, так что оставлю так.
            {
                reslength += i.Length;
            }
            var resString = new StringBuilder(capacity: reslength);
            foreach (var i in ms)
            {
                resString.AppendLine(value: i.ToString());
            }
            if (resString.Length == list.Count)
            {
                resString = new StringBuilder(value: "Пусто");
            }

            MessageBox.Show(text: resString.ToString(), caption: @"Структура смежности");
        }

        private void saveButton_Click(object sender = null, EventArgs e = null)
        {
            if (string.IsNullOrEmpty(_defaultFilePath))
            {
                saveAsButton_Click();
                return;
            }
            //чисто сохранение в файл. Надо, наверное, обернуть в try. Если что-то не получится, сказать об этом... И запустить, опять же, saveAs.
            FileStream fstream = null;
            try
            {
                fstream =
                    File.Open(_defaultFilePath,
                        FileMode.Create); //отлично, если файл существует, он будет перезаписан. Если нет - то будет создан новый.
                var streamWriter = new StreamWriter(fstream, Encoding.Unicode);
                //так, теперь начинаем все записывать.
                /*
                 Что надо записать:
                DataModel:                 1) NodesList //можно записать в виде как раз структуры данных, несложно//кстати, при считывании нужно проследить, чтобы считываемая строка не была IsNullOrEmpty
                VisualModel: //SelectedNode не будет, я ж снимаю выделение при уходе с поля
                2) Nodes.NodesList //ключи можно, а с ними - координаты центра.
                 3)Nodes.QueueList //КАААААК???? Придется записывать ключи в NodesList (getKeyByValue)
                 4)Arrows.ArrowsQueue //записывать пары "Ключ вершины от - Ключ вершины до"
                 5)Arrows.Directed //тут false или true. При считывании придется проверить, как парсится.
                 //при считывании, чтобы избежать парсинга, можно проверять ключи на isDigit(посимвольно, наверное).
                 */
                if (DataModel.Nodes.NodesList.Count == 0)
                {
                    streamWriter.WriteLine("Пустой граф");
                    streamWriter.WriteLine("Ориентированный ли:");
                    streamWriter.WriteLine(VisualModel.Arrows.Directed);
                    streamWriter.Flush();
                    return;
                }
                streamWriter.WriteLine("Структура смежности:");
                foreach (var value in DataModel.Nodes.NodesList)
                {
                    streamWriter.Write(value.Key + ":");
                    foreach (var node in value.Value.AdjoiningNodes)
                    {
                        streamWriter.Write(" " + node.Key);
                    }

                    streamWriter.WriteLine();
                } //это записали NodesList

                streamWriter.WriteLine("Центры вершин:");
                foreach (var visNode in VisualModel.Nodes.NodesList)
                {
                    streamWriter.WriteLine(visNode.Key + ": " + visNode.Value.Center);
                }

                streamWriter.WriteLine("Порядок прорисовки вершин:");
                foreach (var visNode in VisualModel.Nodes.QueueVisList)
                {
                    var index = VisualModel.Nodes.NodesList.IndexOfValue(visNode);
                    streamWriter.Write(VisualModel.Nodes.NodesList.Keys[index]);
                }
                streamWriter.WriteLine();

                streamWriter.WriteLine("Стрелки:");
                foreach (var arrow in VisualModel.Arrows.ArrowsQueue)
                {
                    var indexFrom = VisualModel.Nodes.NodesList.IndexOfValue(arrow.FromNode);
                    var indexTo = VisualModel.Nodes.NodesList.IndexOfValue(arrow.ToNode);
                    var key1 = VisualModel.Nodes.NodesList.Keys[indexFrom];
                    var key2 = VisualModel.Nodes.NodesList.Keys[indexTo];

                    streamWriter.WriteLine("from " + key1 + " to " + key2);
                }

                streamWriter.WriteLine("Ориентированный ли:");
                streamWriter.WriteLine(VisualModel.Arrows.Directed);

                streamWriter.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Не удается создать или заменить файл.", @"Ошибка!");
                fstream?.Close();
            }
            finally
            {
                fstream?.Close();
            }
        }

        private void saveAsButton_Click(object sender = null, EventArgs e = null)
        {
            var dialog = new SaveFileDialog
            {
                Filter = @"Text File|*.txt",
                Title = @"Сохранение графа",
                FileName = "graph"
            };
            dialog.ShowDialog();

            if (dialog.FileName != "")
            {
                _defaultFilePath = dialog.FileName;
                saveButton_Click();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
//Компоненты связности. Для неориентированного - работает, для ориентированного - нет.
            var NodesList = DataModel.Nodes.NodesList;
            var Mark = new SortedList<string, int>(NodesList.Count);
            var count = 0;
            if (NodesList.Count > 0)
            {
                //сам алгоритм
                foreach (var value in NodesList)
                {
//заполнение массива меток по умолчанию
                    Mark.Add(value.Key, 0);
                }

                for (var i = 0; i < Mark.Keys.Count; i++)
                {
                    if (Mark[Mark.Keys[i]] == 0)
                    {
                        count++;
                        Component(Mark.Keys[i]);
                    }
                }

                void Component ( string key )
                {
                    Mark[key] = count;
                    foreach (var nodeItem in NodesList[key].AdjoiningNodes)
                    {
                        if (Mark[nodeItem.Key] == 0)
                        {
                            Component ( nodeItem.Key );
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Пустой граф, в нем не может быть компонент связности");
                return;
            }

            var resString = new StringBuilder(40);

            int lastValue = Mark.Values[Mark.Count - 1];
            int firstValue = 1;
            int currValue = firstValue;


            resString.Append(currValue + ": ");
            for (var i = 0; i < Mark.Count; i++)
            {
                if (Mark[Mark.Keys[i]] == currValue)
                {
                    resString.Append(Mark.Keys[i] + " ");
                }
                else
                {
                    resString.AppendLine();
                    currValue++;
                    resString.Append(currValue + ": ");
                    i--;
                }
            }

            

            MessageBox.Show(resString.ToString());
            StreamWriter sw = new StreamWriter(File.Open("results.txt", FileMode.Create), Encoding.Unicode);
            sw.Write(resString.ToString());
            sw.Flush();
            sw.Close();


            
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(pictureBox1,
                @"help\programHelp.chm");
        }
    }
}