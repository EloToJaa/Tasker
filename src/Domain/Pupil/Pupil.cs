using Domain.Common.Models;
using Domain.Common.ValueObjects;

namespace Domain.Pupil;

public sealed class Pupil : AggregateRoot<UserId, Guid>
{
    public UserId TrainerId { get; set; }

    public Pupil(UserId pupilId, UserId trainerId) : base(pupilId, pupilId)
    {
        TrainerId = trainerId;
    }

    public static Pupil Create(UserId pupilId, UserId trainerId)
    {
        return new Pupil(pupilId, trainerId);
    }

    public void Update(UserId trainerId, UserId updatedBy)
    {
        base.Update(updatedBy);

        TrainerId = trainerId;
    }
}