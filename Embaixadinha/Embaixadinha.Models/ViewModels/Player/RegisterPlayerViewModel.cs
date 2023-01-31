using System.ComponentModel.DataAnnotations;

namespace Embaixadinha.Models.ViewModels.Player
{
    public class RegisterPlayerViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
