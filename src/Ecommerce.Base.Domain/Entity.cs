using System.Diagnostics.CodeAnalysis;

namespace Ecommerce.Base.Domain;

public abstract class Entity : IEquatable<Entity>, IEqualityComparer<Entity>
{
    public Guid Id { get; init; }


    public bool Equals(Entity? other)
    {
        if (other is null)
            return false;
        return Id.Equals(other.Id);
    }

    public bool Equals(Entity? x, Entity? y)
    {
        if (x is null && y is null) return true;
        if (x is null || y is null) return false;
        return x.Equals(y);
    }

    public int GetHashCode([DisallowNull] Entity obj)
    {
        return HashCode.Combine(Id, obj.Id);
    }
}