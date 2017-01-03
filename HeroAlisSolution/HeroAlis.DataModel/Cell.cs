namespace HeroAlis.DataModel
{
	public class Cell
	{
		public int Index { get; set; }

		public bool IsHole { get; set; }
		public bool IsMonster { get; set; }
		public bool IsHero { get; set; }

		public int Mana
		{
			get { return State.Mana; }
			set { State.Mana = value; }
		}

		public int Stamina
		{
			get { return State.Stamina; }
			set { State.Stamina = value; }
		}

		public int Attack
		{
			get { return State.Attack; }
			set { State.Attack = value; }
		}

		public int Defence
		{
			get { return State.Defence; }
			set { State.Defence = value; }
		}


		public State State { get; private set; }

		public Cell()
		{
			State = new State();
		}
	}
}