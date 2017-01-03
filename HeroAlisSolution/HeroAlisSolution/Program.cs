using HeroAlis.DataModel;
using HeroAlis.Logic;
using System;
using System.Linq;

namespace HeroAlisSolution
{
	class Program
	{
		static void Main(string[] args)
		{
			var field = new Field();
			var graph = Factory.CreateGraph(field);
			var heroVertex = graph.Vertices.FirstOrDefault(v => v.Cell.IsHero);
			var monsterVertex = graph.Vertices.FirstOrDefault(v => v.Cell.IsMonster);

			var path = DijkstraPath.FindPath(graph, heroVertex, monsterVertex);
			Utilities.PrintPath(field, path);
			var pathScore = path.Score();

			Console.WriteLine();

			var reversePath = DijkstraPath.FindPath(graph, monsterVertex, heroVertex);
			Utilities.PrintPath(field, reversePath);
			var reversePathScore = path.Score();

			var hero = new State
			{
				Attack = 10,
				Defence = 10,
				Mana = 10,
				Stamina = 10
			};

			var monster = new State
			{
				Attack = 100,
				Defence = 100,
				Mana = 100,
				Stamina = 100
			};

			var result = Utilities.FightResult(pathScore, hero, monster);
		}
	}
}
