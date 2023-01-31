using System.ComponentModel.DataAnnotations;

namespace Embaixadinha.Models.ViewModels.Player
{
    public class RegisterPlayerViewModel
    {
        [Required(ErrorMessage = "O Campo Name é obrigatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O Campo PlayerIp é obrigatorio")]
        public string PlayerIp { get; set; }
    }
}
