using Emgu.CV;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NNTSearchChar
{
    public partial class MainForm : Form
    {
        HaarCascade haar = new HaarCascade(Config.HaarCascadePath);
        FaceRecognition fr = new FaceRecognition();
        Point CurrentPoint;
        Graphics g;
        Timer t = new Timer();
        Timer t2 = new Timer();
        Capture cap = new Capture(Config.ActiveCameraIndex);
        Bitmap bmap, stBm;
        bool timerStart = false;
        static int count = 0x0;

        public MainForm()
        {
            InitializeComponent();
            picture1.MouseDown += picture1_MouseDown;
            picture1.Paint += picture1_Paint;

            textFaceId.SetWatermark("Write user name...");
            bmap = new Bitmap(picture1.Width, picture1.Height);
            g = picture1.CreateGraphics();

            picture2.Image = ImageResize.ResizeOrigImg(
             new Bitmap(Image.FromFile($"{Application.StartupPath}\\" +
             $"photo\\photo.jpg")), 400, 300);
            stBm = new Bitmap(picture2.Image);

            picture2.Width = cap.Width;
            picture2.Height = cap.Height;
            Width = cap.Width + 30;
            Height = cap.Height + 135;

            t.Interval = 110;
            t.Tick += (s, ea) => {
                picture2.Image = fr.FaceDetect(haar,
                    cap.QueryFrame(), stBm);
            };
            t.Start();
        }

        private void button_Click(object sender, EventArgs e)
        {
            count = 0;

            t2.Interval = Config.TimerResponseValue;
            t2.Tick += (s, ea) => {
                if (count == 15)
                {
                    t2.Stop();
                    timerStart = false;
                    progressBar.Value = progressBar.Maximum;
                    MessageBox.Show($"User {textFaceId.Text} save in datebase!", "Done!", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    progressBar.Value = progressBar.Minimum;
                    textFaceId.Text = string.Empty;
                }
                else
                {
                    fr.FaceDataset(haar,
                        cap.QueryFrame(), textFaceId.Text, count + 1, stBm);
                    count++;
                    progressBar.Value += 1;
                }
            };
            if (!timerStart)
                t2.Start();
        }

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"This button in stage development! \nWith love <3 \n©Sash", "Sorry",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}