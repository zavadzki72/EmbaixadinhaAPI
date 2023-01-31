using Embaixadinha.Data;
using Embaixadinha.Models;
using Embaixadinha.Models.Entities;
using Embaixadinha.Models.Interfaces;
using Embaixadinha.Models.ViewModels.Player;
using Embaixadinha.Models.ViewModels.Score;
using Microsoft.EntityFrameworkCore;

namespace Embaixadinha.Services
{
    public class ScoreService : IScoreService
    {
        private readonly ApplicationContext _applicationContext;

        public ScoreService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<ServiceResult<List<PlayerWithBestScoreResponse>>> GetBestPlayers()
        {
            var query = (
                from s in _applicationContext.Set<Score>().Include(x => x.Player)
                orderby s.Value descending, s.Created_At descending
                select new PlayerWithBestScoreResponse
                {
                    BestScoreId = s.Id,
                    PlayerId = s.PlayerId,
                    BestScore = s.Value,
                    PlayerName = s.Player.Name
                }
            );

            var result = await query.Take(10).ToListAsync();

            return ServiceResult<List<PlayerWithBestScoreResponse>>.Ok(result, new List<Notification>());
        }

        public async Task<ServiceResult> Register(RegisterScoreViewModel registerScoreViewModel)
        {
            var existsPlayerInDb = await _applicationContext.Set<Player>().FirstOrDefaultAsync(x => x.Id == registerScoreViewModel.PlayerId);

            if (existsPlayerInDb == null)
            {
                var notification = new Notification("PLAYER_NOT_FOUND", $"Não achamos um jogador com o ID {registerScoreViewModel.PlayerId} cadastrado.");
                return ServiceResult<PlayerWithBestScoreResponse>.Error(new List<Notification> { notification });
            }

            var score = new Score(registerScoreViewModel.Value, registerScoreViewModel.PlayerId);

            await _applicationContext.AddAsync(score);
            await _applicationContext.SaveChangesAsync();

            return ServiceResult.OkEmpty(new List<Notification>());
        }
    }
}
