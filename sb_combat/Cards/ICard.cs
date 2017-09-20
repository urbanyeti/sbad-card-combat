using System.Collections.Generic;

namespace SuperBaddy.Combat.Cards
{
	public interface ICard
	{
        string Id { get; }
		string Name { get; }
		string Description { get; }
		PowerType.Type PowerType { get; }
		int PowerValue { get; }
		string CardType { get; }
        List<string> Properties { get; }
	}
}