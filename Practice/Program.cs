using CustomDependencyContainer;
using static System.Console;

var container = new DependencyContainer();

container.AddSingleton<LogService>();
container.AddTransient<LoginService>();
container.AddTransient<EmailService>();

// var loginService = container.GetDependency(typeof(LoginService));
// WriteLine(loginService.Type.Name);

var resolver = new DependencyResolver(container);

var logService = resolver.GetServices<LogService>();
logService.log("Hello from dependency container instance");


// var emailService = resolver.GetServices<EmailService>();
// emailService.Send();

var loginService = resolver.GetServices<LoginService>();
loginService.Login();

