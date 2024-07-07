namespace CustomDependencyContainer;
using static System.Console;

public class LogService
{
    public void log(string message)
    {
        Console.ForegroundColor = ConsoleColor.White;
        WriteLine(message);
    }
    
    public void logSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine(message);
    }

}
