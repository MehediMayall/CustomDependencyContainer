namespace CustomDependencyContainer;

public class DependencyResolver(DependencyContainer container)
{
    public T GetService<T>()
    {
        return (T) GetService(typeof(T));
    }
     
    public object GetService(Type type)
    {
        var dependency = container.GetDependency(type);
        var constructor = dependency.Type.GetConstructors().Single();
        var parameters = constructor.GetParameters().ToArray();

        if (parameters.Length == 0)
            return CreateImplementation(dependency, t=> Activator.CreateInstance(t));

        List<object> parameterImplementations = new List<object>();

        
        foreach ( var parameter in parameters)
        {
            if (container.GetDependency(parameter.ParameterType) is null)
                throw new ArgumentNullException($"{parameter.ParameterType.Name} is not registered as dependency"); 
            
            parameterImplementations.Add(
                GetService(parameter.ParameterType)
            );
        }

        return  CreateImplementation(dependency, t => Activator.CreateInstance(t, parameterImplementations.ToArray()));
    }

    private object CreateImplementation(Dependency dependency, Func<Type, object> factory)
    {
        if (dependency.IsImplemented)
                return dependency.Implementation;

        var implementation = factory(dependency.Type);

        if (dependency.Lifetime == DependencyLifetime.Singleton)
            dependency.SetImplementatiton(implementation);
            
        return implementation;
    }
}