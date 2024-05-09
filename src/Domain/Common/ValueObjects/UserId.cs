using Domain.Common.Models;

namespace Domain.Common.ValueObjects;

public sealed class UserId : AggregateRootId<Guid>
{
    private UserId(Guid value) : base(value)
    {
    }

    public static UserId Create(Guid value)
    {
        return new UserId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}