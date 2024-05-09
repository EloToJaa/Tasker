using Domain.Common.Models;
using Domain.Common.ValueObjects;
using Domain.Exercise;

namespace Domain.Part;

public sealed class Part : AggregateRoot<PartId, Guid>
{
    private List<ExerciseId> _exerciseIds = new();

    public string Name { get; private set; }
    public string Description { get; private set; }
    public IReadOnlyList<ExerciseId> ExerciseIds => _exerciseIds.AsReadOnly();

    private Part(PartId id, string name, string description, UserId createdBy) : base(id, createdBy)
    {
        Name = name;
        Description = description;
    }

    public static Part Create(string name, string description, UserId createdBy)
    {
        return new Part(PartId.CreateUnique(), name, description, createdBy);
    }

    public void Update(string name, string description, UserId updatedBy)
    {
        base.Update(updatedBy);

        Name = name;
        Description = description;
    }

#pragma warning disable CS8618
    private Part()
    {
    }
#pragma warning restore CS8618
}