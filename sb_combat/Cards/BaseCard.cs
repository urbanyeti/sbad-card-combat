using System.Collections.Generic;
using System.Linq;

namespace SuperBaddy.Combat.Cards
{
	public abstract class BaseCard : ICard
	{
		public BaseCard(string id, string name, string description, PowerType.Type powerType, int powerValue, IEnumerable<string> properties)
		{
            Id = id;
			Name = name;
			Description = description;
			PowerType = powerType;
			PowerValue = powerValue;
            Properties = properties.ToList();
		}

        public string Id { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public PowerType.Type PowerType { get; private set; }
		public int PowerValue { get; private set; }
        public List<string> Properties { get; private set; }

		public string CardType
		{
			get { return this.GetType().Name; }
		}

		public override string ToString()
		{
			return $"Card: [Name: {Name}] [CardType: {CardType}] [Power: {PowerValue} {PowerType}]";
		}
	}
}