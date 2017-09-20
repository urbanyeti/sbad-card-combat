using SuperBaddy.Combat.Players;
using SuperBaddy.Combat.Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperBaddy.Combat
{
	public class Turn
	{
		public Turn(int number, IPlayer p1, IPlayer p2)
		{
			Number = number;
			P1 = p1;
			P2 = p2;
			P1.PlayerDead += new EventHandler<PlayerDeadEventArgs>(turn_OnPlayerDead);
			P2.PlayerDead += new EventHandler<PlayerDeadEventArgs>(turn_OnPlayerDead);

            Phases = new List<Phase>();
		}

		private bool _stopTurn = false;
        private IPlayer _winner;
        private IPlayer _loser;
		public int Number { get; private set; }
		public IPlayer P1 { get; private set; }
		public IPlayer P2 { get; private set; }
		public List<Phase> Phases { get; set; }

		public TurnResult Resolve()
		{
            IPlayer fastPlayer, slowPlayer;
			TurnResult result = new TurnResult(this);

			int numPhases = Math.Max(P1.Hand.Count, P2.Hand.Count);
			for (int i = 0; i < numPhases && !_stopTurn; i++)
			{
				var phase = new Phase(i);
				Phases.Add(phase);

				P1.ActiveCard = P1.Hand.ElementAtOrDefault(i);
				P2.ActiveCard = P2.Hand.ElementAtOrDefault(i);

				// Figure out who goes first
				fastPlayer = (P1.SPD >= P2.SPD) ? P1 : P2;
				slowPlayer = (P1.SPD >= P2.SPD) ? P2 : P1;

				phase.CombatResults.Add(ResolveCombat(fastPlayer, slowPlayer));
				if (_stopTurn)
				{
					return result.SetGameOver(_winner, _loser);
				}

				phase.CombatResults.Add(ResolveCombat(slowPlayer, fastPlayer));
				if (_stopTurn)
				{
					return result.SetGameOver(_winner, _loser);
				}
			}
			return result;
		}

		public CombatResult ResolveCombat(IPlayer p1, IPlayer p2)
		{
			CombatResult result = new CombatResult(p1, p2);
			// Is p1 attacking?
			var atk_card1 = p1.ActiveCard as AttackCard;
			if (atk_card1 != null)
			{
				var attackDmg = Math.Max(atk_card1.AttackAgainst(p2.ActiveCard) + p1.ATK - p2.DEF, 0);
				result.Dmg1 = attackDmg;
				p2.HP -= attackDmg;
			}

			if (_stopTurn)
			{
				_loser = p2;
				_winner = p1;
			}
				// Did p2 counter?
			var cnt_card2 = p2.ActiveCard as CounterCard;
			if (cnt_card2 != null)
			{
				var counterDmg = Math.Max(cnt_card2.CounterAttack() + p2.ATK - p1.DEF, 0);
				result.Dmg2 = counterDmg;
				p1.HP -= counterDmg;
			}

			if (_stopTurn)
			{
				_loser = p1;
				_winner = p2;
			}

			return result;
		}

		private void turn_OnPlayerDead(object sender, PlayerDeadEventArgs e)
		{
		    _stopTurn = true;
		    _loser = e.DeadPlayer;
		}
	}

	public class Phase
	{
		public Phase(int number)
		{
			Number = number;
			CombatResults = new List<CombatResult>();
		}
		public int Number { get; set; }
		public List<CombatResult> CombatResults { get; set; }
	}
}