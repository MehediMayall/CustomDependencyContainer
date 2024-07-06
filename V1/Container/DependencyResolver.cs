namespace CustomDependencyContainer;

public class DependencyResolver(DependencyContainer container)
{
     
     public T GetService<T>()
     {
        var dependency = container.GetDependency(typeof(T));
        var constructor = dependency.GetConstructors().Single();
        var parameters = constructor.GetParameters().ToArray();

        if (parameters.Length == 0)
            return (T) Activator.CreateInstance(dependency);

        List<object> parameterImplementations = new List<object>();
        foreach ( var parameter in parameters)
        {
            if (container.GetDependency(parameter.ParameterType) is null)
                throw new ArgumentNullException($"{parameter.ParameterType.Name} is not registered as dependency"); 
            parameterImplementations.Add(Activator.CreateInstance(parameter.ParameterType));
        }

        return (T) Activator.CreateInstance(dependency, parameterImplementations.ToArray());
     }
}