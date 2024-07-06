namespace CustomDependencyContainer;

public class LogInService: ILogInService
{
    private readonly ILogService logService;

    public LogInService(ILogService logService)
    {
        this.logService = logService;
    }

    public void LogIn()
    {
        logService.log("->| Login successfully");
    }
}