using System.ComponentModel.DataAnnotations;

namespace RockPaperScissorsAPI.DTO.GameDTO
{
    public class MakeMoveDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Move is required.")]
        public string Move { get; set; }
    }
}
