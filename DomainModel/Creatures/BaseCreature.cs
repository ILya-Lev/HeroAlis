namespace DomainModel.Creatures
{
	public abstract class BaseCreature
	{
		public Position Position { get; set; }
		public CreatureState State { get; set; }
		public bool IsAlive { get; protected set; }
		public abstract int Damage { get; }

		public abstract void Attacked (int damage);
	}
}