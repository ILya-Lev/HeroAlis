using System;

namespace DomainModel.Creatures
{
	public class Hero : BaseCreature
	{
		public override int Damage => State.Attack * State.Mana;

		public event MonsterIsMetHandler MonsterIsMet;

		public override void Attacked (int damage)
		{
			if (!IsAlive)
				throw new InvalidOperationException("Hero is already dead and cannot be attacked");

			State.Health -= damage - State.Defence * State.Mana;
			IsAlive = State.Health > 0;
		}

		public void MoveTo (Node node)
		{
			if (node.Position.IsNeighbor(Position))
				throw new InvalidOperationException($"Hero cannot move from {Position} to {node.Position}."
												+ "They are not neighbors.");

			if (!IsAlive)
				throw new InvalidOperationException($"Hero cannot move from {Position} to {node.Position}."
												+ "Hero is already dead.");
			Position = node.Position;
			if (node.IsHole) IsAlive = false;
			else if (node.IsMonster) MonsterIsMet?.Invoke(this, node.Monster as Monster);
			else State += node.WillChangeCreatureStateBy;
		}
	}
}
