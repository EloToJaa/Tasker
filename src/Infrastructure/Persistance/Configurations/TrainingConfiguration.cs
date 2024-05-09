using Domain.Exercise;
using Domain.Training;
using Domain.Training.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations;

public sealed class TrainingConfiguration : IEntityTypeConfiguration<Training>
{
    public void Configure(EntityTypeBuilder<Training> builder)
    {
        ConfigureTrainingTable(builder);
        ConfigureSetsTable(builder);
    }

    private void ConfigureSetsTable(EntityTypeBuilder<Training> builder)
    {
        builder.OwnsMany(t => t.Sets, sb =>
        {
            sb.ToTable("Sets");

            sb.WithOwner().HasForeignKey("TrainingId");

            sb.HasKey("Id", "TrainingId");

            sb.Property(s => s.Id)
                .HasColumnName("SetId")
                .HasConversion(
                    id => id.Value,
                    value => TrainingSetId.Create(value)
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

    private void ConfigureTrainingTable(EntityTypeBuilder<Training> builder)
    {
        builder.ToTable("Trainings");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id)
            .HasConversion(
                id => id.Value,
                value => TrainingId.Create(value)
            );

        builder.Property(t => t.Name)
            .HasMaxLength(200);
    }
}
