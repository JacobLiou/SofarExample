// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System.Diagnostics;
using System.Reflection.Emit;
using System.Text.Json;
using ConsoleDemo;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;


internal class Program
{
    private static void Main(string[] args)
    {

        string hello = "hello";
        var isIntern = string.IsInterned(hello);
        Console.WriteLine(isIntern);


        var builder = Host.CreateApplicationBuilder(args);
        builder.Build();
        var yourname = builder.Configuration["yourname"];
        Console.WriteLine(yourname);


        // var cademo = new CatsleDemo();
        // cademo.UseDicAdaptor();

        var dic = new Dictionary<Point, int>
        {
            { new Point(1.0, 1.0), 1 },
            { new Point(2.0, 2.0), 2 },
            { new Point(3.0, 3.0), 3 }
        };

        //STJ
        try
        {
            var json = System.Text.Json.JsonSerializer.Serialize(dic);
            Console.WriteLine(json);

            var dic2 = System.Text.Json.JsonSerializer.Deserialize<Dictionary<Point, int>>(json);
            Debug.Assert(dic2[new Point(1.0, 1.0)] == 1);
            Debug.Assert(dic2[new Point(2.0, 2.0)] == 2);
            Debug.Assert(dic2[new Point(3.0, 3.0)] == 3);
        }
        catch
        {

        }

        //Newtonsoft.Json
        try
        {
            var json1 = JsonConvert.SerializeObject(dic);
            Console.WriteLine(json1);

            var dic2 = JsonConvert.DeserializeObject<Dictionary<Point, int>>(json1);
            Debug.Assert(dic2[new Point(1.0, 1.0)] == 1);
            Debug.Assert(dic2[new Point(2.0, 2.0)] == 2);
            Debug.Assert(dic2[new Point(3.0, 3.0)] == 3);
        }
        catch
        {

        }

        var dynamicMethod = new DynamicMethod("GetValue", typeof(object), new[] { typeof(string) }, typeof(Program));

        var ilGen = dynamicMethod.GetILGenerator();
        ilGen.Emit(OpCodes.Ldstr, "ABC");
        ilGen.Emit(OpCodes.Starg, 0);
        // 返回局部变量的值
        ilGen.Emit(OpCodes.Ldarg_0); // 加载第一个参数（message）
        ilGen.Emit(OpCodes.Ret);     // 返回该值


    }

    public static object GetValue(string arg)
    {
        arg = "abc";
        return arg;
    }
}


//字典自定义key序列化的规则要匹配
// https://stackoverflow.com/questions/42677693/serialize-deserialize-a-dictionary-that-contain-a-class-key
// https://stackoverflow.com/questions/58167956/json-serialize-deserialize-for-a-dictionary-with-custom-key-by-overriding-tostri
public readonly record struct Point(double x, double y)
{
    public override string ToString() => $"{x}, {y}";

    public static Point Parse(string s)
    {
        var tokens = s.Trim('(', ')').Split(',', StringSplitOptions.TrimEntries);
        if (tokens.Length != 2)
        {
            throw new FormatException("Invalid format");
        }
        return new Point(double.Parse(tokens[0]), double.Parse(tokens[1]));
    }
}



