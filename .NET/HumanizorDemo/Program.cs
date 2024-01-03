using Humanizer;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine("PascalCaseInputStringIsTurnedIntoSentence".Humanize());

var yesterday = DateTime.UtcNow.AddHours(-30).Humanize();
Console.WriteLine(yesterday);
Console.WriteLine(DateTimeOffset.UtcNow.AddHours(1).Humanize());