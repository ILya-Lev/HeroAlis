namespace DomainModel
{
	public class CreatureState
	{
		public int Health { get; set; }
		public int Attack { get; set; }
		public int Defence { get; set; }
		public int Mana { get; set; }

		public static CreatureState operator + (CreatureState lhs, CreatureState rhs) => new CreatureState
		{
			Health = lhs.Health + rhs.Health,
			Attack = lhs.Attack + rhs.Attack,
			Defence = lhs.Defence + rhs.Defence,
			Mana = lhs.Mana + rhs.Mana
		};

		public static CreatureState operator - (CreatureState state) => new CreatureState
		{
			Health = -state.Health,
			Attack = -state.Attack,
			Defence = -state.Defence,
			Mana = -state.Mana
		};

		public static CreatureState operator - (CreatureState lhs, CreatureState rhs) => lhs + (-rhs);
	}
}
