using RockPaperScissorsAPI.Entities;

namespace RockPaperScissorsAPI.Interfaces
{
	public interface IRPSLogic
	{
		string DetermineWinner(Player playerOne, Player playerTwo);
		bool IsValidMove(string playerMove);
		bool IsFullGame(Game fullGame);
		bool IsFinishedGame(Game finishedGame);
	}
}
