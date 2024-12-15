using Microsoft.AspNetCore.Mvc;
using RockPaperScissorsAPI.DTO.GameDTO;
using RockPaperScissorsAPI.DTO.PlayerDTO;
using RockPaperScissorsAPI.Entities;
using RockPaperScissorsAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RockPaperScissorsAPI.Controllers
{
    [Route("api/games")]
	[ApiController]
	public class GamesController : ControllerBase
	{
		private readonly IGameManager _gameManager;
		private readonly IPlayerManager _playerManager;
		private readonly IRPSLogic _rpsLogic;

        public GamesController(IGameManager gameManager, IPlayerManager playerManager, IRPSLogic rpsLogic)
        {
            _gameManager = gameManager;
			_playerManager = playerManager;
			_rpsLogic = rpsLogic;
        }

		// GET api/<GamesController>/{Guid}/status
		[HttpGet("{gameId}/status")]
		public ActionResult<GameStatusDTO> GetStatus(Guid gameId)
		{
			if (gameId == Guid.Empty)
			{
				return BadRequest($"Invalid Game ID provided.");
			}

			try
			{
				GameStatusDTO activeGame = _gameManager.GetGameStatus(gameId);
				return Ok(activeGame);
			}

			catch (KeyNotFoundException)
			{
				return NotFound($"No active game was found by the entered ID.");
			}

			catch (ArgumentException)
			{
				return BadRequest("Invalid player count");
			}

			catch (Exception)
			{
				return StatusCode(500, "An error occurred while trying to process your request.");
			}
		}

		// GET api/<GamesController>/{Guid}/result
		[HttpGet("{gameId}/result")]
		public ActionResult<FinishedGameDTO> GetResult(Guid gameId)
		{
			if (gameId == Guid.Empty)
			{
				return BadRequest("Invalid Game ID provided.");
			}

			try
			{
				FinishedGameDTO finishedGame = _gameManager.GetGameResult(gameId);
				return Ok(finishedGame);
			}

			catch (ArgumentNullException)
			{
				return BadRequest("The Game is not finished. It has to have two players and both have to make their moves.");
			}

			catch (Exception)
			{
				return StatusCode(500, "An error occurred while trying to process your request.");
			}
		}

		// POST api/<GamesController>
		[HttpPost("create")]
		public ActionResult<NewGameDTO> Post([FromBody] CreatePlayerDTO createPlayerDTO)
		{
			//if (!ModelState.IsValid)
			//{
			//	return BadRequest(ModelState);
			//}

			if (createPlayerDTO == null)
			{
				return BadRequest("Player data is missing.");
			}

			try
			{
				NewGameDTO newGame = _gameManager.CreateGame(createPlayerDTO);
				return Ok(newGame);
			}

			catch (ArgumentNullException)
			{
				return BadRequest("A Name has to be entered.");
			}

			catch (Exception)
			{
				return StatusCode(500, "An error occurred while trying to process your request.");
			}
		}

		// PUT api/<GamesController>/{Guid}/join
		[HttpPut("{gameId}/join")]
		public ActionResult<ActiveGameDTO> Put(Guid gameId, [FromBody] CreatePlayerDTO createPlayerDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (gameId == Guid.Empty)
			{
				return BadRequest($"Invalid Game ID provided.");
			}

			if (createPlayerDTO == null)
			{
				return BadRequest($"Invalid Player data provided.");
			}

			try
			{
				Player newPlayer = _playerManager.CreatePlayer(createPlayerDTO);
				if (newPlayer == null)
				{
					return BadRequest("Player creation failed.");
				}

				ActiveGameDTO activeGame = _gameManager.JoinGame(gameId, newPlayer);
				if (activeGame == null)
				{
					return BadRequest("No active Game with given ID was found.");
				}

				return Ok(activeGame);
			}

			catch (ArgumentException)
			{
				return BadRequest("The game is full, two players have already joined.");
			}

			catch (Exception)
			{
				return StatusCode(500, "An error occurred while trying to process your request.");
			}
		}

		// PATCH api/<GamesController/{Guid}/move
		[HttpPatch("{gameId}/move")]
		public ActionResult<MakeMoveDTO> Patch(Guid gameId, [FromBody] MakeMoveDTO makeMoveDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (gameId == Guid.Empty)
			{
				return BadRequest("Invalid Game ID provided.");
			}

			if (makeMoveDTO == null)
			{
				return BadRequest("A Name and a Move have to be entered.");
			}

			if (!_rpsLogic.IsValidMove(makeMoveDTO.Move))
			{
				return BadRequest("The move is not valid. Choose Rock, Paper or Scissors.");
			}

			try
			{
				MakeMoveDTO patchedGame = _gameManager.MakeMove(gameId, makeMoveDTO);
				if (patchedGame == null)
				{
					return BadRequest("Move could not be made.");
				}

				return Ok(patchedGame);
			}

			catch (ArgumentException)
			{
				return BadRequest("No user with that Name was found.");
			}

			catch (InvalidOperationException)
			{
				return BadRequest("This Player has already made a Move.");
			}

			catch (Exception)
			{
				return StatusCode(500, "An error occurred while trying to process your request.");
			}
		}
	}
}
