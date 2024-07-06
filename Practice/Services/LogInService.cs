namespace CustomDependencyContainer;
 
public  class LogInService(LogService logService)
{
    public void Login()
    {
        logService.logSuccess("Successfully logged in");
    }
    
}