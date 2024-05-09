using Domain.Common.Models;
using Domain.Common.ValueObjects;

namespace Domain.Pupil;

public sealed class PupilId : AggregateRootId<Guid>
{
    public PupilId(Guid value) : base(value)
    {
    }

    public static PupilId Create(Guid value)
    {
        return new PupilId(value);
    }

    public UserId GetUserId()
    {
        return UserId.Create(Value);
    }
}