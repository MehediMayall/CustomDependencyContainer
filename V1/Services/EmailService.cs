namespace CustomDependencyContainer;

public class EmailService: IEmailService
{
    public bool Send()
    {
        System.Console.WriteLine("Email successfully sent!");
        return true;
    }
}