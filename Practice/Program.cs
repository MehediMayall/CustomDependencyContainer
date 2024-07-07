using CustomDependencyContainer;

// new LoginService(new LogService()).LogIn();


var container = new DependencyContainer();
container.AddSingleton<LogService>();
container.AddTransient<LoginService>();
container.AddTransient<EmailService>();

var resolver = new DependencyResolver(container);


// Log Serivce
var logService = resolver.GetServices<LogService>();
logService.log("Hello from Dependency container instance");


// LogInService --> LogService
var loginService = resolver.GetServices<LoginService>();
loginService.LogIn();


// EmailService --> LogService
var emailService = resolver.GetServices<EmailService>();
emailService.Send();
