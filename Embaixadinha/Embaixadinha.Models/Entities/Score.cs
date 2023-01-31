namespace Embaixadinha.Models.Entities
{
    public class Score : BaseEntity
    {
        public int Value { get; set; }
        public int PlayerId { get; set; }
        
        public virtual Player Player { get; set; }
    }
}
