using Embaixadinha.Models.ViewModels.Player;
using Embaixadinha.Models.ViewModels.Score;

namespace Embaixadinha.Models.Interfaces
{
    public interface IScoreService
    {
        Task<ServiceResult> Register(RegisterScoreViewModel registerScoreViewModel);
        Task<ServiceResult<List<PlayerWithBestScoreResponse>>> GetBestPlayers();
    }
}
