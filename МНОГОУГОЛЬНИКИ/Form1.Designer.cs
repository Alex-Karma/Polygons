namespace МНОГОУГОЛЬНИКИ
{
    partial class form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.фигураToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кругToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.квадратToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.треугольникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цветToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фигурыToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.оболочкиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.фонаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.размерToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фигурыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оболочкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DynamicsGo = new System.Windows.Forms.ToolStripMenuItem();
            this.DynamicsStop = new System.Windows.Forms.ToolStripMenuItem();
            this.файлыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialogF = new System.Windows.Forms.ColorDialog();
            this.colorDialogH = new System.Windows.Forms.ColorDialog();
            this.colorDialogBG = new System.Windows.Forms.ColorDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.AutoSize = false;
            this.menuStrip.BackColor = System.Drawing.Color.Silver;
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фигураToolStripMenuItem,
            this.цветToolStripMenuItem,
            this.размерToolStripMenuItem,
            this.DynamicsGo,
            this.DynamicsStop,
            this.файлыToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(661, 35);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // фигураToolStripMenuItem
            // 
            this.фигураToolStripMenuItem.CheckOnClick = true;
            this.фигураToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.кругToolStripMenuItem,
            this.квадратToolStripMenuItem,
            this.треугольникToolStripMenuItem});
            this.фигураToolStripMenuItem.Name = "фигураToolStripMenuItem";
            this.фигураToolStripMenuItem.Size = new System.Drawing.Size(87, 31);
            this.фигураToolStripMenuItem.Text = "Фигура";
            // 
            // кругToolStripMenuItem
            // 
            this.кругToolStripMenuItem.Name = "кругToolStripMenuItem";
            this.кругToolStripMenuItem.Size = new System.Drawing.Size(217, 34);
            this.кругToolStripMenuItem.Text = "Круг";
            this.кругToolStripMenuItem.Click += new System.EventHandler(this.КругToolStripMenuItem_Click);
            // 
            // квадратToolStripMenuItem
            // 
            this.квадратToolStripMenuItem.Name = "квадратToolStripMenuItem";
            this.квадратToolStripMenuItem.Size = new System.Drawing.Size(217, 34);
            this.квадратToolStripMenuItem.Text = "Квадрат";
            this.квадратToolStripMenuItem.Click += new System.EventHandler(this.КвадратToolStripMenuItem_Click);
            // 
            // треугольникToolStripMenuItem
            // 
            this.треугольникToolStripMenuItem.Name = "треугольникToolStripMenuItem";
            this.треугольникToolStripMenuItem.Size = new System.Drawing.Size(217, 34);
            this.треугольникToolStripMenuItem.Text = "Треугольник";
            this.треугольникToolStripMenuItem.Click += new System.EventHandler(this.ТреугольникToolStripMenuItem_Click);
            // 
            // цветToolStripMenuItem
            // 
            this.цветToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фигурыToolStripMenuItem1,
            this.оболочкиToolStripMenuItem1,
            this.фонаToolStripMenuItem});
            this.цветToolStripMenuItem.Name = "цветToolStripMenuItem";
            this.цветToolStripMenuItem.Size = new System.Drawing.Size(67, 31);
            this.цветToolStripMenuItem.Text = "Цвет";
            // 
            // фигурыToolStripMenuItem1
            // 
            this.фигурыToolStripMenuItem1.Name = "фигурыToolStripMenuItem1";
            this.фигурыToolStripMenuItem1.Size = new System.Drawing.Size(198, 34);
            this.фигурыToolStripMenuItem1.Text = "Фигуры";
            this.фигурыToolStripMenuItem1.Click += new System.EventHandler(this.фигурыToolStripMenuItem1_Click);
            // 
            // оболочкиToolStripMenuItem1
            // 
            this.оболочкиToolStripMenuItem1.Name = "оболочкиToolStripMenuItem1";
            this.оболочкиToolStripMenuItem1.Size = new System.Drawing.Size(198, 34);
            this.оболочкиToolStripMenuItem1.Text = "Оболочки";
            this.оболочкиToolStripMenuItem1.Click += new System.EventHandler(this.оболочкиToolStripMenuItem1_Click);
            // 
            // фонаToolStripMenuItem
            // 
            this.фонаToolStripMenuItem.Name = "фонаToolStripMenuItem";
            this.фонаToolStripMenuItem.Size = new System.Drawing.Size(198, 34);
            this.фонаToolStripMenuItem.Text = "Фона";
            this.фонаToolStripMenuItem.Click += new System.EventHandler(this.фонаToolStripMenuItem_Click);
            // 
            // размерToolStripMenuItem
            // 
            this.размерToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фигурыToolStripMenuItem,
            this.оболочкиToolStripMenuItem});
            this.размерToolStripMenuItem.Name = "размерToolStripMenuItem";
            this.размерToolStripMenuItem.Size = new System.Drawing.Size(88, 31);
            this.размерToolStripMenuItem.Text = "Размер";
            // 
            // фигурыToolStripMenuItem
            // 
            this.фигурыToolStripMenuItem.Name = "фигурыToolStripMenuItem";
            this.фигурыToolStripMenuItem.Size = new System.Drawing.Size(198, 34);
            this.фигурыToolStripMenuItem.Text = "Фигуры";
            this.фигурыToolStripMenuItem.Click += new System.EventHandler(this.ФигурыToolStripMenuItem_Click);
            // 
            // оболочкиToolStripMenuItem
            // 
            this.оболочкиToolStripMenuItem.Name = "оболочкиToolStripMenuItem";
            this.оболочкиToolStripMenuItem.Size = new System.Drawing.Size(198, 34);
            this.оболочкиToolStripMenuItem.Text = "Оболочки";
            this.оболочкиToolStripMenuItem.Click += new System.EventHandler(this.ОболочкиToolStripMenuItem_Click);
            // 
            // DynamicsGo
            // 
            this.DynamicsGo.AutoSize = false;
            this.DynamicsGo.BackColor = System.Drawing.Color.Silver;
            this.DynamicsGo.BackgroundImage = global::МНОГОУГОЛЬНИКИ.Properties.Resources.Зелёная_Стрелка;
            this.DynamicsGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DynamicsGo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.DynamicsGo.Name = "DynamicsGo";
            this.DynamicsGo.Size = new System.Drawing.Size(33, 29);
            this.DynamicsGo.Text = " ";
            this.DynamicsGo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.DynamicsGo.Click += new System.EventHandler(this.DynamicsGotoolStripMenuItem1_Click);
            // 
            // DynamicsStop
            // 
            this.DynamicsStop.AutoSize = false;
            this.DynamicsStop.BackgroundImage = global::МНОГОУГОЛЬНИКИ.Properties.Resources.Красный_квадрат;
            this.DynamicsStop.Name = "DynamicsStop";
            this.DynamicsStop.Size = new System.Drawing.Size(33, 29);
            this.DynamicsStop.Click += new System.EventHandler(this.DynamicsStopToolStripMenuItem_Click);
            // 
            // файлыToolStripMenuItem
            // 
            this.файлыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.открытьToolStripMenuItem});
            this.файлыToolStripMenuItem.Name = "файлыToolStripMenuItem";
            this.файлыToolStripMenuItem.Size = new System.Drawing.Size(82, 31);
            this.файлыToolStripMenuItem.Text = "Файлы";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // colorDialogF
            // 
            this.colorDialogF.AnyColor = true;
            this.colorDialogF.Color = System.Drawing.Color.Red;
            // 
            // colorDialogH
            // 
            this.colorDialogH.AnyColor = true;
            // 
            // colorDialogBG
            // 
            this.colorDialogBG.AnyColor = true;
            this.colorDialogBG.Color = System.Drawing.Color.White;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "Пример №";
            this.saveFileDialog.Filter = "Binary Files (*.bin)|*.bin";
            this.saveFileDialog.InitialDirectory = "C:\\Users\\karma\\OneDrive\\Рабочий стол\\МНОГОУГОЛЬНИКИ 0.1";
            this.saveFileDialog.Title = "Save File";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Binary Files (*.bin)|*.bin";
            this.openFileDialog.InitialDirectory = "C:\\Users\\karma\\OneDrive\\Рабочий стол\\МНОГОУГОЛЬНИКИ 0.1";
            // 
            // form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(661, 620);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "МНОГОУГОЛЬНИКИ";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.form_MouseUp);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem фигураToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кругToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem квадратToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem треугольникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem цветToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem размерToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фигурыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оболочкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фигурыToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem оболочкиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem фонаToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialogF;
        private System.Windows.Forms.ColorDialog colorDialogH;
        private System.Windows.Forms.ColorDialog colorDialogBG;
        private System.Windows.Forms.ToolStripMenuItem DynamicsGo;
        private System.Windows.Forms.ToolStripMenuItem DynamicsStop;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem файлыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
    }
}

