using DomainModel.Creatures;
using System;
using System.Collections.Generic;

namespace DomainModel
{
	public class Field
	{
		public int Width { get; }
		public int Height { get; }

		public Hero Hero { get; set; }
		public Monster Monster { get; set; }
		public string Winner { get; private set; }

		private readonly List<Node> _nodes;
		private readonly List<Node> _path;

		public Field (int width, int height, Hero hero, Monster monster)
		{
			Width = width;
			Height = height;
			_nodes = new List<Node>(width * height);
			_path = new List<Node>();

			var trc = new Position { X = width, Y = height };       // trc = top right corner

			if (!hero.Position.IsInRange(width, height))
				throw new ArgumentException($"Hero {hero.Position} cannot stand outside the field {trc}");

			if (!monster.Position.IsInRange(width, height))
				throw new ArgumentException($"Hero {monster.Position} cannot stand outside the field {trc}");

			Hero = hero;
			Hero.MonsterIsMet += Battle;
			Monster = monster;

			InitializeNodes();
		}

		private void InitializeNodes ()
		{
			throw new NotImplementedException();
		}

		public string MakeMove ()
		{
			CalculateThePath();
			foreach (Node node in _path)
			{
				Hero.MoveTo(node);
			}
			return Winner;
		}

		private void CalculateThePath ()
		{
			throw new NotImplementedException();
		}

		private void Battle (Hero hero, Monster monster)
		{
			if (hero == null || monster == null)
				throw new ArgumentException("either hero or monster is null");

			while (hero.IsAlive || monster.IsAlive)
			{
				hero.Attacked(monster.Damage);
				if (hero.IsAlive)
					monster.Attacked(hero.Damage);
			}

			Winner = hero.IsAlive ? nameof(Hero) : nameof(Monster);
		}
	}
}
