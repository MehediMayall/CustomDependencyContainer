using CustomDependencyContainer;
using static System.Console;

var container = new DependencyContainer();

container.AddTransient<LogService>();
container.AddTransient<LogInService>();
container.AddTransient<EmailService>();

// var loginType = container.GetDependency(typeof(LogService));

// WriteLine(loginType);



// Using Dependency Resolver
var resolver = new DependencyResolver(container);

var logService = resolver.GetService<LogService>();
logService.log("Hello from dependency container service instance");

var logInService = resolver.GetService<LogInService>();
logInService.LogIn();

