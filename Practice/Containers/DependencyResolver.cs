using System.Reflection;

namespace CustomDependencyContainer;

public class DependencyResolver(DependencyContainer container)
{
    public T GetServices<T>()
    {
        return (T) GetServices(typeof(T));
    }

    public object GetServices(Type type)
    {
        var dependency = container.GetDependency(type) ?? 
            throw new Exception($"{type.Name} is not registered. Please register this service");

        ParameterInfo[] parameters = dependency.Type.GetConstructors().Single().GetParameters();

        if ( parameters.Length ==0 )
        {
            return CreateImplementation(dependency, x => Activator.CreateInstance(dependency.Type));
        }

        List<object> constructorImplementations = new List<object>();

        foreach(ParameterInfo parameter in parameters)
        {
            if ( container.GetDependency(parameter.ParameterType) is null)
                throw new Exception($"{parameter.ParameterType.Name} is not registered. Please register this service");

            
            constructorImplementations.Add(
                GetServices(parameter.ParameterType)
            );
        }

        return CreateImplementation(dependency, x=> Activator.CreateInstance(dependency.Type, constructorImplementations.ToArray()));
    }

    private object CreateImplementation(Dependency dependency, Func<Type, object> factory)
    {
        if (dependency.IsImplemented)
            return  dependency.Implementation;

        var implementation = factory(dependency.Type);

        if (dependency.Lifetime == DependencyLifetime.SINGLETON)
            return  dependency.SetImplementation(implementation);

        return implementation;
    }
}