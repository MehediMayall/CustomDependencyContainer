namespace CustomDependencyContainer;

public class DependencyResolver(DependencyContainer container)
{
    public T GetServices<T>()
    {
        var dependency = container.GetDependency<T>();
        var parameters = dependency.Type.GetConstructors().Single().GetParameters().ToArray();

        if (parameters.Length ==0)
            return (T) Activator.CreateInstance(dependency.Type);
        
        List<object> ConstructorDependencies = new List<object>();
        foreach (var parameter in parameters)
            ConstructorDependencies.Add(Activator.CreateInstance(parameter.ParameterType));

        return (T) Activator.CreateInstance(dependency.Type, ConstructorDependencies.ToArray());        
    }
}