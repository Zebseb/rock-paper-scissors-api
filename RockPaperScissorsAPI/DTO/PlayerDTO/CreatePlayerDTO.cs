using System.ComponentModel.DataAnnotations;

namespace RockPaperScissorsAPI.DTO.PlayerDTO
{
    public class CreatePlayerDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
    }
}
