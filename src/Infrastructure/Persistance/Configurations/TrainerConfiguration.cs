using Domain.Common.ValueObjects;
using Domain.TrainerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations;

public sealed class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
{
    public void Configure(EntityTypeBuilder<Trainer> builder)
    {
        ConfigureTrainerTable(builder);
        ConfigureTrainerPupilIdsTable(builder);
    }

    private void ConfigureTrainerTable(EntityTypeBuilder<Trainer> builder)
    {
        builder.ToTable("trainers");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasConversion(
                id => id.Value,
                value => TrainerId.Create(value)
            );
    }

    private void ConfigureTrainerPupilIdsTable(EntityTypeBuilder<Trainer> builder)
    {
        builder.OwnsMany(p => p.PupilIds, eb =>
        {
            eb.ToTable("trainer_pupil_ids");
            eb.OwnedEntityType.RemoveDiscriminatorValue();

            eb.WithOwner().HasForeignKey("trainer_id");

            eb.HasKey(nameof(Trainer.Id));

            eb.Property(e => e.Value)
                .HasColumnName("pupil_id")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Trainer.PupilIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
