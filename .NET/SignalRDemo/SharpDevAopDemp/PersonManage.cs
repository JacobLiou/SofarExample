namespace SharpDevAopDemp;

using DeveloperSharp.Structure.Model;
using DeveloperSharp.Structure.Model.Aspect;

public class PersonManage : LogicLayer
{
    public string GetInfo1(string Name, int Num)
    {
        return $"{Name} {Num} 人";
    }
}

public class Interceptor1 : AspectModel
{
    //PreProcess方法先于主程序执行
    public override void PreProcess(object sender, AspectEventArgs e)
    {
        //把主程序的两个参数值改掉
        e.MethodInfo.ParameterValues[0] = "老师";
        e.MethodInfo.ParameterValues[1] = 20;
    }

    //PostProcess方法后于主程序执行
    public override void PostProcess(object sender, AspectEventArgs e)
    {

    }

    public void UseGoto()
    {
        // https://stackoverflow.com/questions/3517726/what-is-wrong-with-using-goto
        for (int i = 0; i < 1000; i++)
        {
            for (int j = 0; j < 10000; j++)
            {
                if(j = 100)
                    goto OutNested;
            }
        }

    OutNested:
        var x = 1 +2;
        Console.WriteLine(x);

    }
}