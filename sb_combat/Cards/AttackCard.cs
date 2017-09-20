using System.Collections.Generic;

namespace SuperBaddy.Combat.Cards
{
	public class AttackCard : BaseCard
	{
        public AttackCard(string id, string name, string description, PowerType.Type powerType, int powerValue, IEnumerable<string> properties)
            :base(id, name, description, powerType, powerValue, properties)
        { }
        public int AttackAgainst(ICard card2)
		{
			int cardDamage = PowerValue;

			// Are they defending?
			var def_card2 = card2 as DefendCard; 
			if (def_card2 != null)
			{
				cardDamage -= def_card2.DefendAgainst(this);
			}

			return cardDamage;
		}
	}
}