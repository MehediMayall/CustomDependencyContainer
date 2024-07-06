namespace CustomDependencyContainer;

public class DependencyResolver(DependencyContainer container)
{
     
     public T GetService<T>()
     {
        var dependency = container.GetDependency(typeof(T));
        var constructor = dependency.GetConstructors().Single();
        var parameters = constructor.GetParameters().ToArray();
        List<object> parameterImplementations = new List<object>();

        foreach ( var parameter in parameters)
            parameterImplementations.Append(Activator.CreateInstance(parameter.ParameterType));
        

        return (T) Activator.CreateInstance(dependency, parameterImplementations);
     }
}