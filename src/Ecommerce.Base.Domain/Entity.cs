namespace Ecommerce.Base.Domain;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; init; }

    public bool Equals(Entity? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id;
    }

    public override bool Equals(object? obj) =>
        Equals(obj as Entity);
    
    public override int GetHashCode() =>
        Id.GetHashCode();

    public static bool operator ==(Entity left, Entity right)
    {
        if (left is null && right is null) return true;
        if (left is null || right is null) return false;
        if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
        {
            return false;
        }
        return ReferenceEquals(left, right) || left!.Equals(right);
    }
    public static bool operator !=(Entity left, Entity right) =>
        !(left == right);
}