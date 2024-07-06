namespace CustomDependencyContainer;

public class LogInService(EmailService emailService, LogService logService): ILogInService
{
     

    public void LogIn()
    {
        logService.log("->| Login successfully");
        emailService.Send();
    }
}