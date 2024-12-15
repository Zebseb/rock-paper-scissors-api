namespace RockPaperScissorsAPI.DTO.GameDTO
{
	public class GameStatusDTO
	{
		public Guid GameId { get; set; }
		public bool PlayerOneJoined { get; set; }
		public bool PlayerOneHasMadeMove { get; set; }
		public bool PlayerTwoJoined { get; set; }
		public bool PlayerTwoHasMadeMove { get; set; }
	}
}
