using Domain.Common.Models;
using Domain.Common.ValueObjects;
using Domain.Pupil;

namespace Domain.Trainer;

public sealed class Trainer : AggregateRoot<TrainerId, Guid>
{
    private readonly List<PupilId> _pupilIds = new();
    public IReadOnlyList<PupilId> PupilIds => _pupilIds.AsReadOnly();

    private Trainer(TrainerId trainerId) : base(trainerId, trainerId.GetUserId())
    {
    }

    public static Trainer Create(TrainerId trainerId)
    {
        return new Trainer(trainerId);
    }

    public void AddPupil(PupilId pupilId, UserId updatedBy)
    {
        base.Update(updatedBy);
        _pupilIds.Add(pupilId);
    }

    public void RemovePupil(PupilId pupilId, UserId updatedBy)
    {
        base.Update(updatedBy);
        _pupilIds.Remove(pupilId);
    }

#pragma warning disable CS8618
    private Trainer()
    {
    }
#pragma warning restore CS8618
}