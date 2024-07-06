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
        var constructor = dependency.GetConstructors().Single();
        var parameters = constructor.GetParameters().ToArray();

        if (parameters.Length == 0)
            return Activator.CreateInstance(dependency);

        List<object> parameterImplementations = new List<object>();
        foreach ( var parameter in parameters)
        {
            if (container.GetDependency(parameter.ParameterType) is null)
                throw new ArgumentNullException($"{parameter.ParameterType.Name} is not registered as dependency"); 
            parameterImplementations.Add(
                GetService(parameter.ParameterType)
            );
        }

        return  Activator.CreateInstance(dependency, parameterImplementations.ToArray());
    }
}