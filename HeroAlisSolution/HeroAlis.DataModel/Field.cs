using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HeroAlis.DataModel
{
	public class Field
	{
		public int Width { get; }
		public int Height { get; }
		public IReadOnlyList<Cell> Cells { get; }

		public Field()
		{
			try
			{
				var data = File.ReadLines(@"resources\Field.txt").ToList();
				var sizes = data[0].Split(new[] { ' ', ',', 'x', 'X', ';' },
						StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToList();

				Height = sizes[0];
				Width = sizes[1];

				if (data.Count < Height + 1)
					throw new IndexOutOfRangeException($"Not enough data. Present {data.Count} rows, need {Height + 1} rows");

				Cells = data.Skip(1).SelectMany(line => line.Split(new[] { ' ' },
													StringSplitOptions.RemoveEmptyEntries))
									.Select(Factory.GenerateCell).ToList();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
	}
}
