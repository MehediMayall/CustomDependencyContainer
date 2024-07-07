namespace CustomDependencyContainer;

public class Dependency(Type type, DependencyLifetime lifetime)
{
    public readonly Type Type = type;
    public readonly DependencyLifetime Lifetime = lifetime;

    public object Implementation {get; private set;}
    public bool IsImplemented {get; private set;} = false;

    public object SetImplementation(object implementation)
    {
        IsImplemented = true;
        return Implementation = implementation;
    }
}
