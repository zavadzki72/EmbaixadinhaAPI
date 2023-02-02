using System.ComponentModel.DataAnnotations;

namespace Embaixadinha.Models.ViewModels.Player
{
    public class UpdatePlayerViewModel
    {
        [Required(ErrorMessage = "O Campo Name é obrigatorio")]
        public string Name { get; set; }
    }
}
