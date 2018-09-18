using System;
using System.Drawing;
using System.Windows.Forms;

namespace NNTSearchChar
{
    partial class MainForm
    {
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

        private void ImageProperty()
        {
            double hue, sat, val;
            Bitmap bm = new Bitmap(picture2.Image);

            for (var i = 0; i < picture2.Height; i++)
            {
                bool err = false;
                for (var j = 0; j < picture2.Width; j++)
                {
                    try
                    {
                        ImageProcessing.ColToHSV(bm.GetPixel(i, j), out hue, out sat, out val);
                        bm.SetPixel(i, j, ImageProcessing.ColFromHSV(hue, sat, val));
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show($"Сообщение об ошибке: \n{ex}\n\n" +
                            $"Один из аргументов имеет значение выходящее из-за диапазона [0-255].", "Error!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        err = true; break;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Неизвестная ошибка !\n\nСообщение об ошибке: \n{ex}", "Error!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        err = true; break;
                    }
                }
                if (err) break;
            }
        }
    }
}
