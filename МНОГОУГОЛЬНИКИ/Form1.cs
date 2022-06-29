using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO; // библиотека для работы с файлами
using System.Runtime.Serialization.Formatters.Binary; // бибилоитека для записи бинарных файлов (данных)
using System.Windows.Forms;


namespace МНОГОУГОЛЬНИКИ
{
    public delegate void Redraw(); // делегат пространства имён МНОГОУГОЛЬНИКИ
    public partial class form : Form
    {
        #region -- ПОЛЯ --
        List<FIGURE> F; // список для объектов фигур
        bool isreplace = false; //  флажок для проверки попадания в область  для перемещения
        List<float> DX; // изменения положений точек фигур при перемещении   по Х
        List<float> DY; // по Y
        List<int> Dnd; // список объектов, которые надо перетаскивать
        bool ismovehull = false;
        Color Fcolor; // цвет фигур
        Color BGcolor; // цвет фона
        BinaryFormatter formatter; // создание объекта класса, нужного для сериализации и десериализвции данных
        List<Object> Info; // список, который будет сохроняться в файл
        Form scrolBarF; // форма, которая измняет радиус фигур
        Form trackBarH; // форма, которая измняет размер оболочки
        #endregion
        #region -- ПОЛЯ Оболочки --
        Color Hcolor; // цвет оболочки
        static int width; // толщина оболочки
        static public int WIDTH { get { return width; } set { width = value; } } // свойство для поля width
        int n1, n2; // счетчики количества точек, лежащих по одну сторону от прямой
        PointF point; // точка при нажатии внутрь оболочки и её дальнейшее изменение в методе при передвижении оболочки
        #endregion
        public form()
        {
            InitializeComponent();
            F = new List<FIGURE>();
            DX = new List<float>();
            DY = new List<float>();
            Dnd = new List<int>();
            Hcolor = Color.Black;
            Fcolor = Color.Red;
            BGcolor = Color.White;
            width = 10;
            n1 = n2 = 0;
            кругToolStripMenuItem.Checked = true;
            formatter = new BinaryFormatter();
            Info = new List<Object>();
            scrolBarF = new scrolF();
            trackBarH = new trackH();
            //saveFileDialog.InitialDirectory = @"E:\МНОГОУГОЛЬНИКИ 0.1"; // место сохранения файла
            //openFileDialog.InitialDirectory = @"E:\МНОГОУГОЛЬНИКИ 0.1"; // место открытия файла
            trackH.RE = redraw; // присвоение делегатам форм, изменяющим размеры...
            scrolF.RE = redraw; // ...функции производящей перересовку главной формы
        }
        public void redraw() // функция, которую я присваиваю делегату - она производит перересовку главной формы
        {
            Refresh();
        }
        void Form_Paint(object sender, PaintEventArgs e) // рисование
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality; // лучшая прорисовка
            drawhull(e); // прорисовка оболочки
            foreach (FIGURE i in F) // прорисовка фигур
                i.draw(e, Fcolor, i.X, i.Y, FIGURE.R);
        }
        #region --Нажатие на окошки меню--
        #region --Выбор фигуры--
        private void КругToolStripMenuItem_Click(object sender, EventArgs e) // определение выбор фигуры
        {
            foreach (ToolStripMenuItem i in фигураToolStripMenuItem.DropDownItems)
                i.Checked = false;
            кругToolStripMenuItem.Checked = true;
        }
        private void КвадратToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem i in фигураToolStripMenuItem.DropDownItems)
                i.Checked = false;
            квадратToolStripMenuItem.Checked = true;
        }
        private void ТреугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem i in фигураToolStripMenuItem.DropDownItems)
                i.Checked = false;
            треугольникToolStripMenuItem.Checked = true;
        }
        #endregion
        #region --Размеры--
        private void ФигурыToolStripMenuItem_Click(object sender, EventArgs e) // вызов окошка для изменение размера фигуры
        {
            if (scrolBarF.WindowState == FormWindowState.Minimized) // проверка на свёрнутость формы - если она свёрнута, то развернуть
            {
                scrolBarF.WindowState = FormWindowState.Normal; // разварачивает
                scrolBarF.Focus(); // устанавливает фокус на эту форму - нужно тогда, когда главная форма полностью развёрнута, и без этого эта форма просто открылась бы но была под главной
            }
            scrolBarF.Show();
        }
        private void ОболочкиToolStripMenuItem_Click(object sender, EventArgs e) // вызов окошка для изменение размера оболочки
        {
            if (trackBarH.WindowState == FormWindowState.Minimized) // проверка на свёрнутость формы - если она свёрнута, то развернуть
            {
                trackBarH.WindowState = FormWindowState.Normal; // разварачивает
                trackBarH.Focus(); // устанавливает фокус на эту форму - нужно тогда, когда главная форма полностью развёрнута, и без этого эта форма просто открылась бы но была под главной
            }
            trackBarH.Show();
        }
        #endregion
        #region --Цвета--
        private void фигурыToolStripMenuItem1_Click(object sender, EventArgs e) // вызов окошка для изменение цвета фигуры
        {
            colorDialogF.ShowDialog();
            Fcolor = colorDialogF.Color;
        }
        private void оболочкиToolStripMenuItem1_Click(object sender, EventArgs e) // вызов окошка для изменение цвета оболочки
        {
            colorDialogH.ShowDialog();
            Hcolor = colorDialogH.Color;
        }
        private void фонаToolStripMenuItem_Click(object sender, EventArgs e) // вызов окошка для изменение цвета фона
        {
            colorDialogBG.ShowDialog();
            this.BackColor = BGcolor = colorDialogBG.Color;
        }
        #endregion
        #region --Динамика--
        private void DynamicsGotoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (F.Count >= 1)
            {
                //DynamicsGo.BackgroundImage = Красный_квадрат.png;
                timer.Start();
            }
        }
        private void DynamicsStopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (F.Count >= 1)
                timer.Stop();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            foreach (FIGURE i in F)
            {
                i.X += rnd.Next(-5, 6);
                i.Y += rnd.Next(-5, 6);
            }
            F = Del();
            Refresh();
        }
        #endregion
        #region --Save/Load--
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
            using (Stream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
            {
                Info.Add(Fcolor); // добавление
                Info.Add(Hcolor); //
                Info.Add(BGcolor); // цветов
                Info.Add(width); // добавление размера оболочки
                Info.Add(F); // добавление списка фигур
                Info.Add(FIGURE.R); // добавление радиуса фигуры
                // добавление открытых окошек
                // добавление галочек в меню с выбором фигуры
                // добавление значение включённой динамики
                formatter.Serialize(stream, Info);
            }
        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();

            try // при нажатиии на кнопку отмена возникает ошибка, из-за того, что "Пустое имя пути не допускается" - потоку присваивается ничего
            {
                using (Stream stream = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    Info = (List<Object>)formatter.Deserialize(stream);
                    Fcolor = (Color)Info[0];
                    Hcolor = (Color)Info[1];
                    this.BackColor = BGcolor = (Color)Info[2];
                    width = (int)Info[3];
                    F = (List<FIGURE>)Info[4];
                    FIGURE.R = (int)Info[5];
                    Invalidate();
                }
            }
            catch { }
        }
        #endregion
        #endregion
        #region --События мышки--
        void form_MouseDown(object sender, MouseEventArgs e) // процессы при нажатии мыщи
        {
            if (e.Button == MouseButtons.Left) // добавление нового объекта и сохранение изменения координат объекта для передвижения
            {
                if (F.Count == 0) // добавлене объекта, когда не существует ни одного объекта
                {
                    if (кругToolStripMenuItem.Checked)
                        F.Add(new Circle());
                    else if (квадратToolStripMenuItem.Checked)
                        F.Add(new Square());
                    else if (треугольникToolStripMenuItem.Checked)
                        F.Add(new Triangle());
                    /*
                      Type type = typeof()
                     */
                    F[F.Count - 1].X = e.X;
                    F[F.Count - 1].Y = e.Y;
                }
                else
                {
                    for (int i = 0; i < F.Count; i++)
                    {
                        if (F[i].cheak(e)) // запоминание координат при нажатии для перемещения объекта
                        {
                            isreplace = true;
                            Dnd.Add(i);
                            DX.Add(F[i].X - e.X);
                            DY.Add(F[i].Y - e.Y);
                        }
                    }
                    if (ISmovehull(e) && !isreplace) // ставлю флажок на перетаскивание оболочки при попадании внутрь оболочки
                    {
                        ismovehull = true;
                    }
                    else if (!isreplace) // добавлене объекта
                    {
                        if (кругToolStripMenuItem.Checked)
                            F.Add(new Circle());
                        else if (квадратToolStripMenuItem.Checked)
                            F.Add(new Square());
                        else if (треугольникToolStripMenuItem.Checked)
                            F.Add(new Triangle());
                        F[F.Count - 1].X = e.X;
                        F[F.Count - 1].Y = e.Y;
                    }
                }
            }
            else if (e.Button == MouseButtons.Right && F.Count != 0)
            {
                for (int i = 0; i < F.Count;)
                {
                    if (F[i].cheak(e))
                        F.RemoveAt(i);
                    else
                        i++;
                }
            } // удаление объекта
        }
        void Form_MouseMove(object sender, MouseEventArgs e) // процессы при движении мыщи после нажатия
        {
            if (ismovehull)
                F = movehull(e);
            else if (isreplace)
            {
                int j = 0;
                try // ошибка возникает при удалении объекта во время его передвижения
                {
                    foreach (int i in Dnd)
                    {
                        F[i].X = e.X + DX[j];
                        F[i].Y = e.Y + DY[j];
                        j++;
                    }
                }
                catch { }
            }
            Refresh();
        }
        void form_MouseUp(object sender, MouseEventArgs e) // процессы после отжатия мыши
        {
            F = Del();
            ismovehull = false;
            isreplace = false;
            Dnd.Clear();
            DX.Clear();
            DY.Clear();
            Invalidate();
        }
        #endregion
        #region --Методы Оболочки--
        void drawhull(PaintEventArgs e) // метод рисует выпуклую оболочку
        {
            List<FIGURE> objs = new List<FIGURE>(); // список объектов образующих оболочку
            float Vector(FIGURE a, FIGURE b, FIGURE c) // функция, возвращающая вектор
            {
                return (c.Y - b.Y) * (a.X - b.X) - (c.X - b.X) * (a.Y - b.Y);
            }
            if (F.Count >= 3)
            {
                for (int i = 0; i < F.Count; i++)
                {
                    for (int j = i + 1; j < F.Count; j++)
                    {
                        n1 = n2 = 0;
                        for (int k = 0; k < F.Count; k++)
                        {
                            if (i != k && j != k)
                            {
                                if (Vector(F[i], F[j], F[k]) > 0)
                                    n1++;
                                else if (Vector(F[i], F[j], F[k]) < 0)
                                    n2++;
                            }
                        }
                        if (F.Count - 2 == n1 || F.Count - 2 == n2) // минус два, так как точки вектора тоже будут добавлены
                        {
                            bool yesa = false; // флажок на повторную всречу объекта
                            bool yesb = false; // another
                            foreach (FIGURE n in objs)
                            {
                                if (n == F[i])
                                    yesa = true;
                                if (n == F[j])
                                    yesb = true;
                            }
                            if (!yesa)
                            {
                                objs.Add(F[i]);
                                F[i].draw(e, Hcolor, F[i].X, F[i].Y, FIGURE.R + width);
                            }
                            if (!yesb)
                            {
                                objs.Add(F[j]);
                                F[j].draw(e, Hcolor, F[j].X, F[j].Y, FIGURE.R + width);
                            }
                            e.Graphics.DrawLine(new Pen(Hcolor, width), new PointF(F[i].X, F[i].Y), new PointF(F[j].X, F[j].Y));
                        }
                    }
                }
            }
        }
        List<FIGURE> Del() // возврат обновлённого списка с удалением объектов, попавших внутрь оболочки
        {
            List<FIGURE> objs = new List<FIGURE>(); // список объектов образующих оболочку
            float Vector(FIGURE a, FIGURE b, FIGURE c) // функция, возвращающая вектор
            {
                return (c.Y - b.Y) * (a.X - b.X) - (c.X - b.X) * (a.Y - b.Y);
            }
            if (F.Count >= 3)
            {
                for (int i = 0; i < F.Count; i++)
                {
                    for (int j = i + 1; j < F.Count; j++)
                    {
                        n1 = n2 = 0;
                        for (int k = 0; k < F.Count; k++)
                        {
                            if (i != k && j != k)
                            {
                                if (Vector(F[i], F[j], F[k]) > 0)
                                    n1++;
                                else if (Vector(F[i], F[j], F[k]) < 0)
                                    n2++;
                            }
                        }
                        if (F.Count - 2 == n1 || F.Count - 2 == n2) // минус два, так как точки вектора тоже будут добавлены
                        {
                            bool yesa = false; // флажок на повторную всречу объекта
                            bool yesb = false; // another
                            foreach (FIGURE n in objs)
                            {
                                if (n == F[i])
                                    yesa = true;
                                if (n == F[j])
                                    yesb = true;
                            }
                            if (!yesa)
                                objs.Add(F[i]);
                            if (!yesb)
                                objs.Add(F[j]);
                        }
                    }
                }
                for (int n = 0; n < F.Count;)
                {
                    if (!objs.Contains(F[n]))
                        F.Remove(F[n]);
                    else
                        n++;
                }
            }
            return F;
        }
        bool ISmovehull(MouseEventArgs e) // проверка на попадание нажатой мышки внутрь оболочки
        {

            // надо исправить проверку при попадании на линию соеденяющую фигуры, т.к. проверка по центрам фигур не коректна

            List<PointF> objs = new List<PointF>(); // список из начальных точек        // создаю список точек, т.к. не могу преобразовать
            List<PointF> endobjs = new List<PointF>(); // список точек оболочки         // нажатую точку (point = e) в объект класса FIGURE
            point = new PointF(e.X, e.Y); // инициализация точки при нажатии
            float Vector(PointF a, PointF b, PointF c) // функция, возвращающая вектор
            {
                return (c.Y - b.Y) * (a.X - b.X) - (c.X - b.X) * (a.Y - b.Y);
            }
            if (F.Count >= 3)
            {
                foreach (FIGURE i in F)
                    objs.Add(new PointF(i.X, i.Y));
                objs.Add(point);

                for (int i = 0; i < objs.Count; i++)
                {
                    for (int j = i + 1; j < objs.Count; j++)
                    {
                        n1 = n2 = 0;
                        for (int k = 0; k < objs.Count; k++)
                        {
                            if (i != k && j != k)
                            {
                                if (Vector(objs[i], objs[j], objs[k]) >= 0)
                                    n1++;
                                else if (Vector(objs[i], objs[j], objs[k]) <= 0)
                                    n2++;
                            }
                        }
                        if (objs.Count - 2 == n1 || objs.Count - 2 == n2)
                        {
                            bool yesa = false; // флажок на повторную всречу объекта
                            bool yesb = false; // another
                            foreach (PointF n in endobjs)
                            {
                                if (n == objs[i])
                                    yesa = true;
                                if (n == objs[j])
                                    yesb = true;
                            }
                            if (!yesa)
                                endobjs.Add(objs[i]);
                            if (!yesb)
                                endobjs.Add(objs[j]);
                        }
                    }
                }
                if (!(endobjs.Contains(point))) // если этот список не содержит точку нажатия, то она лежит внутри оболочки
                    return true;
            }
            return false;
        }
        List<FIGURE> movehull(MouseEventArgs e) // движение оболочки при захвате
        {
            List<FIGURE> newF = new List<FIGURE>();
            foreach (FIGURE i in F)
                newF.Add(i);
            for (int i = 0; i < newF.Count; i++)
            {
                newF[i].X = newF[i].X + e.X - point.X;
                newF[i].Y = newF[i].Y + e.Y - point.Y;
            }
            point.X = e.X;
            point.Y = e.Y;
            return newF;
        }
        #endregion
    }

    #region --Классы фигур--
    [Serializable]
    abstract class FIGURE
    {
        static int r = 40; // field of the radius    СДЕЛАТЬ СТАТИЧЕСКИМ
        float x, y; // field x & y
        static Color color; // поле, отвечающее за цвет фигуры      ТОЖЕ
        public float X { get { return x; } set { x = value; } }
        public float Y { get { return y; } set { y = value; } }
        static public int R { get { return r; } set { r = value; } }
        public Color COLOR { get { return color; } }
        public virtual void draw(PaintEventArgs e, Color Fcolor, float X, float Y, float R) // метод рисования
        {
            color = Fcolor;
        }
        public abstract bool cheak(MouseEventArgs e); // абстрактный метод проверки попадания в фигуру
    }

    [Serializable]
    class Circle : FIGURE
    {
        public override void draw(PaintEventArgs e, Color Fcolor, float X, float Y, float R) // рисования
        {
            base.draw(e, Fcolor, X, Y, R);
            e.Graphics.FillEllipse(new SolidBrush(COLOR), X - R, Y - R, 2 * R, 2 * R);
        }
        public override bool cheak(MouseEventArgs e) // проверка попадания мышки в круг
        {
            float l = (float)Math.Sqrt(Math.Pow(e.X - X, 2) + Math.Pow(e.Y - Y, 2)); // расстояние между центром окружности и нажатой точкой
            if (l <= R)
                return true;
            else
                return false;
        }
    }
    [Serializable]
    class Square : FIGURE
    {
        public override void draw(PaintEventArgs e, Color Fcolor, float X, float Y, float R) // рисования
        {
            base.draw(e, Fcolor, X, Y, R);
            e.Graphics.FillRectangle(new SolidBrush(COLOR), X - R, Y - R, 2 * R, 2 * R);
        }
        public override bool cheak(MouseEventArgs e) // проверка попадания мышки в квадрат
        {
            if (e.X >= X - R && e.X <= X + R && e.Y >= Y - R && e.Y <= Y + R)
                return true;
            else
                return false;
        }
    }
    [Serializable]
    class Triangle : FIGURE
    {
        private float ax, ay;
        private float bx, by;
        private float cx, cy;
        public override void draw(PaintEventArgs e, Color Fcolor, float X, float Y, float R) // рисования
        {
            base.draw(e, Fcolor, X, Y, R);
            // координаты нижней левой вершины треугольника
            ax = X - (R * (float)Math.Sqrt(3) / 2);
            ay = Y + (R / 2);
            // координаты нижней правой вершины треугольника
            bx = X + (R * (float)Math.Sqrt(3) / 2);
            by = Y + (R / 2);
            // координаты верхней вершины треугольника
            cx = X;
            cy = Y - R;
            PointF[] mus = { new PointF(ax, ay), new PointF(bx, by), new PointF(cx, cy) };
            e.Graphics.FillPolygon(new SolidBrush(COLOR), mus);
        }
        public override bool cheak(MouseEventArgs e) // проверка попадания мышки в треугольник
        {
            // координаты нижней левой вершины треугольника
            ax = X - (R * (float)Math.Sqrt(3) / 2);
            ay = Y + (R * (float)Math.Sqrt(3) / 4);
            // координаты нижней правой вершины треугольника
            bx = X + (R * (float)Math.Sqrt(3) / 2);
            by = Y + (R * (float)Math.Sqrt(3) / 4);
            // координаты верхней вершины треугольника
            cx = X;
            cy = Y - R;
            float Vektor1 = (e.Y - ay) * (bx - ax) - (e.X - ax) * (by - ay); // вектор нижней стороны
            float Vektor2 = (e.Y - by) * (cx - bx) - (e.X - bx) * (cy - by); // вектор левой стороны
            float Vektor3 = (e.Y - cy) * (ax - cx) - (e.X - cx) * (ay - cy); // вектор правой стороны

            if (Vektor1 <= 0 && Vektor2 <= 0 && Vektor3 <= 0) // проверка
                return true;
            else
                return false;
        }
    }
    #endregion
}