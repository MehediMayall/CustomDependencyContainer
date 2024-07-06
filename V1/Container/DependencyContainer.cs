namespace CustomDependencyContainer;

public class DependencyContainer
{
    private List<Type> dependencies;

    public DependencyContainer()
    {
        dependencies = new List<Type>();
    }

    public void AddDependency(Type type)
    {
        dependencies.Add(type);
    }
    public void AddDependency<T>()
    {
        dependencies.Add(typeof(T));
    }

    public Type GetDependency(Type type)
    {
        return dependencies.First(x => x.Name == type.Name);
    }


}