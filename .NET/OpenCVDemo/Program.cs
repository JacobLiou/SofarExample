// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using OpenCvSharp;

//using var img = new Mat(Path.Combine(Environment.CurrentDirectory, "background.jpg"));
using Mat mat = Cv2.ImRead(Path.Combine(Environment.CurrentDirectory, "background.jpg"));
if(mat == null )
    return;
//Cv2.ImShow("MU", mat);

//平整切割成16块
int columnCount = 4;
int rowCount = 4;

int width = mat.Width / columnCount;
int height = mat.Height / rowCount;
for (int i = 0; i < columnCount; i++)
{
    for (int j = 0; j < rowCount; j++)
    {
        Rect rect = new Rect(i * width, j * height, width, height);
        Mat croppedImage = new Mat(mat, rect);
        croppedImage.SaveImage(Path.Combine(Environment.CurrentDirectory, $"Cropped{i}{j}.jpg"));
    }
}

Console.ReadKey();

