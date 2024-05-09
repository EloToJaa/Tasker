using Domain.Common.Models;

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

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}