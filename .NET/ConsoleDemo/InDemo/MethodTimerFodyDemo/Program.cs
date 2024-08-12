// See https://aka.ms/new-console-template for more information
using MethodTimer;
namespace MethodTimerFodyDemo
{
    internal class Program
    {
        /// <summary>
        /// 程序入口
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            DoSomething();

            Console.WriteLine("测试方法执行结束!！！");

            Console.ReadKey();
        }

        /// <summary>
        /// 示例方法
        /// </summary>
        [Time]
        public static void DoSomething()
        {
            Task.Delay(1000).Wait();
            Console.WriteLine("测试方法执行时间！！！");
        }
    }
}