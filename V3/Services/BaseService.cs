namespace CustomDependencyContainer;
using static System.Console;

public class BaseService
{
    protected void log(string message, ConsoleColor color = ConsoleColor.DarkGreen)
    {
        Console.ForegroundColor = color;
        WriteLine(message);
    }
    protected void logError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        WriteLine(message);
    }
}