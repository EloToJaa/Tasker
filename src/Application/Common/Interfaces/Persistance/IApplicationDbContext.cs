using Domain.ExecutionAggregate;
using Domain.ExerciseAggregate;
using Domain.PartAggregate;
using Domain.PupilAggregate;
using Domain.TrainerAggregate;
using Domain.TrainingAggregate;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Training> Trainings { get; set; }
    DbSet<Part> Parts { get; set; }
    DbSet<Execution> Executions { get; set; }
    DbSet<Exercise> Exercises { get; set; }
    DbSet<Trainer> Trainers { get; set; }
    DbSet<Pupil> Pupils { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}