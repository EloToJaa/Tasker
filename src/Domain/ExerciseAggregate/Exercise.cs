using Domain.Common.Models;
using Domain.Common.ValueObjects;
using Domain.PartAggregate;

namespace Domain.ExerciseAggregate;

public sealed class Exercise : AggregateRoot<ExerciseId, Guid>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Image Photo { get; private set; }
    public PartId PartId { get; private set; }

    private Exercise(ExerciseId id, string name, string description, Image photo, PartId partId, UserId createdBy) : base(id, createdBy)
    {
        Id = id;
        Name = name;
        Description = description;
        Photo = photo;
        PartId = partId;
    }

    public static Exercise Create(string name, string description, Image photo, PartId partId, UserId createdBy)
    {
        return new Exercise(ExerciseId.CreateUnique(), name, description, photo, partId, createdBy);
    }

    public void Update(string name, string description, Image photo, PartId partId, UserId updatedBy)
    {
        base.Update(updatedBy);

        Name = name;
        Description = description;
        Photo = photo;
        PartId = partId;
    }

#pragma warning disable CS8618
    private Exercise()
    {
    }
#pragma warning restore CS8618
}