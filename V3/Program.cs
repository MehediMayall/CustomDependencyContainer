using CustomDependencyContainer;
using static System.Console;

var container = new DependencyContainer();

container.AddTransient<ILogService,LogService>();
container.AddTransient<ILogInService, LogInService>();
container.AddTransient<IEmailService, EmailService>();

// var loginType = container.GetDependency(typeof(LogService));

// WriteLine(loginType);



// Using Dependency Resolver
var resolver = new DependencyResolver(container);

var logService = resolver.GetService<ILogService>();
logService.log("Hello from dependency container service instance");

var logInService = resolver.GetService<ILogInService>();
logInService.LogIn();

