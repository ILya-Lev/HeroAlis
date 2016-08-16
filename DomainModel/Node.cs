using DomainModel.Creatures;
using System.Collections.Generic;

namespace DomainModel
{
	public class Node
	{
		public Position Position { get; set; }
		public CreatureState WillChangeCreatureStateBy { get; set; }

		public bool IsHole { get; set; }

		public bool IsMonster => Monster?.Position == Position;
		public bool IsHero => Hero?.Position == Position;

		public BaseCreature Hero { get; set; }
		public BaseCreature Monster { get; set; }


		public List<Node> Neighbors { get; set; }
	}
}
