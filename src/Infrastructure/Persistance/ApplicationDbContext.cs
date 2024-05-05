using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistance.Interceptors;
using Domain.Common.Models;
using Domain.Training;
using Domain.Part;
using Domain.Execution;
using Domain.Exercise;

namespace Infrastructure.Persistance;

public class ApplicationDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor) : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Training> Trainings { get; set; } = null!;
    public DbSet<Part> Parts { get; set; } = null!;
    public DbSet<Execution> Executions { get; set; } = null!;
    public DbSet<Exercise> Exercises { get; set; } = null!;
}
