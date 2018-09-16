using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NNTSearchChar
{
    class FaceRecognition
    {
        List<string> lList = new List<string>();
        /// <summary>
        ///     Call face detect and draw image with face and rectangle.
        /// </summary>
        /// <param name="haar">Field for using cascade Haar.</param>
        /// <param name="img">Argument for draw face from web-cam.</param>
        /// <param name="bmp">Set here some image, if u dont have web-cam</param>
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
        /// <summary>
        ///     Call face detect and save image with face in gray format in dataset.
        /// </summary>
        /// <param name="haar">Field for using cascade Haar.</param>
        /// <param name="img">Argument for draw face from web-cam.</param>
        /// <param name="ID">Set here user name for saving face in dataset.</param>
        /// <param name="count">Set here count photo user in dataset.</param>
        /// <param name="bmp">Set here some image, if u dont have web-cam</param>
        public void FaceDataset(HaarCascade haar, Image<Bgr, byte> img, string ID, int count, Bitmap bmp = null)
        {
            using (Image<Bgr, byte> nextFrame = new Image<Bgr, byte>(bmp))
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
                        grayframe.Save($"{Config.FacePhotosPath}user_{ID}-{count}{Config.ImageFileExtension}");
                }
            }
        }
        /// <summary>
        ///     Call face training.
        /// </summary>
        /// <param name="haar">Field for using cascade Haar.</param>
        /// <param name="nameUser">Set here user name for saving face in dataset.</param>
        public List<string> FaceTrain(HaarCascade haar, string nameUser)
        {
            var allPhotos = Directory.GetFiles(Config.FacePhotosPath);
            foreach (string photo in allPhotos)
            {
                int subsEnd = (Config.FacePhotosPath + "user_" + nameUser).Length;
                int subsStart = (Config.FacePhotosPath + "user_").Length;

                string name = photo.Substring(0, subsEnd).Substring(subsStart);
                if(name == nameUser)
                    lList.Add(photo);
            }

            MCvTermCriteria termCrit = new MCvTermCriteria(lList.Count, 0.001);
            //EigenObjectRecognizer recognizer = new EigenObjectRecognizer(imageList.ToArray(), lList.ToArray(), 3000, ref termCrit);

            return lList;
        }
    }
}
