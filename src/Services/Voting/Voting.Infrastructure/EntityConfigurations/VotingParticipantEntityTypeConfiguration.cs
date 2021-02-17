using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Voting.Domain.Models;

namespace Voting.Infrastructure.EntityConfigurations
{
    public class VotingParticipantEntityTypeConfiguration
        : IEntityTypeConfiguration<VotingParticipant>
    {
        public void Configure(EntityTypeBuilder<VotingParticipant> builder)
        {
            builder.ToTable("participants");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).UseHiLo();

            builder.HasIndex(p => new { p.Id, p.VotingId });

            builder.Property(p => p.Name)
                .HasMaxLength(50);

            builder.Ignore(p => p.VotesQuantity);

            builder.Ignore(p => p.VotesPercentage);

            builder.Property(p => p.CreatedDate)
                .HasColumnType<DateTime>("timestamp without time zone")
                .ValueGeneratedOnAdd();
        }
    }
}
