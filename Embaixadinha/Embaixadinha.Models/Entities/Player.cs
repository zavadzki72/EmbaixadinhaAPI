using Embaixadinha.Models.ViewModels.Player;
using Embaixadinha.Models.ViewModels.Score;

namespace Embaixadinha.Models.Entities
{
    public class Player : BaseEntity
    {
        public Player(string name, string playerIp)
        {
            Name = name;
            PlayerIp = playerIp;

            Created_At = DateTime.Now;
            Updated_At = DateTime.Now;
        }

        public string Name { get; set; }
        public string PlayerIp { get; set; }

        public List<Score> Scores { get; set; }

        public PlayerResponse GetPlayer()
        {
            return new PlayerResponse
            {
                Id = Id,
                Name = Name
            };
        }

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

        public PlayerWithScoresResponse GetPlayerWithScores()
        {
            var scores = Scores.Select(x => new ScoreResponse { Value = x.Value }).ToList();

            return new PlayerWithScoresResponse
            {
                PlayerId = Id,
                PlayerName = Name,
                Scores = scores
            };
        }
    }
}
