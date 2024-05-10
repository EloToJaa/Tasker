using Domain.Common.Models;
using Domain.ExerciseAggregate;

namespace Domain.ExecutionAggregate.Entities;

public sealed class ExecutionSet : Entity<ExecutionSetId>
{
    public string Description { get; private set; }
    public int Repetitions { get; private set; }
    public int Time { get; private set; }
    public ExerciseId ExerciseId { get; private set; }

    private ExecutionSet(ExecutionSetId id, ExerciseId exerciseId, string description, int repetitions, int time) : base(id)
    {
        Description = description;
        Repetitions = repetitions;
        Time = time;
        ExerciseId = exerciseId;
    }

    public static ExecutionSet Create(ExerciseId exerciseId, string description, int repetitions, int time)
    {
        return new ExecutionSet(ExecutionSetId.CreateUnique(), exerciseId, description, repetitions, time);
    }
}