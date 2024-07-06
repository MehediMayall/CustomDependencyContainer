namespace CustomDependencyContainer;

public class Dependency(Type type, DependencyLifetime lifetime)
{
    public Type Type = type;
    public DependencyLifetime Lifetime = lifetime;

    public object Implementation {get; private set;}
    public bool IsImplemented {get; private set;} = true;

    public void SetImplementation(object implementation) => Implementation = implementation;
}
