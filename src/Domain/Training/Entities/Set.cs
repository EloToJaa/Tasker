using Domain.Common.Models;
using Domain.Exercise;

namespace Domain.Training.Entities;

public sealed class Set : Entity<SetId>
{
    public string Description { get; private set; }
    public int Repetitions { get; private set; }
    public int Time { get; private set; }
    public IReadOnlyList<ExerciseId> ExerciseIds => _exerciseIds.AsReadOnly();

    private readonly List<ExerciseId> _exerciseIds = new();

    private Set(SetId id, string description, int repetitions, int time) : base(id)
    {
        Description = description;
        Repetitions = repetitions;
        Time = time;
    }

    public static Set Create(string description, int repetitions, int time)
    {
        return new Set(SetId.CreateUnique(), description, repetitions, time);
    }

    public void AddExercise(ExerciseId exerciseId)
    {
        // _exerciseIds.Add(exerciseId);
    }

    public void RemoveExercise(ExerciseId exerciseId)
    {
        // _exerciseIds.Remove(exerciseId);
    }
}