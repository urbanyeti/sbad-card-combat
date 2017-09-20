namespace SuperBaddy.Combat.Cards
{
	public static class PowerType
	{
		public enum Type { Strength, Technology, Magic };
		public enum TypeOutcome { Win, Tie, Lose };

		public static TypeOutcome Versus(Type type1, Type type2)
		{
			switch (type1)
			{
				case Type.Strength:
					if (type2 == Type.Magic) return TypeOutcome.Win;
					else if (type2 == Type.Technology) return TypeOutcome.Lose;
					break;
				case Type.Technology:
					if (type2 == Type.Strength) return TypeOutcome.Win;
					else if (type2 == Type.Magic) return TypeOutcome.Lose;
					break;
				case Type.Magic:
					if (type2 == Type.Technology) return TypeOutcome.Win;
					else if (type2 == Type.Strength) return TypeOutcome.Lose;
					break;
			}
			return TypeOutcome.Tie;
		}
	}
}