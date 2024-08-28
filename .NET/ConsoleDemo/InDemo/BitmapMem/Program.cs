//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Diagnostics;
using System.Drawing;

// 创建一个新的Bitmap对象，大小为100x100像素  
//    Bitmap 对象中每个像素点所占用的字节数取决于位图的颜色深度（color depth）。这里有几个常见的颜色格式：

//1位深度（黑白）：每个像素1比特
//8位深度（256色）：每个像素1字节
//16位深度（高彩色）：每个像素2字节（如 RGB 565）
//24位深度（真彩色）：每个像素3字节
//32位深度（真彩色 + Alpha）：每个像素4字节（如 ARGB 8888）

//默认按 32 位深度的来计算，21000x21000 像素的 Bitmap 约占用 1.64 GB

// 4 * 21000 * 21000 / 1024 / 1024 / 1024
Bitmap bitmap = new Bitmap(21000, 21000);

// 获取Bitmap的Graphics对象，用于绘制  
using (Graphics g = Graphics.FromImage(bitmap))
{
    // 设置背景色为蓝色  
    g.Clear(Color.Blue);

    // 示例：在Bitmap上绘制一个红色的圆  
    // 设置画笔颜色为红色  
    using (Pen pen = new Pen(Color.Red, 10000)) // 10为画笔粗细  
    {
        // 绘制圆，圆心为(50, 50)，半径为30  
        g.DrawEllipse(pen, 10000, 10000, 15000, 15000);
    }

    // 示例：在Bitmap上绘制文本  
    // 设置字体  
    using (Font font = new Font("Arial", 1600))
    {
        // 设置画刷颜色为白色  
        using (Brush brush = new SolidBrush(Color.White))
        {
            // 在Bitmap上绘制文本，位置为(10, 70)  
            g.DrawString("Hello, Bitmap!", font, brush, new PointF(100, 700));
        }
    }
}

// 保存Bitmap到文件  
bitmap.Save("example.png", System.Drawing.Imaging.ImageFormat.Png);

Console.ReadLine();

// 释放Bitmap资源  
bitmap.Dispose();

Console.WriteLine("Bitmap saved as example.png");

Debugger.Break();
Console.ReadLine();
