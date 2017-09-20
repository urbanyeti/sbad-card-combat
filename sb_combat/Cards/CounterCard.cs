using System.Collections.Generic;

namespace SuperBaddy.Combat.Cards
{
	public class CounterCard : DefendCard
	{
        public CounterCard(string id, string name, string description, PowerType.Type powerType, int powerValue, IEnumerable<string> properties)
            :base(id, name, description, powerType, powerValue, properties)
        { }
        public int CounterAttack()
		{
			return PowerValue;
		}
	}
}