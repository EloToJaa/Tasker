using Domain.Common.Models;
using Domain.ExecutionAggregate.Entities;
using Domain.PupilAggregate;
using Domain.TrainerAggregate;
using Domain.TrainingAggregate;

namespace Domain.ExecutionAggregate;

public sealed class Execution : AggregateRoot<ExecutionId, Guid>
{
    public TrainingId TrainingId { get; private set; }
    public PupilId PupilId { get; private set; }
    public TrainerId TrainerId { get; private set; }
    public DateTime DateToComplete { get; private set; }
    public DateTime? CompletionDate { get; private set; }
    public bool Completed => CompletionDate.HasValue;
    public int NumberOfExercises { get; private set; }
    public int Duration { get; private set; }
    public IReadOnlyList<ExecutionSet> Sets => _sets.AsReadOnly();
    private readonly List<ExecutionSet> _sets = new();

    private Execution(ExecutionId id, TrainingId trainingId, PupilId createdBy, TrainerId trainerId, DateTime dateToComplete, List<ExecutionSet> sets) : base(id, createdBy.GetUserId())
    {
        TrainingId = trainingId;
        PupilId = PupilId.Create(createdBy.Value);
        TrainerId = trainerId;
        DateToComplete = dateToComplete;
        CompletionDate = null;

        _sets.AddRange(sets);
        NumberOfExercises = sets.Count;
        Duration = sets.Sum(s => s.Time);
    }

    public static Execution Create(TrainingId trainingId, PupilId createdBy, TrainerId trainerId, DateTime dateToComplete, List<ExecutionSet> sets)
    {
        return new Execution(ExecutionId.CreateUnique(), trainingId, createdBy, trainerId, dateToComplete, sets);
    }

    public void Complete(List<ExecutionSet> sets)
    {
        base.Update(PupilId.GetUserId());

        CompletionDate = DateTime.UtcNow;
        _sets.Clear();
        _sets.AddRange(sets);
        NumberOfExercises = sets.Count;
        Duration = sets.Sum(s => s.Time);
    }

#pragma warning disable CS8618
    private Execution()
    {
    }
#pragma warning restore CS8618
}
