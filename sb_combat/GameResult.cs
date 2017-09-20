using SuperBaddy.Combat.Players;
using SuperBaddy.Combat.Cards;

namespace SuperBaddy.Combat
{
	public class GameResult
	{
		public GameResult(Game game, TurnResult lastTurnResult)
		{
			Game = game;
			LastTurnResult = lastTurnResult;
		}

		public Game Game { get; private set; }
		public IPlayer Winner { get; set; }
		public IPlayer Loser { get; set; }
		public TurnResult LastTurnResult { get; private set; }

		public bool UserWon
		{
			get 
			{
				return Winner.IsUser;
			}
		}
		public int LastTurnNum
		{
			get
			{
				return LastTurnResult.Number;
			}
		}
	}
}