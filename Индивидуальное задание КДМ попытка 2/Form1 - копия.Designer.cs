namespace Индивидуальное_задание_КДМ_попытка_2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose ( );
            }
            base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Node = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newFileButton = new System.Windows.Forms.ToolStripButton();
            this.openButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.saveAsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.newNodeButton = new System.Windows.Forms.ToolStripButton();
            this.ConnectNodesButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.moveButton = new System.Windows.Forms.ToolStripButton();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SearchDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.InfoButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.матрицаСмежностиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pbDrawing = new System.Windows.Forms.PictureBox();
            this.tbAct = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.чтотоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.импортToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заданиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.найтиКомпонентыСвязностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.матрицаСмежностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMenu.SuspendLayout();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawing)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.button2);
            this.panelMenu.Controls.Add(this.button1);
            this.panelMenu.Controls.Add(this.Node);
            this.panelMenu.Controls.Add(this.button3);
            this.panelMenu.Location = new System.Drawing.Point(3, 27);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(108, 394);
            this.panelMenu.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(19, 300);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 35);
            this.button2.TabIndex = 6;
            this.button2.Text = "Del";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 259);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "Move";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Node
            // 
            this.Node.AutoEllipsis = true;
            this.Node.Location = new System.Drawing.Point(21, 135);
            this.Node.Name = "Node";
            this.Node.Size = new System.Drawing.Size(75, 35);
            this.Node.TabIndex = 4;
            this.Node.Text = "Connect";
            this.Node.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.AutoEllipsis = true;
            this.button3.Location = new System.Drawing.Point(21, 176);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 35);
            this.button3.TabIndex = 3;
            this.button3.Text = "Node";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panel
            // 
            this.panel.AccessibleDescription = "panelDrawing";
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.Controls.Add(this.button4);
            this.panel.Controls.Add(this.pictureBox1);
            this.panel.Controls.Add(this.toolStrip1);
            this.panel.Controls.Add(this.pbDrawing);
            this.panel.Location = new System.Drawing.Point(117, 27);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(744, 394);
            this.panel.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(161, 71);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(170, 120);
            this.button4.TabIndex = 4;
            this.button4.Text = "Выделение цветом - есть, надо было заменить return на break. Теперь надо сделать " +
    "адеватное выделение SelectedNode  при Move, а то как будто обманка получается.";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(711, 391);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileButton,
            this.openButton,
            this.saveButton,
            this.saveAsButton,
            this.toolStripSeparator5,
            this.toolStripSeparator,
            this.newNodeButton,
            this.ConnectNodesButton,
            this.toolStripSeparator6,
            this.toolStripSeparator2,
            this.moveButton,
            this.deleteButton,
            this.toolStripSeparator4,
            this.toolStripSeparator3,
            this.SearchDropDownButton,
            this.toolStripSeparator1,
            this.InfoButton});
            this.toolStrip1.Location = new System.Drawing.Point(714, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(30, 394);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newFileButton
            // 
            this.newFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newFileButton.Image = global::Индивидуальное_задание_КДМ_попытка_2.Properties.Resources.NewFile;
            this.newFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newFileButton.Name = "newFileButton";
            this.newFileButton.Size = new System.Drawing.Size(27, 20);
            this.newFileButton.Text = "toolStripButton2";
            this.newFileButton.ToolTipText = "Новый граф";
            this.newFileButton.Click += new System.EventHandler(this.newFileButton_Click);
            // 
            // openButton
            // 
            this.openButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openButton.Image = global::Индивидуальное_задание_КДМ_попытка_2.Properties.Resources.OpenFile;
            this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(27, 20);
            this.openButton.Text = "Открыть граф";
            // 
            // saveButton
            // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Enabled = false;
            this.saveButton.Image = global::Индивидуальное_задание_КДМ_попытка_2.Properties.Resources.FileSave;
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(27, 20);
            this.saveButton.Text = "Сохранить";
            // 
            // saveAsButton
            // 
            this.saveAsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveAsButton.Enabled = false;
            this.saveAsButton.Image = ((System.Drawing.Image)(resources.GetObject("saveAsButton.Image")));
            this.saveAsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(27, 20);
            this.saveAsButton.Text = "Сохранить как...";
            this.saveAsButton.ToolTipText = "Сохранить под другим именем";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(27, 6);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(27, 6);
            // 
            // newNodeButton
            // 
            this.newNodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newNodeButton.Enabled = false;
            this.newNodeButton.Image = global::Индивидуальное_задание_КДМ_попытка_2.Properties.Resources.Node;
            this.newNodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newNodeButton.Name = "newNodeButton";
            this.newNodeButton.Size = new System.Drawing.Size(27, 20);
            this.newNodeButton.Text = "Вершина";
            this.newNodeButton.Click += new System.EventHandler(this.NewNode_Click);
            // 
            // ConnectNodesButton
            // 
            this.ConnectNodesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ConnectNodesButton.Enabled = false;
            this.ConnectNodesButton.Image = global::Индивидуальное_задание_КДМ_попытка_2.Properties.Resources.ConnectTwoNodes;
            this.ConnectNodesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ConnectNodesButton.Name = "ConnectNodesButton";
            this.ConnectNodesButton.Size = new System.Drawing.Size(27, 20);
            this.ConnectNodesButton.Text = "Стрелка";
            this.ConnectNodesButton.Click += new System.EventHandler(this.ConnectNodesButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(27, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(27, 6);
            // 
            // moveButton
            // 
            this.moveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveButton.Enabled = false;
            this.moveButton.Image = global::Индивидуальное_задание_КДМ_попытка_2.Properties.Resources.HandPointerMove;
            this.moveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(27, 20);
            this.moveButton.Text = "Передвинуть";
            this.moveButton.Click += new System.EventHandler(this.ButtonMove_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteButton.Enabled = false;
            this.deleteButton.Image = global::Индивидуальное_задание_КДМ_попытка_2.Properties.Resources.DelImage1;
            this.deleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(27, 20);
            this.deleteButton.Text = "Удалить";
            this.deleteButton.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(27, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(27, 6);
            // 
            // SearchDropDownButton
            // 
            this.SearchDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SearchDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.SearchDropDownButton.Enabled = false;
            this.SearchDropDownButton.Image = global::Индивидуальное_задание_КДМ_попытка_2.Properties.Resources.searchImage3;
            this.SearchDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SearchDropDownButton.Name = "SearchDropDownButton";
            this.SearchDropDownButton.Size = new System.Drawing.Size(27, 20);
            this.SearchDropDownButton.Text = "Поиск";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(203, 22);
            this.toolStripMenuItem1.Text = "Компоненты связности";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(27, 6);
            // 
            // InfoButton
            // 
            this.InfoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.InfoButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.матрицаСмежностиToolStripMenuItem1});
            this.InfoButton.Enabled = false;
            this.InfoButton.Image = global::Индивидуальное_задание_КДМ_попытка_2.Properties.Resources.info2;
            this.InfoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(27, 20);
            this.InfoButton.Text = "Информация";
            // 
            // матрицаСмежностиToolStripMenuItem1
            // 
            this.матрицаСмежностиToolStripMenuItem1.Name = "матрицаСмежностиToolStripMenuItem1";
            this.матрицаСмежностиToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
            this.матрицаСмежностиToolStripMenuItem1.Text = "Матрица смежности";
            // 
            // pbDrawing
            // 
            this.pbDrawing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pbDrawing.Enabled = false;
            this.pbDrawing.Location = new System.Drawing.Point(3, 0);
            this.pbDrawing.Name = "pbDrawing";
            this.pbDrawing.Size = new System.Drawing.Size(708, 391);
            this.pbDrawing.TabIndex = 1;
            this.pbDrawing.TabStop = false;
            this.pbDrawing.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbDrawing_MouseClick);
            this.pbDrawing.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbDrawing_MouseDoubleClick);
            this.pbDrawing.MouseLeave += new System.EventHandler(this.pbDrawing_MouseLeave);
            this.pbDrawing.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbDrawing_MouseMove);
            // 
            // tbAct
            // 
            this.tbAct.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbAct.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbAct.ForeColor = System.Drawing.Color.Maroon;
            this.tbAct.Name = "tbAct";
            this.tbAct.Size = new System.Drawing.Size(220, 23);
            this.tbAct.ToolTipText = "Что делать";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.чтотоToolStripMenuItem,
            this.заданиеToolStripMenuItem,
            this.таблицыToolStripMenuItem,
            this.tbAct});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(861, 27);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // чтотоToolStripMenuItem
            // 
            this.чтотоToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйToolStripMenuItem,
            this.импортToolStripMenuItem1,
            this.экспортToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem});
            this.чтотоToolStripMenuItem.Image = global::Индивидуальное_задание_КДМ_попытка_2.Properties.Resources.this_file;
            this.чтотоToolStripMenuItem.Name = "чтотоToolStripMenuItem";
            this.чтотоToolStripMenuItem.Size = new System.Drawing.Size(64, 23);
            this.чтотоToolStripMenuItem.Text = "Файл";
            // 
            // новыйToolStripMenuItem
            // 
            this.новыйToolStripMenuItem.Image = global::Индивидуальное_задание_КДМ_попытка_2.Properties.Resources.NewFile;
            this.новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
            this.новыйToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.новыйToolStripMenuItem.Text = "Новый";
            this.новыйToolStripMenuItem.ToolTipText = "Новый граф";
            // 
            // импортToolStripMenuItem1
            // 
            this.импортToolStripMenuItem1.Image = global::Индивидуальное_задание_КДМ_попытка_2.Properties.Resources.OpenFile;
            this.импортToolStripMenuItem1.Name = "импортToolStripMenuItem1";
            this.импортToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.импортToolStripMenuItem1.Text = "Открыть";
            this.импортToolStripMenuItem1.ToolTipText = "Открыть граф";
            // 
            // экспортToolStripMenuItem
            // 
            this.экспортToolStripMenuItem.Image = global::Индивидуальное_задание_КДМ_попытка_2.Properties.Resources.FileSave;
            this.экспортToolStripMenuItem.Name = "экспортToolStripMenuItem";
            this.экспортToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.экспортToolStripMenuItem.Text = "Сохранить";
            this.экспортToolStripMenuItem.ToolTipText = "Сохранить граф";
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Image = global::Индивидуальное_задание_КДМ_попытка_2.Properties.Resources.FileSaveAs;
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как...";
            this.сохранитьКакToolStripMenuItem.ToolTipText = "Сохранить под другим именем";
            // 
            // заданиеToolStripMenuItem
            // 
            this.заданиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.найтиКомпонентыСвязностиToolStripMenuItem});
            this.заданиеToolStripMenuItem.Image = global::Индивидуальное_задание_КДМ_попытка_2.Properties.Resources.searchImage3;
            this.заданиеToolStripMenuItem.Name = "заданиеToolStripMenuItem";
            this.заданиеToolStripMenuItem.Size = new System.Drawing.Size(70, 23);
            this.заданиеToolStripMenuItem.Text = "Поиск";
            // 
            // найтиКомпонентыСвязностиToolStripMenuItem
            // 
            this.найтиКомпонентыСвязностиToolStripMenuItem.Name = "найтиКомпонентыСвязностиToolStripMenuItem";
            this.найтиКомпонентыСвязностиToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.найтиКомпонентыСвязностиToolStripMenuItem.Text = "Компоненты связности";
            // 
            // таблицыToolStripMenuItem
            // 
            this.таблицыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.матрицаСмежностиToolStripMenuItem});
            this.таблицыToolStripMenuItem.Image = global::Индивидуальное_задание_КДМ_попытка_2.Properties.Resources.info1;
            this.таблицыToolStripMenuItem.Name = "таблицыToolStripMenuItem";
            this.таблицыToolStripMenuItem.Size = new System.Drawing.Size(109, 23);
            this.таблицыToolStripMenuItem.Text = "Информация";
            // 
            // матрицаСмежностиToolStripMenuItem
            // 
            this.матрицаСмежностиToolStripMenuItem.Name = "матрицаСмежностиToolStripMenuItem";
            this.матрицаСмежностиToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.матрицаСмежностиToolStripMenuItem.Text = "Матрица смежности";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 437);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelMenu.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawing)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Node;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newFileButton;
        private System.Windows.Forms.ToolStripButton openButton;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStripButton saveAsButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton newNodeButton;
        private System.Windows.Forms.ToolStripButton ConnectNodesButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton moveButton;
        private System.Windows.Forms.ToolStripButton deleteButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton SearchDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton InfoButton;
        private System.Windows.Forms.ToolStripMenuItem матрицаСмежностиToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pbDrawing;
        private System.Windows.Forms.ToolStripTextBox tbAct;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem чтотоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem импортToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem экспортToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заданиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem найтиКомпонентыСвязностиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem матрицаСмежностиToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button4;
    }
}

