using System;
using System.Drawing;
using System.Windows.Forms;

namespace NNTSearchChar
{
    public partial class Form1 : Form
    {
        Point CurrentPoint;
        Graphics g;
        Bitmap bmap;

        public Form1()
        {
            InitializeComponent();
            bmap = new Bitmap(picture1.Width, picture1.Height);
            picture1.MouseDown += picture1_MouseDown;
            picture1.Paint += picture1_Paint;
            g = picture1.CreateGraphics();
        }

        private void picture1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                using (Graphics g = Graphics.FromImage(bmap))
                {
                    g.FillEllipse(Brushes.Black, e.X, e.Y, 10, 10);
                }
                picture1.Invalidate();
            }
        }

        private void picture1_MouseDown(object sender, MouseEventArgs e)
        {
            CurrentPoint = e.Location;
        }

        private void picture1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmap, Point.Empty);
        }

        private void button_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < picture1.Height; i++)
            {
                for (var j = 0; j < picture1.Width; j++)
                {
                    bmap.SetPixel(i, j, Color.Black);
                }
            }
            picture2.Image = bmap;
        }
    }
}