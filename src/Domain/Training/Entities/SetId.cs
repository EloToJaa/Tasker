using Domain.Common.Models;

namespace Domain.Training.Entities;

public sealed class SetId : EntityId<Guid>
{
    private SetId(Guid value) : base(value)
    {
    }

    public static SetId Create(Guid value)
    {
        return new SetId(value);
    }

    public static SetId CreateUnique()
    {
        return new SetId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}