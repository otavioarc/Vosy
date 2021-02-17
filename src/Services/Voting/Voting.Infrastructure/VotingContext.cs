using Microsoft.EntityFrameworkCore;
using Voting.Infrastructure.EntityConfigurations;

namespace Voting.Infrastructure
{
    public class VotingContext : DbContext
    {
        public DbSet<Domain.Models.Voting> Votings { get; set; }
        public DbSet<Domain.Models.VotingParticipant> Participants { get; set; }

        public VotingContext(DbContextOptions<VotingContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VotingEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(
                new VotingParticipantEntityTypeConfiguration());
        }
    }
}
