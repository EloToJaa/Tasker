using Domain.Common.Models;

namespace Domain.ExecutionAggregate.Entities;

public sealed class ExecutionSetId : EntityId<Guid>
{
    private ExecutionSetId(Guid value) : base(value)
    {
    }

    public static ExecutionSetId Create(Guid value)
    {
        return new ExecutionSetId(value);
    }

    public static ExecutionSetId CreateUnique()
    {
        return new ExecutionSetId(Guid.NewGuid());
    }
}