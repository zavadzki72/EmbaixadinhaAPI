using Embaixadinha.Models.Interfaces;
using Embaixadinha.Models.ViewModels.Player;
using Microsoft.AspNetCore.Mvc;

namespace Embaixadinha.API.Controllers
{
    [ApiController]
    [Route("player")]
    public class PlayerController : BaseController
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterPlayerViewModel registerPlayerViewModel)
        {
            var result = await _playerService.Register(registerPlayerViewModel);

            return ProcessResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var result = await _playerService.Get(id);

            return ProcessResponse(result);
        }

        [HttpGet("ip/{ip}")]
        public async Task<IActionResult> GetByIp([FromRoute] string ip)
        {
            var result = await _playerService.GetByIp(ip);

            return ProcessResponse(result);
        }

        [HttpGet("{id}/scores")]
        public async Task<IActionResult> GetWithScores([FromRoute] int id)
        {
            var result = await _playerService.GetWithScores(id);

            return ProcessResponse(result);
        }

        [HttpGet("{id}/best-score")]
        public async Task<IActionResult> GetWithBestScore([FromRoute] int id)
        {
            var result = await _playerService.GetWithBestScore(id);

            return ProcessResponse(result);
        }
    }
}
