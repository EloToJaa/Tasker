using Domain.Common.Models;
using Domain.Common.ValueObjects;

namespace Domain.Trainer;

public sealed class TrainerId : AggregateRootId<Guid>
{
    public TrainerId(Guid value) : base(value)
    {
    }

    public static TrainerId Create(Guid value)
    {
        return new TrainerId(value);
    }

    public UserId GetUserId()
    {
        return UserId.Create(Value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}