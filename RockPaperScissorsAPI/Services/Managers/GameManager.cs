using RockPaperScissorsAPI.DTO.GameDTO;
using RockPaperScissorsAPI.DTO.PlayerDTO;
using RockPaperScissorsAPI.Entities;
using RockPaperScissorsAPI.Interfaces;
using RockPaperScissorsAPI.Services.Converters;

namespace RockPaperScissorsAPI.Services.Managers
{
    public class GameManager : IGameManager
    {
        private readonly Dictionary<Guid, Game> _games = new Dictionary<Guid, Game>();
        private readonly IRPSLogic _rpsLogic;

        public GameManager(IRPSLogic rpsLogic)
        {
            _rpsLogic = rpsLogic;
        }

        public GameStatusDTO GetGameStatus(Guid gameId)
		{
            Game activeGame = GetGameById(gameId);
            return activeGame.ToGameStatusDTO();
		}

		public NewGameDTO CreateGame(CreatePlayerDTO createPlayerDTO)
        {
            if (createPlayerDTO == null)
            {
                throw new ArgumentNullException($"{createPlayerDTO} cannot be null.");
            }

            Game newGame = new()
            {
                GameId = Guid.NewGuid(),
                Players = new List<Player>
                {
                    new()
                    {
                        Name = createPlayerDTO.Name,
                    }
                }
            };

            _games[newGame.GameId] = newGame;
            return newGame.ToNewGameDTO();
        }

        public ActiveGameDTO JoinGame(Guid gameId, Player newPlayer)
        {
            Game gameToJoin = GetGameById(gameId);

            if (_rpsLogic.IsFullGame(gameToJoin))
            {
                throw new ArgumentException($"{gameToJoin} is already full.");
            }

            gameToJoin.Players.Add(newPlayer);   
            return gameToJoin.ToActiveGameDTO();
        }

		public MakeMoveDTO MakeMove(Guid gameId, MakeMoveDTO makeMoveDTO)
        {
            Game game = GetGameById(gameId);

            Player? playerToUpdate = game.Players.FirstOrDefault(p => p.Name == makeMoveDTO.Name);

            if (playerToUpdate == null)
            {
                throw new ArgumentException($"No user with Name: {makeMoveDTO.Name} was found.");
            }

            if (playerToUpdate.Move != null)
            {
                throw new InvalidOperationException($"{makeMoveDTO.Name} has already made a Move.");
            }

            playerToUpdate.Move = makeMoveDTO.Move;
            return game.ToMakeMoveDTO(playerToUpdate);
        }

		public FinishedGameDTO GetGameResult(Guid gameId)
		{
			Game finishedGame = GetGameById(gameId);

			if (_rpsLogic.IsFinishedGame(finishedGame))
			{
				finishedGame.Result = _rpsLogic.DetermineWinner(finishedGame.Players[0], finishedGame.Players[1]);
			}

			else
			{
				throw new ArgumentNullException("Two players have to enter the Game and make their Moves.");
			}

			return finishedGame.ToFinishedGameDTO();
		}

		private Game GetGameById(Guid gameId)
        {
			if (!_games.ContainsKey(gameId))
			{
				throw new KeyNotFoundException($"Game with ID: {gameId} was not found.");
			}

			Game game = _games[gameId];
            return game;
		}
    }
}
