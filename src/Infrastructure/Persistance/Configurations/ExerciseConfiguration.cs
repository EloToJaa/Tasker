using Domain.ExerciseAggregate;
using Domain.PartAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations;

public sealed class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        ConfigureExerciseTable(builder);
    }

    private void ConfigureExerciseTable(EntityTypeBuilder<Exercise> builder)
    {
        builder.ToTable("exercises");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasConversion(
                id => id.Value,
                value => ExerciseId.Create(value)
            );

        builder.Property(e => e.PartId)
            .HasConversion(
                id => id.Value,
                value => PartId.Create(value)
            );

        builder.Property(e => e.Name)
            .HasMaxLength(200);

        builder.OwnsOne(e => e.Photo);
    }
}