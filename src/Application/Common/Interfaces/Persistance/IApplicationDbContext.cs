using Domain.Execution;
using Domain.Exercise;
using Domain.Part;
using Domain.Training;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Training> Trainings { get; set; }
    DbSet<Part> Parts { get; set; }
    DbSet<Execution> Executions { get; set; }
    DbSet<Exercise> Exercises { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}