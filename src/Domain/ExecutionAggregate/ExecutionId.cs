using Domain.Common.Models;

namespace Domain.ExecutionAggregate;

public sealed class ExecutionId : AggregateRootId<Guid>
{
    private ExecutionId(Guid value) : base(value)
    {
    }

    public static ExecutionId Create(Guid value)
    {
        return new ExecutionId(value);
    }

    public static ExecutionId CreateUnique()
    {
        return new ExecutionId(Guid.NewGuid());
    }
}