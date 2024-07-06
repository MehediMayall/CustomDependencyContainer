namespace CustomDependencyContainer;

public class DependencyContainer
{
    private List<Dependency> dependencies;
    public DependencyContainer()
    {
        dependencies = new List<Dependency>();
    }

    public void AddSingleton<T>()=>
        dependencies.Add(new Dependency(typeof(T), DependencyLifetime.Singleton));

    public void AddTransient<T>()=>
        dependencies.Add(new Dependency(typeof(T), DependencyLifetime.Transient));

    public Dependency GetDependency<T>() =>
        dependencies.FirstOrDefault(x => x.Type.Name == typeof(T).Name);

}
