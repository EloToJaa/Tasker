using Domain.Common.ValueObjects;
using Domain.Pupil;
using Domain.Trainer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations;

public sealed class PupilConfiguration : IEntityTypeConfiguration<Pupil>
{
    public void Configure(EntityTypeBuilder<Pupil> builder)
    {
        ConfigurePupilTable(builder);
    }

    private void ConfigurePupilTable(EntityTypeBuilder<Pupil> builder)
    {
        builder.ToTable("Pupils");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
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