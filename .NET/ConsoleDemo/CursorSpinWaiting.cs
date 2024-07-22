namespace ConsoleDemo
{
    internal class CursorSpinWaiting
    {

       public static void Process()
        {
            Console.WriteLine("正在处理，请稍候...");

            using (var spinner = new ConsoleSpinner())
            {
                // 模拟一些耗时操作
                for (int i = 0; i < 100; i++)
                {
                    spinner.Turn();
                    Thread.Sleep(100);  // 模拟工作
                }
            }

            Console.WriteLine("\n处理完成！");
        }
    }

    public class ConsoleSpinner : IDisposable
    {
        private int _counter = 0;
        private readonly int _left;
        private readonly int _top;
        private readonly string[] _sequence;

        public ConsoleSpinner()
        {
            _sequence = new[] { "/", "-", "\\", "|" };
            _left = Console.CursorLeft;
            _top = Console.CursorTop;
            Console.CursorVisible = false;
        }

        public void Turn()
        {
            Console.SetCursorPosition(_left, _top);
            Console.Write(_sequence[_counter++ % _sequence.Length]);
        }

        public void Dispose()
        {
            Console.SetCursorPosition(_left, _top);
            Console.Write(" ");
            Console.CursorVisible = true;
        }
    }

}
