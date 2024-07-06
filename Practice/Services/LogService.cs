namespace CustomDependencyContainer;
using static Console;
public class LogService
{
    private int instanceNo;
    public LogService()
    {
        instanceNo = Random.Shared.Next(100,999);
    } 

    public void log(string message)
    {
        Console.ForegroundColor = ConsoleColor.White;
        WriteLine($"{instanceNo}# {message}");
    } 
    public void logSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine($"{instanceNo}# {message}");
    } 

}
