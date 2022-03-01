// See https://aka.ms/new-console-template for more information
ParallelExperiment(LazyThreadSafetyMode.None);

ParallelExperiment(LazyThreadSafetyMode.PublicationOnly);

ParallelExperiment(LazyThreadSafetyMode.ExecutionAndPublication);

Console.ReadLine();

void ParallelExperiment(LazyThreadSafetyMode lazyThreadSafetyMode)
{
    Console.WriteLine($"LazyThreadSafetyMode - {lazyThreadSafetyMode}");

    Lazy<User> user = new(lazyThreadSafetyMode);

    Parallel.For(0, 7, new ParallelOptions { MaxDegreeOfParallelism = 3 }, (i) =>
    {
        Console.WriteLine($"#{i} Thread: {Environment.CurrentManagedThreadId:00} - HashCode: {user.Value.GetHashCode()}");
    });

    Console.WriteLine("---------------");
    Console.WriteLine($"HashCode: {user.Value.GetHashCode()}");
    Console.WriteLine("---------------\n\n");

    Task.Delay(500);
}

public class User
{
    public User()
    {
        Console.WriteLine("Creating user...");
        Task.Delay(500).Wait();
        Console.WriteLine($"User created! - {this.GetHashCode()}");
    }
}