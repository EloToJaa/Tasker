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
        builder.ToTable("Trainers");

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
            eb.ToTable("TrainerPupilIds");

            eb.WithOwner().HasForeignKey("TrainerId");

            eb.HasKey("Id");

            eb.Property(e => e.Value)
                .HasColumnName("PupilId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Trainer.PupilIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
