using Embaixadinha.Models.Entities;
using Embaixadinha.Models.ViewModels.Player;

namespace Embaixadinha.Models.Interfaces
{
    public interface IPlayerService
    {
        Task<ServiceResult<PlayerResponse>> Get(int id);
        Task<ServiceResult<PlayerResponse>> GetByIp(string ip);
        Task<ServiceResult<PlayerWithScoresResponse>> GetWithScores(int id);
        Task<ServiceResult<PlayerWithBestScoreResponse>> GetWithBestScore(int id);
        Task<ServiceResult<int>> Register(RegisterPlayerViewModel registerPlayerViewModel);
        Task<ServiceResult<int>> Update(int id, UpdatePlayerViewModel updatePlayerViewModel);
    }
}
