namespace CustomDependencyContainer;

public class Dependency(Type type, DependencyLifetime lifetime) 
{
     public Type Type = type;
     public DependencyLifetime Lifetime = lifetime;
     public object Implementation {get; private set;}
     public bool IsImplemented {get;private set;}

     public void SetImplementatiton(object implementation)
     {
        Implementation = implementation;
        IsImplemented = true;
     }
}