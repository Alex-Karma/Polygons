using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace МНОГОУГОЛЬНИКИ
{
    public partial class trackH : Form
    {
        static Redraw re; // создание объекта делегата Redraw
        static public Redraw RE { get { return re; } set { re = value; } } // свойство объекта делегата Redraw
        public trackH()
        {
            InitializeComponent();
            label3.Text = "ЗНАЧЕНИЕ : " + Convert.ToString(form.WIDTH);
            trackBar.Value = form.WIDTH;
        }
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            label3.Text = "ЗНАЧЕНИЕ : " + Convert.ToString(trackBar.Value);
            form.WIDTH = trackBar.Value; // изменяю размер оболочки
            re(); // использую объект делегата для перересовки 
        }
        private void trackH_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
