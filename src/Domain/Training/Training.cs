using Domain.Common.Models;
using Domain.Training.Entities;

namespace Domain.Training;

public sealed class Training : AggregateRoot<TrainingId, Guid>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int NumberOfExercises { get; private set; }
    public int Duration { get; private set; }
    public IReadOnlyList<Set> Sets => _sets.AsReadOnly();
    private readonly List<Set> _sets = new();

    private Training(TrainingId id, string name, string description, Guid userId) : base(id, userId)
    {
        Id = id;
        Name = name;
        Description = description;

        NumberOfExercises = 0;
        Duration = 0;
    }

    public static Training Create(string name, string description, Guid userId)
    {
        return new Training(TrainingId.CreateUnique(), name, description, userId);
    }

    public void Update(string name, string description, Guid userId, List<Set> sets)
    {
        base.Update(userId);

        Name = name;
        Description = description;
        _sets.Clear();
        _sets.AddRange(sets);

        NumberOfExercises = 0;
        Duration = _sets.Sum(s => s.Time);
    }

#pragma warning disable CS8618
    private Training()
    {
    }
#pragma warning restore CS8618
}