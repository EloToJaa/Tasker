using Domain.Common.Models;

namespace Domain.ExerciseAggregate;

public sealed class ExerciseId : AggregateRootId<Guid>
{
    private ExerciseId(Guid value) : base(value)
    {
    }

    public static ExerciseId Create(Guid value)
    {
        return new ExerciseId(value);
    }

    public static ExerciseId CreateUnique()
    {
        return new ExerciseId(Guid.NewGuid());
    }
}