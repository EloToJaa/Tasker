using Domain.Common.Models;
using Domain.Common.ValueObjects;
using Domain.TrainerAggregate;

namespace Domain.PupilAggregate;

public sealed class Pupil : AggregateRoot<PupilId, Guid>
{
    public TrainerId TrainerId { get; set; }

    public Pupil(PupilId pupilId, TrainerId trainerId) : base(pupilId, pupilId.GetUserId())
    {
        TrainerId = trainerId;
    }

    public static Pupil Create(PupilId pupilId, TrainerId trainerId)
    {
        return new Pupil(pupilId, trainerId);
    }

    public void Update(TrainerId trainerId, UserId updatedBy)
    {
        base.Update(updatedBy);

        TrainerId = trainerId;
    }

#pragma warning disable CS8618
    private Pupil()
    {
    }
#pragma warning restore CS8618
}