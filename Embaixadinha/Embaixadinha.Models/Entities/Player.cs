using Embaixadinha.Models.ViewModels.Player;

namespace Embaixadinha.Models.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }

        public List<Score> Scores { get; set; }

        public PlayerWithBestScoreResponse GetPlayerWithBestScore()
        {
            var bestScore = Scores.OrderByDescending(x => x.Value).FirstOrDefault();

            return new PlayerWithBestScoreResponse
            {
                PlayerId = Id,
                PlayerName = Name,
                BestScoreId = bestScore?.Id,
                BestScore = bestScore != null ? bestScore.Value : 0
            };
        }
    }
}
