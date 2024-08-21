using System;
using System.Collections.Concurrent;

namespace WebAppDemo
{
    public class BlockingDemo
    {

        private readonly BlockingCollection<DataItem> dataItems = new();

        public void TaskDemo()
        {
            Task.Run(() =>
            {
                dataItems.TryAdd(new DataItem() { Id = 1 });
                dataItems.TryAdd(new DataItem() { Id = 2 });
                dataItems.TryAdd(new DataItem() { Id = 3 });
                dataItems.TryAdd(new DataItem() { Id = 4 });
            });

            dataItems.Dispose();
        }


        public void RecordDemo()
        {          
            var person1 = new Person("vip", "wan", 18);
            var person2 = person1 with { Age = 30 };
            Console.WriteLine(person1); // 输出: Person { FirstName = vip, LastName = wan, Age = 18 }
            Console.WriteLine(person2); // 输出: Person { FirstName = vip, LastName = wan, Age = 30 }

            Console.WriteLine(person1 == person2);
            var person3 = person1;
            Console.WriteLine(person3 == person1);

            //person3.re
            var (firstName, lastName, age) = person1;
        }
    }

    public record Person(string FirstName, string LastName, int Age);

    public record DataItem
    {
        public int Id { get; set; }
    }
}
