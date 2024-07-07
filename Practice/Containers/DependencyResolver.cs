using System.Reflection;

namespace CustomDependencyContainer;

public class DependencyResolver(DependencyContainer container)
{
    public T GetServices<T>()
    {
        var dependency = container.GetDependency(typeof(T)) ?? 
            throw new Exception($"{typeof(T).Name} is not registered. Please register this service");

        ParameterInfo[] parameters = dependency.Type.GetConstructors().Single().GetParameters();

        if ( parameters.Length ==0 )
            return (T) Activator.CreateInstance(dependency.Type);

        List<object> constructorImplementations = new List<object>();

        foreach(ParameterInfo parameter in parameters)
        {
            if ( container.GetDependency(parameter.ParameterType) is null)
                throw new Exception($"{parameter.ParameterType.Name} is not registered. Please register this service");
            constructorImplementations.Add(Activator.CreateInstance(parameter.ParameterType));
        }

        return (T) Activator.CreateInstance(dependency.Type, constructorImplementations.ToArray());
    }
}