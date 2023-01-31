using System.ComponentModel.DataAnnotations;

namespace Embaixadinha.Models.ViewModels.Score
{
    public class RegisterScoreViewModel
    {
        [Required]
        public int PlayerId { get; set; }
        
        [Required]
        public int Value { get; set; }
    }
}
