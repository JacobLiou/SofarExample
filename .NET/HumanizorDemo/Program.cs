using Humanizer;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine("PascalCaseInputStringIsTurnedIntoSentence".Humanize());

var yesterday = DateTime.UtcNow.AddHours(-30).Humanize();
Console.WriteLine(yesterday);
Console.WriteLine(DateTimeOffset.UtcNow.AddHours(1).Humanize());


//
//rabbitMQ using C# with Producer and Comsumer

//PriorityQueuue
PriorityQueue<string, int> priorityQueue = new PriorityQueue<string, int>();
priorityQueue.Enqueue("Student", 1);
priorityQueue.Enqueue("Teacher", 2);
priorityQueue.Enqueue("Pricipal", 3);
priorityQueue.Enqueue("President", 4);
priorityQueue.DequeueEnqueue("Student", 2);
Console.WriteLine(priorityQueue.Dequeue());
Console.WriteLine(priorityQueue.Dequeue());
Console.WriteLine(priorityQueue.Dequeue());
Console.WriteLine(priorityQueue.Dequeue());

//An instance of PriorityQueue is not thread-safe. Although we have a thread-safe implementation of the regular queue in C#: ConcurrentQueue, we still don’t have that for the priority queue. So, if we’re working in a multithreaded environment, we have to tackle race conditions ourselves when working with PriorityQueue. 


//https://code-maze.com/csharp-priority-queue/
Console.ReadLine();