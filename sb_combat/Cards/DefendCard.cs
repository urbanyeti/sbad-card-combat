using System.Collections.Generic;

namespace SuperBaddy.Combat.Cards
{
	public class DefendCard : BaseCard
	{
        public DefendCard(string id, string name, string description, PowerType.Type powerType, int powerValue, IEnumerable<string> properties)
            :base(id, name, description, powerType, powerValue, properties)
        { }

		public int DefendAgainst(AttackCard attackCard)
		{
			var outcome = Cards.PowerType.Versus(this.PowerType, attackCard.PowerType);
			switch (outcome)
			{
				case Cards.PowerType.TypeOutcome.Win:
					return PowerValue * 2;
				case Cards.PowerType.TypeOutcome.Tie:
					return PowerValue;
				default:
					return 0;
			}	
		}
	}
}