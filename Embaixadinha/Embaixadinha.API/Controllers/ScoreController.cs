using Embaixadinha.Models.Interfaces;
using Embaixadinha.Models.ViewModels.Score;
using Microsoft.AspNetCore.Mvc;

namespace Embaixadinha.API.Controllers
{
    [ApiController]
    [Route("score")]
    public class ScoreController : BaseController
    {
        private readonly IScoreService _scoreService;

        public ScoreController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterScoreViewModel registerScoreViewModel)
        {
            var result = await _scoreService.Register(registerScoreViewModel);

            return ProcessResponse(result);
        }
    }
}
