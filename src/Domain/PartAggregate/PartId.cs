using Domain.Common.Models;

namespace Domain.PartAggregate;

public sealed class PartId : AggregateRootId<Guid>
{
    private PartId(Guid value) : base(value)
    {
    }

    public static PartId Create(Guid value)
    {
        return new PartId(value);
    }

    public static PartId CreateUnique()
    {
        return new PartId(Guid.NewGuid());
    }

}
