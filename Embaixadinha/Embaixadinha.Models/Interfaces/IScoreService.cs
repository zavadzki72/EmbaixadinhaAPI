using Embaixadinha.Models.ViewModels.Score;

namespace Embaixadinha.Models.Interfaces
{
    public interface IScoreService
    {
        Task<ServiceResult> Register(RegisterScoreViewModel registerScoreViewModel);
    }
}
