namespace CustomDependencyContainer;

public class Dependency(Type type, Type implementationType, DependencyLifetime lifetime) 
{
     public Type Type = type;
     public Type ImplementationType = implementationType;
     public DependencyLifetime Lifetime = lifetime;
     public object Implementation {get; private set;}
     public bool IsImplemented {get;private set;} = false;

     public object SetImplementatiton(object implementation)
     {
        IsImplemented = true;
        return Implementation = implementation;
     }
}