using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Voting.Domain.Repositories;

namespace Voting.Infrastructure.Repositories
{
    public class VotingRepository : IVotingRepository
    {
        private readonly VotingContext _votingContext;

        public VotingRepository(VotingContext votingContext)
        {
            _votingContext = votingContext;
        }

        public async Task<Domain.Models.Voting> AddAsync(
            Domain.Models.Voting voting)
        {
            var savedVoting = _votingContext
                .AddAsync(voting)
                .Result
                .Entity;

            await _votingContext.SaveChangesAsync();

            return savedVoting;
        }

        public async Task<Domain.Models.Voting> GetByIdAsync(int id)
        {
            return await _votingContext.Votings
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.Id.Equals(id));
        }
    }
}
