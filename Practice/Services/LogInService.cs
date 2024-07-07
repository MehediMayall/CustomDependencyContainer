namespace CustomDependencyContainer;

public class LoginService(LogService logService)
{
    public void LogIn() => logService.logSuccess("Successfully logged in");
}