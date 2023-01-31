using Embaixadinha.Data;
using Embaixadinha.Models;
using Embaixadinha.Models.Entities;
using Embaixadinha.Models.Interfaces;
using Embaixadinha.Models.ViewModels.Score;

namespace Embaixadinha.Services
{
    public class ScoreService : IScoreService
    {
        private readonly ApplicationContext _applicationContext;

        public ScoreService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<ServiceResult> Register(RegisterScoreViewModel registerScoreViewModel)
        {
            var score = new Score { PlayerId = registerScoreViewModel.PlayerId, Value = registerScoreViewModel.Value };

            await _applicationContext.AddAsync(score);
            await _applicationContext.SaveChangesAsync();

            return ServiceResult.OkEmpty(new List<Notification>());
        }
    }
}
