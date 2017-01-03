namespace HeroAlis.DataModel
{
	public class State
	{
		public int Mana { get; set; }
		public int Stamina { get; set; }
		public int Attack { get; set; }
		public int Defence { get; set; }

		public State() { }

		private State(State rhs)
		{
			Mana = rhs.Mana;
			Stamina = rhs.Stamina;
			Attack = rhs.Attack;
			Defence = rhs.Defence;
		}

		public static State operator +(State lhs, State rhs)
		{
			if (lhs == null) return new State(rhs);
			if (rhs == null) return new State(lhs);

			return new State
			{
				Mana = lhs.Mana + rhs.Mana,
				Stamina = lhs.Stamina + rhs.Stamina,
				Attack = lhs.Attack + rhs.Attack,
				Defence = lhs.Defence + rhs.Defence
			};
		}
	}
}