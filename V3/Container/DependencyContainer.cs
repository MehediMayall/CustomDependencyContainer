namespace CustomDependencyContainer;

public class DependencyContainer
{
    private List<Dependency> dependencies;

    public DependencyContainer() =>
        dependencies = new List<Dependency>();
    

    public void AddSingleton<T,TImp>() =>
        dependencies.Add(new Dependency(typeof(T), typeof(TImp), DependencyLifetime.Singleton));
    
    public void AddTransient<T>() =>
        dependencies.Add(new Dependency(typeof(T), null, DependencyLifetime.Transient));
    public void AddTransient<T,TImp>() =>
        dependencies.Add(new Dependency(typeof(T), typeof(TImp), DependencyLifetime.Transient));
    

    public Dependency? GetDependency(Type type) => 
        dependencies.Find(
            x => x.Type.Name == type.Name || 
            x.ImplementationType.Name == type.Name
        );
    
}