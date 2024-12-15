using RockPaperScissorsAPI.Interfaces;

namespace RockPaperScissorsAPI.DTO.GameDTO
{
    public class ActiveGameDTO
    {
        public Guid GameId { get; set; }
        public string PlayerOne { get; set; }
        public string PlayerTwo { get; set; }
    }
}
