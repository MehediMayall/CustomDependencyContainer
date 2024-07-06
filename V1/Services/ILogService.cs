namespace CustomDependencyContainer;

public interface ILogService
{
    void log(string message, ConsoleColor color = ConsoleColor.DarkGreen);

    void logError(string message);
}