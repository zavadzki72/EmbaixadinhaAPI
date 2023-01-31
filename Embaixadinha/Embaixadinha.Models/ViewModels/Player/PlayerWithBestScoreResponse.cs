namespace Embaixadinha.Models.ViewModels.Player
{
    public class PlayerWithBestScoreResponse
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int? BestScoreId { get; set; }
        public int BestScore { get; set; }
    }
}
