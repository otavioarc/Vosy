using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Voting.Domain.Models;
using Voting.Domain.Repositories;

namespace Voting.Infrastructure.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly VotingContext _votingContext;

        public ParticipantRepository(VotingContext votingContext)
        {
            _votingContext = votingContext;
        }

        public async Task<VotingParticipant> AddAsync(
            VotingParticipant votingParticipant)
        {
            var participant = _votingContext
                .AddAsync(votingParticipant)
                .Result
                .Entity;

            await _votingContext.SaveChangesAsync();

            return participant;
        }

        public Task<VotingParticipant> GetByIdAsync(int id)
        {
            return _votingContext.Participants
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id.Equals(id));
        }
    }
}
