// See https://aka.ms/new-console-template for more information
using MethodDecorator.Fody.Interfaces;
using System.Reflection;

Console.WriteLine("Hello, World!");
MyClass myClass = new MyClass();
myClass.MyMethod();
Console.ReadKey();

public class LogAttribute : Attribute, IMethodDecorator
{
    private MethodBase? _method;

    private object? _instance;

    private object[]? _args;

    public void Init(object instance, MethodBase method, object[] args)
    {
        _instance = instance;
        _method = method;
        _args = args;
    }

    public void OnEntry()
    {
        Console.WriteLine($"Entering {_method?.Name}");
    }

    public void OnExit()
    {
        Console.WriteLine($"Exiting {_method?.Name}");
    }

    public void OnException(Exception exception)
    {
        Console.WriteLine($"Exception in {_method?.Name}: {exception.Message}");
    }
}

public class MyClass
{
    [Log]
    public void MyMethod()
    {
        // 方法实现
        Console.WriteLine($"Executing AOP Method {nameof(MyMethod)}");
    }
}