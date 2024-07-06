namespace CustomDependencyContainer;

public class LoginService(EmailService emailService, LogService logService)
{
    public void Login() => logService.logSuccess("Successfully logged in");

}