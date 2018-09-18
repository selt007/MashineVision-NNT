namespace NNTSearchChar
{
    class Config
    {
        public static string HaarCascadePath = "haarcascades\\haarcascade_frontalface_default.xml";
        public static string FacePhotosPath = "photo\\dataset\\";
        public static string FaceListTextFile = "photo\\faceList.txt";
        public static int TimerResponseValue = 500;
        public static string ImageFileExtension = ".bmp";
        public static int ActiveCameraIndex = 0;//0: Default active camera device
    }
}
