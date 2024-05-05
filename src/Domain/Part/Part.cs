using Domain.Common.Models;
using Domain.Exercise;

namespace Domain.Part;

public sealed class Part : AggregateRoot<PartId, Guid>
{
  private List<ExerciseId> _exerciseIds = new();

  public string Name { get; private set; }
  public string Description { get; private set; }
  public IReadOnlyList<ExerciseId> ExerciseIds => _exerciseIds.AsReadOnly();

  private Part(PartId id, string name, string description, Guid userId) : base(id, userId)
  {
    Name = name;
    Description = description;
  }

  public static Part Create(string name, string description, Guid userId)
  {
    return new Part(PartId.CreateUnique(), name, description, userId);
  }

  public void Update(string name, string description, Guid userId)
  {
    base.Update(userId);

    Name = name;
    Description = description;
  }
}