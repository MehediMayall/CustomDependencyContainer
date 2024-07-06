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
        var dependency = container.GetDependency(type);
        ParameterInfo[] parameters = dependency.Type.GetConstructors().Single().GetParameters();

        if (parameters.Length == 0)
        {
            if (dependency.IsImplemented)
                return dependency.Implementation;

            var implementation = Activator.CreateInstance(dependency.Type); 

            if (dependency.Lifetime == DependencyLifetime.SINGLETON)
                return dependency.SentImplementation(implementation);

            return  implementation;
        }
        
        List<object> constructorServices = new List<object>();

        foreach(var parameter in parameters)
        {
            if (container.GetDependency(parameter.ParameterType) is null)
                throw new InvalidOperationException($"{parameter.ParameterType.Name} is not registered. Please register this dependency");

            object service = GetServices(parameter.ParameterType);
            constructorServices.Add(service);
        }
        
        return Activator.CreateInstance(dependency.Type, constructorServices.ToArray());
    }
}
