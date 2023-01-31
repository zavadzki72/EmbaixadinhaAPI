using Embaixadinha.Models.Entities;
using Embaixadinha.Models.ViewModels.Player;

namespace Embaixadinha.Models.Interfaces
{
    public interface IPlayerService
    {
        Task<ServiceResult<int>> Register(RegisterPlayerViewModel registerPlayerViewModel);
        Task<ServiceResult<Player>> Get(int id);
        Task<ServiceResult<Player>> GetWithScores(int id);
        Task<ServiceResult<PlayerWithBestScoreResponse>> GetWithBestScore(int id);
    }
}
