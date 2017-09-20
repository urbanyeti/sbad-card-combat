using SuperBaddy.Combat.Players;

namespace SuperBaddy.Combat
{
	public class TurnResult
	{
		public TurnResult(Turn turn)
		{
			Turn = turn;
		}

		public Turn Turn { get; private set; }
		public bool IsGameOver { get; set; }
		public IPlayer Winner { get; set; }
		public IPlayer Loser { get; set; }

		public int Number
		{
			get
			{
				return Turn.Number;
			}
		}

		public TurnResult SetGameOver(IPlayer winner, IPlayer loser)
		{
			IsGameOver = true;
			Winner = winner;
			Loser = loser;
			return this;
		}
	}
}