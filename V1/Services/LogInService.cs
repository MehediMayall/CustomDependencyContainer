namespace CustomDependencyContainer;

public class LogInService: ILogInService
{
    private readonly LogService logService;

    public LogInService(LogService logService)
    {
        this.logService = logService;
    }

    public void LogIn()
    {
        logService.log("->| Login successfully");
    }
}