using Embaixadinha.Models.ViewModels.Score;

namespace Embaixadinha.Models.ViewModels.Player
{
    public class PlayerWithScoresResponse
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public List<ScoreResponse> Scores { get; set; }
    }
}
