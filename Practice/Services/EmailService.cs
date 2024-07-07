namespace CustomDependencyContainer;

public class EmailService(LogService logService)
{
    public void Send() =>
        logService.logSuccess("Succcessfully sent email");
}