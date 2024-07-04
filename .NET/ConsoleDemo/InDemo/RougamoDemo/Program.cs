// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Rougamo.Context;
using Rougamo;
using Newtonsoft.Json;

[AttributeUsage(AttributeTargets.Method)]
public class LoggingAttribute : MoAttribute
{
    public override void OnEntry(MethodContext context)
    {
        Console.WriteLine("执行方法 {0}() 开始，参数：{1}.", context.Method.Name,
            JsonConvert.SerializeObject(context.Arguments));
    }
    public override void OnException(MethodContext context)
    {
        Console.WriteLine("执行方法 {0}() 异常，{1}.", context.Method.Name, context.Exception.Message);
    }
    public override void OnExit(MethodContext context)
    {
        Console.WriteLine("执行方法 {0}() 结束.", context.Method.Name);
    }
    public override void OnSuccess(MethodContext context)
    {
        Console.WriteLine("执行方法 {0}() 成功.", context.Method.Name);
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Add(1, 2);
        AddAsync(1, 2);
        Divide(1, 2);
    }

    [Logging]
    static int Add(int a, int b) => a + b;

    [Logging]
    static Task<int> AddAsync(int a, int b) => Task.FromResult(a + b);

    [Logging]
    static decimal Divide(decimal a, decimal b) => a / b;
}
