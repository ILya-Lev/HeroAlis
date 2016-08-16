using System;

namespace DomainModel.Creatures
{
	public class Monster : BaseCreature
	{
		public override int Damage => State.Attack * State.Mana * 2;

		public override void Attacked (int damage)
		{
			if (!IsAlive)
				throw new InvalidOperationException("Monster is already dead and cannot be attacked");

			State.Health -= damage - State.Defence * State.Mana * 3;
			IsAlive = State.Health > 0;
		}

	}
}
