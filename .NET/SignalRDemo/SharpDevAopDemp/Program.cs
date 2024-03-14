

using SharpDevAopDemp;

var pm = new PersonManage();

//要用这种形式调用主程序中的方法，AOP功能才会生效
var str = pm.InvokeMethod("GetInfo1", "学生", 200);
Console.WriteLine(str);
Console.ReadKey();


