using Domain.Execution;
using Domain.Training;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations;

public sealed class ExecutionConfiguration : IEntityTypeConfiguration<Execution>
{
    public void Configure(EntityTypeBuilder<Execution> builder)
    {
        ConfigureExecutionTable(builder);
    }

    private void ConfigureExecutionTable(EntityTypeBuilder<Execution> builder)
    {
        builder.ToTable("Execution");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasConversion(
                id => id.Value,
                value => ExecutionId.Create(value)
            );

        builder.Property(e => e.TrainingId)
            .HasConversion(
                id => id.Value,
                value => TrainingId.Create(value)
            );
    }
}