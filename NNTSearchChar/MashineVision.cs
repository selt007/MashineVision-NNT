using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Windows.Forms;

namespace NNTSearchChar
{
    class MashineVision
    {
        public static void ColToHSV(Color col, out double h, out double s, out double v)
        {
            double 
                r = col.R * 255 / 100, 
                g = col.G * 255 / 100, 
                b = col.B * 255 / 100,
                min, max;

            max = Math.Max(r, Math.Max(g, b));
            min = Math.Min(r, Math.Min(g, b));

            v = (min + max) / 2;
            h = 0x0;

            if (min == max)
                h = 0;
            if (max == r && g >= b)
                h = 60 * ((g - b) / (max - min)) + 0;
            if (max == r && g < b)
                h = 60 * ((g - b) / (max - min)) + 360;
            if (max == g)
                h = 60 * ((b - r) / (max - min)) + 120;
            if (max == b)
                h = 60 * ((r - g) / (max - min)) + 240;

            s = (max == 0) ? 0 : 1d - (1d * min / max);
        }

        public static Color ColFromHSV(double hue, double saturation, double value)
        {
            double vmin, vinc, vdec, a;
            int hi;
            hi = Convert.ToInt32(hue / 60);
            vmin = (100 - saturation) * value / 100;
            a = (value - vmin) * ((hue) / 60);
            vinc = vmin + a;
            vdec = value - a;
            
            switch (hi)
            {
                case 0:
                    return Color.FromArgb(255, (int)value, (int)vinc, (int)vmin);
                case 1:
                    return Color.FromArgb(255, (int)vdec, (int)value, (int)vmin);
                case 2:
                    return Color.FromArgb(255, (int)vmin, (int)value, (int)vinc);
                case 3:
                    return Color.FromArgb(255, (int)vmin, (int)vdec, (int)value);
                case 4:
                    return Color.FromArgb(255, (int)vinc, (int)vmin, (int)value);
                case 5:
                    return Color.FromArgb(255, (int)value, (int)vinc, (int)vmin);
                default:
                    return Color.FromArgb(255, 255, 255, 255);
            }
        }

        public Image FaceDetect(HaarCascade haar, Image<Bgr, byte> img, Bitmap bmp = null)
        {
            var obj = img;
            if (bmp != null) obj = new Image<Bgr, byte>(bmp);

            using (Image<Bgr, byte> nextFrame = obj)
            {
                if (nextFrame != null)
                {
                    Image<Gray, byte> grayframe = nextFrame.Convert<Gray, byte>();
                    var faces =
                            grayframe.DetectHaarCascade(
                                    haar, 1.1, 3,
                                    HAAR_DETECTION_TYPE.DEFAULT,
                                    new Size(nextFrame.Width / 4, nextFrame.Height / 8)
                                    )[0];
                    foreach (var face in faces)
                        nextFrame.Draw(face.rect, new Bgr(0, double.MaxValue, 0), 3);
                }
                return nextFrame.ToBitmap();
            }
        }

        public void FaceDetectSave(HaarCascade haar, Image<Bgr, byte> img, string ID, int count)
        {
            using (Image<Bgr, byte> nextFrame = img)
            {
                if (nextFrame != null)
                {
                    Image<Gray, byte> grayframe = nextFrame.Convert<Gray, byte>();
                    var faces = 
                            grayframe.DetectHaarCascade(
                                    haar, 1.1, 3,
                                    HAAR_DETECTION_TYPE.DEFAULT,
                                    new Size(nextFrame.Width / 4, nextFrame.Height / 8)
                                    )[0];
                    foreach (var face in faces)
                        grayframe.Save($"photo\\dataset\\user.{ID}.{count}.png");
                }
            }
        }
    }
}
