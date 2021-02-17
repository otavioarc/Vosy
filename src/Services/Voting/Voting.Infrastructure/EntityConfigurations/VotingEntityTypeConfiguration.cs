using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Voting.Infrastructure.EntityConfigurations
{
    public class VotingEntityTypeConfiguration
        : IEntityTypeConfiguration<Domain.Models.Voting>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Voting> builder)
        {
            builder.ToTable("votings");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id).UseHiLo();

            builder.HasIndex(v => new { v.EndDate, v.Status });

            builder.Property(v => v.Title)
                .HasMaxLength(50);

            builder.Property(v => v.CreatedDate)
                .HasColumnType<DateTime>("timestamp without time zone")
                .ValueGeneratedOnAdd();

            builder.Property(v => v.StartDate)
                .HasColumnType<DateTime>("timestamp without time zone");

            builder.Property(v => v.EndDate)
                .HasColumnType<DateTime>("timestamp without time zone");

            builder.Ignore(v => v.VotesQuantity);

            builder.OwnsMany(v => v.Participants);
        }
    }
}
