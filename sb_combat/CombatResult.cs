using SuperBaddy.Combat.Players;
using SuperBaddy.Combat.Cards;

namespace SuperBaddy.Combat
{
	public class CombatResult
	{
		public CombatResult(IPlayer p1, IPlayer p2)
		{
			P1 = p1;
			P2 = p2;
			Card1 = P1.ActiveCard;
			Card2 = P2.ActiveCard;
		}
		public IPlayer P1 { get; private set; }
		public IPlayer P2 { get; private set; }
		public ICard Card1 { get; private set; }
		public ICard Card2 { get; private set; }
		public int Dmg1 { get; set; }
		public int Dmg2 { get; set; }
	}
}