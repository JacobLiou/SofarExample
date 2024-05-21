public class PatternMatchDemo
{
    public static void Call()
    {
        object age = null;
        if (age is not null && age is 100)
        {
            Console.WriteLine("age = " + age);
        }

        object age1 = 6;
        if (age1 is int and >= 6)
        {
            Console.WriteLine("age1 = " + age1);
        }

        var hello = age switch
        {
            1 or 2 => "Hellos",
            6 => "lala",
            _ => "",
        };

        Console.WriteLine(hello);

        DateTime birthday = new DateTime(1999, 11, 12);
        if (birthday is { Year: < 2000, Month: 1 or 11 })
        {
            Console.WriteLine("年龄、星座不合适");
        }
    }
}