namespace CustomDependencyContainer;

public class LoginService(EmailService emailService, LogService logService)
{
    public void LogIn()
    {
        logService.logSuccess("Successfully logged in");
        emailService.Send();
    } 
}