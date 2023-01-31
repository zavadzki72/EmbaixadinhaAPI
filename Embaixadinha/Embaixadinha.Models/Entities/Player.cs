namespace Embaixadinha.Models.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }

        public List<Score> Scores { get; set; }
    }
}
