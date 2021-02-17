using System.Threading.Tasks;
using Voting.Domain.Models;

namespace Voting.Domain.Repositories
{
    public interface IParticipantRepository
    {
        Task<VotingParticipant> AddAsync(VotingParticipant votingParticipant);
        Task<VotingParticipant> GetByIdAsync(int id);
    }
}
