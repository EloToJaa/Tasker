using Domain.ExerciseAggregate;
using Domain.PartAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations;

public sealed class PartConfiguration : IEntityTypeConfiguration<Part>
{
    public void Configure(EntityTypeBuilder<Part> builder)
    {
        ConfigurePartTable(builder);
        ConfigurePartExerciseIdsTable(builder);
    }

    private void ConfigurePartExerciseIdsTable(EntityTypeBuilder<Part> builder)
    {
        builder.OwnsMany(p => p.ExerciseIds, eb =>
        {
            eb.ToTable("part_exercise_ids");
            eb.OwnedEntityType.RemoveDiscriminatorValue();

            eb.WithOwner().HasForeignKey("part_id");

            eb.HasKey(nameof(Part.Id));

            eb.Property(e => e.Value)
                .HasColumnName("exercise_id")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Part.ExerciseIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigurePartTable(EntityTypeBuilder<Part> builder)
    {
        builder.ToTable("parts");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasConversion(
                id => id.Value,
                value => PartId.Create(value)
            );

        builder.Property(e => e.Name)
            .HasMaxLength(200);
    }
}