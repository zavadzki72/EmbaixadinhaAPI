using Embaixadinha.Data;
using Embaixadinha.Models;
using Embaixadinha.Models.Entities;
using Embaixadinha.Models.Interfaces;
using Embaixadinha.Models.ViewModels.Player;
using Microsoft.EntityFrameworkCore;

namespace Embaixadinha.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly ApplicationContext _applicationContext;

        public PlayerService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<ServiceResult<Player>> Get(int id)
        {
            var player = await _applicationContext.Set<Player>()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (player == null)
            {
                var notification = new Notification("PLAYER_NOT_FOUND", $"Não achamos um jogador com o ID {id} cadastrado.");
                return ServiceResult<Player>.Error(new List<Notification> { notification });
            }

            return ServiceResult<Player>.Ok(player, new List<Notification>());
        }

        public async Task<ServiceResult<Player>> GetWithScores(int id)
        {
            var player = await _applicationContext.Set<Player>()
                .Include(x => x.Scores)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (player == null)
            {
                var notification = new Notification("PLAYER_NOT_FOUND", $"Não achamos um jogador com o ID {id} cadastrado.");
                return ServiceResult<Player>.Error(new List<Notification> { notification });
            }

            return ServiceResult<Player>.Ok(player, new List<Notification>());
        }

        public async Task<ServiceResult<PlayerWithBestScoreResponse>> GetWithBestScore(int id)
        {
            var player = await _applicationContext.Set<Player>()
                .Include(x => x.Scores)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (player == null)
            {
                var notification = new Notification("PLAYER_NOT_FOUND", $"Não achamos um jogador com o ID {id} cadastrado.");
                return ServiceResult<PlayerWithBestScoreResponse>.Error(new List<Notification> { notification });
            }

            return ServiceResult<PlayerWithBestScoreResponse>.Ok(player.GetPlayerWithBestScore(), new List<Notification>());
        }

        public async Task<ServiceResult<int>> Register(RegisterPlayerViewModel registerPlayerViewModel)
        {
            var existsInDb = await _applicationContext.Set<Player>().FirstOrDefaultAsync(x => x.Name.Equals(registerPlayerViewModel.Name));

            if(existsInDb != null) {
                var notification = new Notification("PLAYER_ALREADY_EXISTS", $"Já existe um jogador com o nome {registerPlayerViewModel.Name} cadastrado. Use outro nome!");
                return ServiceResult<int>.Error(new List<Notification> { notification });
            }

            var player = new Player { Name = registerPlayerViewModel.Name };
            
            var createdPlayer = await _applicationContext.AddAsync(player);
            await _applicationContext.SaveChangesAsync();

            return ServiceResult<int>.Created($"player/{createdPlayer.Entity.Id}", new List<Notification>());
        }
    }
}
