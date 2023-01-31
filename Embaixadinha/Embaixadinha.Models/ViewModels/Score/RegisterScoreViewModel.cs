using System.ComponentModel.DataAnnotations;

namespace Embaixadinha.Models.ViewModels.Score
{
    public class RegisterScoreViewModel
    {
        [Required(ErrorMessage = "O Campo PlayerId é obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "O Valor do PlayerId não é valido")]
        public int PlayerId { get; set; }
        
        [Required(ErrorMessage = "O Campo value é obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "O Valor do score não é valido")]
        public int Value { get; set; }
    }
}
