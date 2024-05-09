using Domain.Common.Models;

namespace Domain.Common.ValueObjects;

public sealed class UserId : EntityId<Guid>
{
    private UserId(Guid value) : base(value)
    {
    }

    public static UserId Create(Guid value)
    {
        return new UserId(value);
    }

    // #pragma warning disable CS8618
    //     private UserId()
    //     {
    //     }
    // #pragma warning restore CS8618
}