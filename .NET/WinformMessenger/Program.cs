using System.Diagnostics;

namespace WinformMessenger;

static class Program
{
    [ThreadStatic]
    public static int num = 10;

    // https://www.cnblogs.com/huangxincheng/p/17982804 一线码农的这篇文章解释了为什么ThreadStatic只有第一个线程赋值成功
    public static ThreadLocal<int> numThread = new ThreadLocal<int>(() => 1);
    
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    /// 
    // https://stackoverflow.com/questions/18333885/threadstatic-v-s-threadlocalt-is-generic-better-than-attribute
    [STAThread]
    static void Main()
    {
        Test();

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }

    static void Test()
    {
        var t1 = new Thread(() =>
        {
            Debugger.Break();
            // var j = num;
            num = num + 1;
            Console.WriteLine(num);
            Console.WriteLine(numThread.Value);
            numThread.Value += 1;
            Console.WriteLine(numThread.Value);
            // Console.WriteLine($"tid={Thread.CurrentThread.ManagedThreadId}, num={j}");

        });
        t1.Start();
        t1.Join();

        var t2 = new Thread(() =>
        {
            Debugger.Break();
            // var j = num;
            num = num + 1;
            Console.WriteLine(numThread.Value);
            numThread.Value += 1;
            Console.WriteLine(numThread.Value);
            // Console.WriteLine($"tid={Thread.CurrentThread.ManagedThreadId}, num={j}");
        });

        t2.Start();
    }
}