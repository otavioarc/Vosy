using System.Threading.Tasks;

namespace Voting.Domain.Repositories
{
    public interface IVotingRepository
    {
        Task<Models.Voting> AddAsync(Models.Voting voting);
        Task<Models.Voting> GetByIdAsync(int id);
    }
}