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

        public async Task<ServiceResult<PlayerResponse>> Get(int id)
        {
            var player = await _applicationContext.Set<Player>()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (player == null)
            {
                var notification = new Notification("PLAYER_NOT_FOUND", $"Não achamos um jogador com o ID {id} cadastrado.");
                return ServiceResult<PlayerResponse>.Error(new List<Notification> { notification });
            }

            return ServiceResult<PlayerResponse>.Ok(player.GetPlayer(), new List<Notification>());
        }

        public async Task<ServiceResult<PlayerResponse>> GetByIp(string ip)
        {
            var player = await _applicationContext.Set<Player>()
                .FirstOrDefaultAsync(x => x.PlayerIp.Equals(ip));

            if (player == null)
            {
                var notification = new Notification("PLAYER_NOT_FOUND", $"Não achamos um jogador com o IP {ip} cadastrado.");
                return ServiceResult<PlayerResponse>.Error(new List<Notification> { notification });
            }

            return ServiceResult<PlayerResponse>.Ok(player.GetPlayer(), new List<Notification>());
        }

        public async Task<ServiceResult<PlayerWithScoresResponse>> GetWithScores(int id)
        {
            var player = await _applicationContext.Set<Player>()
                .Include(x => x.Scores)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (player == null)
            {
                var notification = new Notification("PLAYER_NOT_FOUND", $"Não achamos um jogador com o ID {id} cadastrado.");
                return ServiceResult<PlayerWithScoresResponse>.Error(new List<Notification> { notification });
            }

            return ServiceResult<PlayerWithScoresResponse>.Ok(player.GetPlayerWithScores(), new List<Notification>());
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

            var player = new Player(registerPlayerViewModel.Name, registerPlayerViewModel.PlayerIp);
            
            var createdPlayer = await _applicationContext.AddAsync(player);
            await _applicationContext.SaveChangesAsync();

            return ServiceResult<int>.Created($"player/{createdPlayer.Entity.Id}", new List<Notification>());
        }

        public async Task<ServiceResult<int>> Update(int id, UpdatePlayerViewModel updatePlayerViewModel)
        {
            var player = await _applicationContext.Set<Player>().FirstOrDefaultAsync(x => x.Id == id);

            if (player == null)
            {
                var notification = new Notification("PLAYER_NOT_FOUND", $"Não achamos um jogador com o ID {id} cadastrado.");
                return ServiceResult<int>.Error(new List<Notification> { notification });
            }

            player.Name = updatePlayerViewModel.Name;
            player.Updated_At = DateTime.Now;

            _applicationContext.Update(player);
            await _applicationContext.SaveChangesAsync();

            return ServiceResult<int>.Created($"player/{id}", new List<Notification>());
        }
    }
}
