namespace CustomDependencyContainer;

public class LogInService: BaseService, ILogInService
{
     

    public LogInService()
    {
    }

    public void LogIn()
    {
        log("->| Login successfully");
    }
}