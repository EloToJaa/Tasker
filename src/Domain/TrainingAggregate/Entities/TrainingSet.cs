using Domain.Common.Models;
using Domain.ExerciseAggregate;

namespace Domain.TrainingAggregate.Entities;

public sealed class TrainingSet : Entity<TrainingSetId>
{
    public string Description { get; private set; }
    public int Repetitions { get; private set; }
    public int Time { get; private set; }
    public ExerciseId ExerciseId { get; private set; }

    private TrainingSet(TrainingSetId id, ExerciseId exerciseId, string description, int repetitions, int time) : base(id)
    {
        Description = description;
        Repetitions = repetitions;
        Time = time;
        ExerciseId = exerciseId;
    }

    public static TrainingSet Create(ExerciseId exerciseId, string description, int repetitions, int time)
    {
        return new TrainingSet(TrainingSetId.CreateUnique(), exerciseId, description, repetitions, time);
    }
}