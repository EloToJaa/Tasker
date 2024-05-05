using Domain.Common.Models;
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

    private Execution(ExecutionId id, TrainingId trainingId, Guid userId, Guid trainerId, DateTime dateToComplete) : base(id, trainerId)
    {
        TrainingId = trainingId;
        UserId = userId;
        DateToComplete = dateToComplete;
        CompletionDate = null;
    }

    public static Execution Create(TrainingId trainingId, Guid userId, Guid trainerId, DateTime dateToComplete)
    {
        return new Execution(ExecutionId.CreateUnique(), trainingId, userId, trainerId, dateToComplete);
    }

    public void Complete()
    {
        base.Update(UserId);

        CompletionDate = DateTime.UtcNow;
    }

#pragma warning disable CS8618
    private Execution()
    {
    }
#pragma warning restore CS8618
}
