using RockPaperScissorsAPI.DTO.GameDTO;
using RockPaperScissorsAPI.Entities;

namespace RockPaperScissorsAPI.Services.Converters
{
    public static class ConvertToDTO
	{
		public static NewGameDTO ToNewGameDTO(this Game gameToConvert)
		{
			if (gameToConvert == null)
			{
				throw new ArgumentNullException($"{gameToConvert} cannot be null.");
			}

			return new NewGameDTO
			{
				GameId = gameToConvert.GameId,
				PlayerOne = gameToConvert.Players[0].Name
			};
		}

		public static GameStatusDTO ToGameStatusDTO(this Game gameToConvert)
		{
			if (gameToConvert == null)
			{
				throw new ArgumentNullException($"{gameToConvert} cannot be null.");
			}

			switch (gameToConvert.Players.Count)
			{
				case 1:
					return new GameStatusDTO
					{
						GameId = gameToConvert.GameId,
						PlayerOneJoined = true,
						PlayerOneHasMadeMove = gameToConvert.Players[0].Move != null ? true : false,
						PlayerTwoJoined = false,
						PlayerTwoHasMadeMove = false
					};
				case 2:
					return new GameStatusDTO
					{
						GameId = gameToConvert.GameId,
						PlayerOneJoined = true,
						PlayerOneHasMadeMove = gameToConvert.Players[0].Move != null ? true : false,
						PlayerTwoJoined = true,
						PlayerTwoHasMadeMove = gameToConvert.Players[1].Move != null ? true : false
					};
				default:
					throw new ArgumentException($"{gameToConvert} has an invalid player count.");
			}
		}

		public static ActiveGameDTO ToActiveGameDTO(this Game gameToConvert)
		{
			if (gameToConvert == null)
			{
				throw new ArgumentNullException($"{gameToConvert} cannot be null.");
			}

			return new ActiveGameDTO
			{
				GameId = gameToConvert.GameId,
				PlayerOne = gameToConvert.Players.Count > 0 ? gameToConvert.Players[0].Name : null,
				PlayerTwo = gameToConvert.Players.Count > 1 ? gameToConvert.Players[1].Name : null
			};
		}

		public static MakeMoveDTO ToMakeMoveDTO(this Game gameToConvert, Player playerToMakeMove)
		{
			if (gameToConvert == null)
			{
				throw new ArgumentNullException($"{gameToConvert} cannot be null.");
			}

			return new MakeMoveDTO
			{
				Name = playerToMakeMove.Name,
				Move = "Move successfully made."
			};
		}

		public static FinishedGameDTO ToFinishedGameDTO(this Game gameToConvert)
		{
			if (gameToConvert == null)
			{
				throw new ArgumentNullException($"{gameToConvert} cannot be null.");
			}

			return new FinishedGameDTO
			{
				GameId = gameToConvert.GameId,
				PlayerOne = gameToConvert.Players[0],
				PlayerTwo = gameToConvert.Players[1],
				Result = gameToConvert.Result
			};
		}
	}
}
