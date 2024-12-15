namespace RockPaperScissorsAPI.Entities
{
	public class Game
	{
        public Guid GameId { get; set; }
		public List<Player> Players { get; set; } = new();
        public string Result { get; set; }
    }
}
