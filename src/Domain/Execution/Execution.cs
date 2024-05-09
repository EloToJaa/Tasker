using Domain.Common.Models;
using Domain.Common.ValueObjects;
using Domain.Execution.Entities;
using Domain.Training;

namespace Domain.Execution;

public sealed class Execution : AggregateRoot<ExecutionId, Guid>
{
    public TrainingId TrainingId { get; private set; }
    public UserId PupilId { get; private set; }
    public UserId TrainerId => CreatedBy;
    public DateTime DateToComplete { get; private set; }
    public DateTime? CompletionDate { get; private set; }
    public bool Completed => CompletionDate.HasValue;
    public int NumberOfExercises { get; private set; }
    public int Duration { get; private set; }
    public IReadOnlyList<ExecutionSet> Sets => _sets.AsReadOnly();
    private readonly List<ExecutionSet> _sets = new();

    private Execution(ExecutionId id, TrainingId trainingId, UserId createdBy, UserId trainerId, DateTime dateToComplete, List<ExecutionSet> sets) : base(id, trainerId)
    {
        TrainingId = trainingId;
        PupilId = createdBy;
        DateToComplete = dateToComplete;
        CompletionDate = null;

        _sets.AddRange(sets);
        NumberOfExercises = sets.Count;
        Duration = sets.Sum(s => s.Time);
    }

    public static Execution Create(TrainingId trainingId, UserId createdBy, UserId trainerId, DateTime dateToComplete, List<ExecutionSet> sets)
    {
        return new Execution(ExecutionId.CreateUnique(), trainingId, createdBy, trainerId, dateToComplete, sets);
    }

    public void Complete(List<ExecutionSet> sets)
    {
        base.Update(PupilId);

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
