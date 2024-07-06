namespace CustomDependencyContainer;
using static System.Console;

public class LogService : ILogService
{
    public void log(string message, ConsoleColor color = ConsoleColor.DarkGreen)
    {
        Console.ForegroundColor = color;
        WriteLine(message);
    }
    public void logError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        WriteLine(message);
    }
}