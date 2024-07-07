namespace CustomDependencyContainer;

public class Dependency(Type type, DependencyLifetime lifetime)
{
    public readonly Type Type = type;
    public readonly DependencyLifetime Lifetime = lifetime;
}
