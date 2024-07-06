namespace CustomDependencyContainer;

public class EmailService(LogService logService)
{
    public void Send() => logService.log("Successfully sent email!");
}