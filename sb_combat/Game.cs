using SuperBaddy.Combat.Players;
using SuperBaddy.Combat.Cards;
using System.Collections.Generic;
using System;
using System.Linq;

namespace SuperBaddy.Combat
{
	public class Game
	{
		public Game(IPlayer p1, IPlayer p2)
		{
            P1 = p1;
            P2 = p2;
        }

        public void Run()
        {
            TurnNum = 1;
            CurrentTurn = new Turn(TurnNum, P1, P2);

            TurnResults = new List<TurnResult>();

            while (TurnResults.LastOrDefault()?.IsGameOver ?? false)
            {
                P1.PickHand();
                P2.PickHand();

                TurnResults.Add(ResolveTurn());
            }
        }

		public TurnResult ResolveTurn()
		{
			var turnResult = CurrentTurn.Resolve();
			TurnResults.Add(turnResult);

			if (turnResult.IsGameOver)
			{
				GameDone(turnResult);
			}

			TurnNum++;
			CurrentTurn = new Turn(TurnNum, P1, P2);
            return turnResult;
		}
		public IPlayer P1 { get; set; }
		public IPlayer P2 { get; set; }
		public Turn CurrentTurn { get; set; }
		public int TurnNum { get; set; }
		public List<TurnResult> TurnResults { get; set; }

	    public event EventHandler<GameOverEventArgs> GameOver;
	    protected virtual void OnGameOver(GameOverEventArgs e)
		{
		    EventHandler<GameOverEventArgs> handler = GameOver;
		    if (handler != null)
		    {
		        handler(this, e);
		    }
		}

		public void GameDone(TurnResult turnResult)
		{
			GameResult gameResult = new GameResult(this, turnResult);
		    if (turnResult.Loser.IsUser)
		    {
				Console.WriteLine("You Lose!");

	        	GameOverEventArgs args = new GameOverEventArgs(gameResult);
	        	OnGameOver(args);
		    }
		    else
		    {
		    	Console.WriteLine("You Win!");
	        	GameOverEventArgs args = new GameOverEventArgs(gameResult);
	        	OnGameOver(args);
		    }
		}
	}

	public class GameOverEventArgs : EventArgs
	{
		public GameOverEventArgs(GameResult result)
		{
			Result = result;
		}

		public GameResult Result { get; private set; }
        public override string ToString()
	    {
	        return $"Game Over";
	    }
	}
}