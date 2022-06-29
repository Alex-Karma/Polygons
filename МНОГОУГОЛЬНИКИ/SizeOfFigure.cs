using System;
using System.Windows.Forms;

namespace МНОГОУГОЛЬНИКИ
{
    public partial class scrolF : Form
    {
        static public Redraw RE { get; set; } // свойство объекта делегата Redraw
        public scrolF()
        {
            InitializeComponent();
            label3.Text = "ЗНАЧЕНИЕ : " + Convert.ToString(FIGURE.R);
            scrollBar.Value = FIGURE.R;
        }
        private void scrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            label3.Text = "ЗНАЧЕНИЕ : " + Convert.ToString(scrollBar.Value);
            FIGURE.R = scrollBar.Value; // изменяю радиус фигур
            RE(); // использую объект делегата для перересовки 
        }
        private void scrolF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
