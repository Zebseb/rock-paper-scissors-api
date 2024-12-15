using RockPaperScissorsAPI.DTO.PlayerDTO;
using RockPaperScissorsAPI.Entities;
using RockPaperScissorsAPI.Interfaces;

namespace RockPaperScissorsAPI.Services.Managers
{
    public class PlayerManager : IPlayerManager
    {
        private readonly Dictionary<string, Player> _players = new Dictionary<string, Player>();

        public Player CreatePlayer(CreatePlayerDTO createPlayerDTO)
        {
            if (createPlayerDTO == null)
            {
                throw new ArgumentNullException($"{createPlayerDTO} cannot be null.");
            }

            if (_players.ContainsKey(createPlayerDTO.Name))
            {
                throw new ArgumentException($"Player name: {createPlayerDTO.Name} is already taken, please choose another one.");
            }

            Player newPlayer = new()
            {
                Name = createPlayerDTO.Name,
            };

            _players[newPlayer.Name] = newPlayer;
            return newPlayer;
        }
    }
}
