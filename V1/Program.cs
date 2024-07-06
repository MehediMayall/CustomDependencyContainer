using CustomDependencyContainer;
using static System.Console;

var container = new DependencyContainer();
container.AddDependency(typeof(LogService));
container.AddDependency<LogInService>();

// var loginType = container.GetDependency(typeof(LogService));

// WriteLine(loginType);



// Using Dependency Resolver
var resolver = new DependencyResolver(container);
var logInService = resolver.GetService<LogInService>();

 logInService.LogIn();