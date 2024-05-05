using Domain.Common.Models;

namespace Domain.Training;

public sealed class TrainingId : AggregateRootId<Guid>
{
  private TrainingId(Guid value) : base(value)
  {
  }

  public static TrainingId CreateUnique()
  {
    return new TrainingId(Guid.NewGuid());
  }

  public static TrainingId Create(Guid value)
  {
    return new TrainingId(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}