namespace CustomDependencyContainer;

public class DependencyContainer
{
    private List<Dependency> dependencies;
    public DependencyContainer()
    {
        dependencies = new List<Dependency>();    
    }

    public void AddSingleton<T>() =>
        dependencies.Add(new Dependency(typeof(T), DependencyLifetime.SINGLETON));
    public void AddTransient<T>() =>
        dependencies.Add(new Dependency(typeof(T), DependencyLifetime.TRANSIENT));

    public Dependency GetDependency(Type type) =>
        dependencies.Find(d=> d.Type.Name == type.Name);

}