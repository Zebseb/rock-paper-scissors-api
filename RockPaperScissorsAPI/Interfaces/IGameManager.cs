using RockPaperScissorsAPI.DTO.GameDTO;
using RockPaperScissorsAPI.DTO.PlayerDTO;
using RockPaperScissorsAPI.Entities;

namespace RockPaperScissorsAPI.Interfaces
{
    public interface IGameManager
	{
		GameStatusDTO GetGameStatus(Guid gameId);
		FinishedGameDTO GetGameResult(Guid gameId);
		NewGameDTO CreateGame(CreatePlayerDTO createPlayerDTO);
		ActiveGameDTO JoinGame(Guid gameId, Player newPlayer);
		MakeMoveDTO MakeMove(Guid gameId, MakeMoveDTO makeMoveDTO);
	}
}
