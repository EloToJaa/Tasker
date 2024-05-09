using Domain.Execution;
using Domain.Execution.Entities;
using Domain.Exercise;
using Domain.Pupil;
using Domain.Trainer;
using Domain.Training;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations;

public sealed class ExecutionConfiguration : IEntityTypeConfiguration<Execution>
{
    public void Configure(EntityTypeBuilder<Execution> builder)
    {
        ConfigureExecutionTable(builder);
        ConfigureSetsTable(builder);
    }

    private void ConfigureSetsTable(EntityTypeBuilder<Execution> builder)
    {
        builder.OwnsMany(t => t.Sets, sb =>
        {
            sb.ToTable("ExecutionSets");

            sb.WithOwner().HasForeignKey("ExecutionId");

            sb.HasKey("Id", "ExecutionId");

            sb.Property(s => s.Id)
                .HasColumnName("ExecutionSetId")
                .HasConversion(
                    id => id.Value,
                    value => ExecutionSetId.Create(value)
                );

            sb.Property(s => s.ExerciseId)
                .HasConversion(
                    id => id.Value,
                    value => ExerciseId.Create(value)
                );
        });

        builder.Metadata.FindNavigation(nameof(Training.Sets))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
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

        builder.Property(e => e.PupilId)
            .HasConversion(
                id => id.Value,
                value => PupilId.Create(value)
            );

        builder.Property(e => e.TrainerId)
            .HasConversion(
                id => id.Value,
                value => TrainerId.Create(value)
            );
    }
}