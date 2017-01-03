using HeroAlis.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroAlis.Logic
{
	public static class Utilities
	{
		public static bool IsNullOrEmpty<T>(this ICollection<T> source)
		{
			return source == null || source.Count == 0;
		}

		public static State Score(this List<Vertex> path)
		{
			return path.IsNullOrEmpty()
				? new State()
				: path.Aggregate(new State(), (total, current) => total + current.Cell.State);
		}

		public static bool FightResult(State pathScore, State heroState, State monsterState)
		{
			heroState = heroState + pathScore;
			while (monsterState.Stamina > 0 && heroState.Stamina > 0)
			{
				heroState.Stamina -= monsterState.Attack * monsterState.Mana / heroState.Defence;
				if (heroState.Stamina > 0)
					monsterState.Stamina -= heroState.Attack * heroState.Mana / monsterState.Defence;
			}

			return heroState.Stamina > 0;
		}

		public static void PrintPath(Field field, List<Vertex> path)
		{
			var lookup = path.Select(v => v.Cell).ToLookup(c => c.Index);
			for (int row = 0; row < field.Height; row++)
			{
				for (int col = 0; col < field.Width; col++)
				{
					var index = row * field.Width + col;
					var symbol = lookup.Contains(index)
						? "*" : ".";
					Console.Write(symbol + " ");
				}
				Console.WriteLine();
			}
		}
	}
}