// See https://aka.ms/new-console-template for more information
Console.WriteLine("LazyThreadSafetyMode - None");
ParallelExperiment(LazyThreadSafetyMode.None);
Task.Delay(500);

Console.WriteLine("LazyThreadSafetyMode - PublicationOnly");
ParallelExperiment(LazyThreadSafetyMode.PublicationOnly);
Task.Delay(500);

Console.WriteLine("LazyThreadSafetyMode - ExecutionAndPublication");
ParallelExperiment(LazyThreadSafetyMode.ExecutionAndPublication);
Task.Delay(500);

Console.ReadLine();

void ParallelExperiment(LazyThreadSafetyMode lazyThreadSafetyMode)
{
    Lazy<User> user = new(lazyThreadSafetyMode);

    Parallel.For(0, 7, new ParallelOptions { MaxDegreeOfParallelism = 3 }, (i) =>
    {
        Console.WriteLine($"#{i} Thread: {Environment.CurrentManagedThreadId:00} - HashCode: {user.Value.GetHashCode()}");
    });

    Console.WriteLine("---------------");
    Console.WriteLine($"HashCode: {user.Value.GetHashCode()}");
    Console.WriteLine("---------------\n\n");
}

public class User
{
    public User()
    {
        Console.WriteLine("Creating user...");
        Task.Delay(1000).Wait();
        Console.WriteLine($"User created! - {this.GetHashCode()}");
    }
}