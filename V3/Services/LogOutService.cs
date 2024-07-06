namespace CustomDependencyContainer;

public class LogOutService: BaseService, ILogOutService
{
  
    public LogOutService()
    {
 
    }
    public void LogOut()
    {
        log("|<- Successfully logout.");
    }
}