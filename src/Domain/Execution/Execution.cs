// ## Execution

// ```csharp
// class Execution {
//   Execution Create(Guid trainingId, Guid userId, Guid trainerId, DateTime dateToComplete);
//   void Complete();
// }
// ```

// ```json
// {
//   "Id": "00000000-0000-0000-0000-000000000000",
//   "TrainingId": "00000000-0000-0000-0000-000000000000",
//   "UserId": "00000000-0000-0000-0000-000000000000",
//   "TrainerId": "00000000-0000-0000-0000-000000000000",
//   "DateToComplete": "2021-01-01T00:00:00",
//   "CompletionDate": "2023-01-01T00:00:00",
//   "Completed": true
// }
// ```

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
}