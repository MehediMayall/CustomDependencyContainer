namespace CustomDependencyContainer;

public class EmailService(LogService logService): IEmailService
{
    public bool Send()
    {
        logService.log("Email successfully sent!");
        return true;
    }
}