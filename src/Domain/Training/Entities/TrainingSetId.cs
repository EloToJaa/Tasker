using Domain.Common.Models;

namespace Domain.Training.Entities;

public sealed class TrainingSetId : EntityId<Guid>
{
    private TrainingSetId(Guid value) : base(value)
    {
    }

    public static TrainingSetId Create(Guid value)
    {
        return new TrainingSetId(value);
    }

    public static TrainingSetId CreateUnique()
    {
        return new TrainingSetId(Guid.NewGuid());
    }
}