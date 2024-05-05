using Domain.Common.Models;
using Domain.Common.ValueObjects;
using Domain.Part;

namespace Domain.Exercise;

public sealed class Exercise : AggregateRoot<ExerciseId, Guid>
{
  public string Name { get; private set; }
  public string Description { get; private set; }
  public Image Photo { get; private set; }
  public PartId PartId { get; private set; }

  private Exercise(ExerciseId id, string name, string description, Image photo, PartId partId, Guid userId) : base(id, userId)
  {
    Id = id;
    Name = name;
    Description = description;
    Photo = photo;
    PartId = partId;
  }

  public static Exercise Create(string name, string description, Image photo, PartId partId, Guid userId)
  {
    return new Exercise(ExerciseId.CreateUnique(), name, description, photo, partId, userId);
  }

  public void Update(string name, string description, Image photo, PartId partId, Guid userId)
  {
    base.Update(userId);

    Name = name;
    Description = description;
    Photo = photo;
    PartId = partId;
  }
}