using Domain.Common.Models;
using Domain.Execution.Entities;
using Domain.Training;

namespace Domain.Execution;

public sealed class Execution : AggregateRoot<ExecutionId, Guid>
{
    public TrainingId TrainingId { get; private set; }
    public Guid UserId { get; private set; }
    public Guid TrainerId => CreatedBy;
    public DateTime DateToComplete { get; private set; }
    public DateTime? CompletionDate { get; private set; }
    public bool Completed => CompletionDate.HasValue;
    public int NumberOfExercises { get; private set; }
    public int Duration { get; private set; }
    public IReadOnlyList<ExecutionSet> Sets => _sets.AsReadOnly();
    private readonly List<ExecutionSet> _sets = new();

    private Execution(ExecutionId id, TrainingId trainingId, Guid userId, Guid trainerId, DateTime dateToComplete, List<ExecutionSet> sets) : base(id, trainerId)
    {
        TrainingId = trainingId;
        UserId = userId;
        DateToComplete = dateToComplete;
        CompletionDate = null;

        _sets.AddRange(sets);
        NumberOfExercises = sets.Count;
        Duration = sets.Sum(s => s.Time);
    }

    public static Execution Create(TrainingId trainingId, Guid userId, Guid trainerId, DateTime dateToComplete, List<ExecutionSet> sets)
    {
        return new Execution(ExecutionId.CreateUnique(), trainingId, userId, trainerId, dateToComplete, sets);
    }

    public void Complete(List<ExecutionSet> sets)
    {
        base.Update(UserId);

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
