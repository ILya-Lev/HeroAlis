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

		private readonly List<Node> _nodes;

		public Field (int width, int height, Hero hero, Monster monster)
		{
			Width = width;
			Height = height;
			_nodes = new List<Node>(width * height);

			var trc = new Position { X = width, Y = height };       // trc = top right corner

			if (!hero.Position.IsInRange(width, height))
				throw new ArgumentException($"Hero {hero.Position} cannot stand outside the field {trc}");

			if (!monster.Position.IsInRange(width, height))
				throw new ArgumentException($"Hero {monster.Position} cannot stand outside the field {trc}");

			Hero = hero;
			Monster = monster;
		}

		private void InitializeNodes ()
		{
			//todo lis: implemnet this!
		}


	}
}
