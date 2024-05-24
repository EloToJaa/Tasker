using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Domain.TrainingAggregate.Training> Trainings { get; set; }
    DbSet<Domain.PartAggregate.Part> Parts { get; set; }
    DbSet<Domain.ExecutionAggregate.Execution> Executions { get; set; }
    DbSet<Domain.ExerciseAggregate.Exercise> Exercises { get; set; }
    DbSet<Domain.TrainerAggregate.Trainer> Trainers { get; set; }
    DbSet<Domain.PupilAggregate.Pupil> Pupils { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}