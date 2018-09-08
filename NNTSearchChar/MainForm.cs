using Emgu.CV;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NNTSearchChar
{
    public partial class MainForm : Form
    {
        HaarCascade haar = new HaarCascade(@"haarcascades\haarcascade_frontalface_default.xml");
        MashineVision MV = new MashineVision();
        Point CurrentPoint;
        Graphics g;
        Timer t = new Timer();
        Timer t2 = new Timer();
        Capture cap = new Capture(0);
        Bitmap bmap, stBm;

        public MainForm()
        {
            InitializeComponent();
            textFaceId.SetWatermark("Write ID...");
            bmap = new Bitmap(picture1.Width, picture1.Height);
            picture1.MouseDown += picture1_MouseDown;
            picture1.Paint += picture1_Paint;
            g = picture1.CreateGraphics();

            picture2.Image = ImageResize.ResizeOrigImg(
             new Bitmap(Image.FromFile(@"photo\photo.jpg")), 400, 300);
            stBm = new Bitmap(picture2.Image);

            picture2.Width = cap.Width;
            picture2.Height = cap.Height;
            Width = cap.Width + 30;
            Height = cap.Height + 135;

            t.Interval = 110;
            t.Tick += (s, e) => {
                picture2.Image = MV.FaceDetect(haar,
                    cap.QueryFrame());
            };
            t.Start();
        }

        private void button_Click(object sender, EventArgs e)
        {
            int count = 1;

            t2.Interval = 400;
            t2.Tick += (s, ea) => {
                if (count == 15)
                {
                    t2.Stop();
                    MessageBox.Show("Done!");
                }
                MV.FaceDetectSave(haar, 
                    cap.QueryFrame(), textFaceId.Text, count);
                count++;
            };
            t2.Start();
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
                        MashineVision.ColToHSV(bm.GetPixel(i, j), out hue, out sat, out val);
                        bm.SetPixel(i, j, MashineVision.ColFromHSV(hue, sat, val));
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