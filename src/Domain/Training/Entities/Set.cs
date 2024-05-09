using Domain.Common.Models;
using Domain.Exercise;

namespace Domain.Training.Entities;

public sealed class Set : Entity<SetId>
{
    public string Description { get; private set; }
    public int Repetitions { get; private set; }
    public int Time { get; private set; }
    public ExerciseId ExerciseId { get; private set; }

    private Set(SetId id, ExerciseId exerciseId, string description, int repetitions, int time) : base(id)
    {
        Description = description;
        Repetitions = repetitions;
        Time = time;
        ExerciseId = exerciseId;
    }

    public static Set Create(ExerciseId exerciseId, string description, int repetitions, int time)
    {
        return new Set(SetId.CreateUnique(), exerciseId, description, repetitions, time);
    }
}