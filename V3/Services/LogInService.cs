namespace CustomDependencyContainer;

public class LogInService(EmailService emailService, ILogService logService): ILogInService
{
     

    public void LogIn()
    {
        logService.log("->| Login successfully");
        emailService.Send();
    }
}