namespace CustomDependencyContainer;
using static System.Console;

public class LogService
{
    private int instance;
    public LogService()
    {
        instance = Random.Shared.Next(111,999);
    }
    public void log(string message)
    {
        Console.ForegroundColor = ConsoleColor.White;
        WriteLine($"{instance} {message}");
    }
    
    public void logSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine($"{instance} {message}");
    }

}
