using CustomDependencyContainer;


var container = new DependencyContainer();
container.AddSingleton<LogService>();
container.AddSingleton<LogInService>();


var resolver =  new DependencyResolver(container);

// var logService = resolver.GetServices<LogService>();
// logService.log("Hello");

var loginService = resolver.GetServices<LogInService>();
loginService.Login();