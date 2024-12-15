using RockPaperScissorsAPI.DTO.PlayerDTO;
using RockPaperScissorsAPI.Entities;

namespace RockPaperScissorsAPI.Interfaces
{
    public interface IPlayerManager
	{
		Player CreatePlayer(CreatePlayerDTO createPlayerDTO);
	}
}
