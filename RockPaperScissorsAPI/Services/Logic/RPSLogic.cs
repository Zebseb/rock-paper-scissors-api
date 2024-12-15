using RockPaperScissorsAPI.Entities;
using RockPaperScissorsAPI.Enums;
using RockPaperScissorsAPI.Interfaces;

namespace RockPaperScissorsAPI.Services.Logic
{
	public class RPSLogic : IRPSLogic
	{
		private readonly string rockString = Move.Rock.ToString().ToLower().Trim();
		private readonly string paperString = Move.Paper.ToString().ToLower().Trim();
		private readonly string scissorsString = Move.Scissors.ToString().ToLower().Trim();
		private readonly int maxNumOfPlayers = 2;

		public bool IsValidMove(string playerMove)
		{
			return Enum.TryParse<Move>(playerMove.Trim(), true, out _);
		}

		public bool IsFullGame(Game fullGame)
		{
			return fullGame.Players.Count == maxNumOfPlayers;
		}

		public bool IsFinishedGame(Game finishedGame)
		{
			return finishedGame.Players.Count == maxNumOfPlayers && finishedGame.Players.All(p => p.Move != null);
		}

		public string DetermineWinner(Player playerOne, Player playerTwo)
		{
			if (playerOne.Move == null ||  playerTwo.Move == null)
			{
				throw new ArgumentNullException("Both players needs to make their Moves!");
			}

			string playerOneMove = playerOne.Move.ToLower().Trim();
			string playerTwoMove = playerTwo.Move.ToLower().Trim();

			if (playerOne.Move == playerTwo.Move)
			{
				return "The Game ends in a TIE!";
			}

			if ((playerOneMove == rockString && playerTwoMove == scissorsString)
				|| (playerOneMove == scissorsString && playerTwoMove == paperString)
				|| (playerOneMove == paperString && playerTwoMove == rockString))
			{
				return $"The WINNER is {playerOne.Name}!";
			}

			else
			{
				return $"The WINNER is {playerTwo.Name}!";
			}
		}
	}
}
