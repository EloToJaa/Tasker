using Domain.ExecutionAggregate;
using Domain.ExecutionAggregate.Entities;
using Domain.ExerciseAggregate;
using Domain.PupilAggregate;
using Domain.TrainerAggregate;
using Domain.TrainingAggregate;
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
            sb.ToTable("execution_sets");

            sb.WithOwner().HasForeignKey("execution_id");

            sb.HasKey(nameof(Execution.Id), "execution_id");

            sb.Property(s => s.Id)
                .HasColumnName("execution_set_id")
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
        builder.ToTable("execution");

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