using Domain.Common.ValueObjects;

namespace Domain.Common.Models;

public abstract class AggregateRoot<TId, TIdType> : Entity<TId>
    where TId : AggregateRootId<TIdType>
{
    public new AggregateRootId<TIdType> Id { get; protected set; }

    public DateTime CreatedAt { get; protected set; }
    public UserId CreatedBy { get; protected set; }

    public DateTime UpdatedAt { get; protected set; }
    public UserId UpdatedBy { get; protected set; }

    protected AggregateRoot(TId id, UserId createdBy)
    {
        Id = id;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        CreatedBy = createdBy;
        UpdatedBy = createdBy;
    }

    protected void Update(UserId updatedBy)
    {
        UpdatedAt = DateTime.UtcNow;
        UpdatedBy = updatedBy;
    }

#pragma warning disable CS8618
    protected AggregateRoot()
    {
    }
#pragma warning restore CS8618
}
