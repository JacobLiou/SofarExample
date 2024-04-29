// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using Spectre.Console;

Console.WriteLine("Hello Spectre");

AnsiConsole.WriteLine("Hello Spectre");
AnsiConsole.Markup("[underline red]Hello [/] [Blue]World[/][DarkMagenta]!!![/]");
//AnsiConsole ansiConsole = new(); 
//Spectre.Console.Progress progress = new Progress();

AnsiConsole.WriteLine();

var table = new Table();
table.AddColumn("[red]编号[/]");
table.AddColumn("[green]姓名[/]");
table.AddColumn("[blue]年龄[/]");

//添加一些行
table.AddRow("1", "追逐时光者", "20岁");
table.AddRow("2", "大姚", "22岁");
table.AddRow("3", "小袁", "18岁");
table.AddRow("4", "小明", "23岁");

AnsiConsole.Write(table);

var barChart = new BarChart();
barChart.Width = 100;
barChart.AddItem("杨过", 50, Color.Yellow);
barChart.AddItem("小龙女", 50, Color.Green);

AnsiConsole.WriteLine();
AnsiConsole.Write(barChart);



Console.ReadKey();


