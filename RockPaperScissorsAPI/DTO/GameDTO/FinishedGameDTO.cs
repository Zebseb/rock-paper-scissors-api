using RockPaperScissorsAPI.Entities;
using RockPaperScissorsAPI.Interfaces;

namespace RockPaperScissorsAPI.DTO.GameDTO
{
    public class FinishedGameDTO
    {
        public Guid GameId { get; set; }
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        public string Result { get; set; }
    }
}
