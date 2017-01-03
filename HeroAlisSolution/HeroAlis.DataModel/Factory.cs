using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroAlis.DataModel
{
	public static class Factory
	{
		private static readonly Dictionary<char, Action<Cell>> _cellPropertySetters
			= new Dictionary<char, Action<Cell>>
			{
				['M'] = cell => cell.Mana += 10,
				['S'] = cell => cell.Stamina += 10,
				['D'] = cell => cell.Defence += 10,
				['A'] = cell => cell.Attack += 10,
				['C'] = cell => cell.IsMonster = true,
				['H'] = cell => cell.IsHero = true,
				['Z'] = cell => cell.IsHole = true,
			};

		public static Cell GenerateCell(string cellPiece, int index)
		{
			var newCell = new Cell { Index = index };
			cellPiece.ToCharArray()
				.Where(code => _cellPropertySetters.ContainsKey(code))
				.ToList().ForEach(code => _cellPropertySetters[code](newCell));
			return newCell;
		}

		public static Graph CreateGraph(Field field)
		{
			var graph = new Graph();

			//create vertices
			for (int row = 0; row < field.Height; row++)
			{
				for (int col = 0; col < field.Width; col++)
				{
					var idx = row * field.Width + col;
					var vertex = new Vertex { Cell = field.Cells[idx] };
					graph.Vertices.Add(vertex);
				}
			}

			//create edges
			for (int row = 0; row < field.Height; row++)
			{
				for (int col = 0; col < field.Width; col++)
				{
					var idx = row * field.Width + col;
					var headVertex = graph.Vertices[idx];
					var row1 = row;
					var col1 = col;
					var edges = new[]{
							new {Row = -1, Col = 0},
							new {Row = +1, Col = 0},
							new {Row = 0, Col = -1},
							new {Row = 0, Col = +1},
						}.Select(delta => new { Row = row1 + delta.Row, Col = col1 + delta.Col })
						.Where(c => c.Row >= 0 && c.Row < field.Height
								 && c.Col >= 0 && c.Col < field.Width)
						.Select(coord => coord.Row * field.Width + coord.Col)
						.Select(index => graph.Vertices[index])
						.Select(vertex => new Edge { Head = headVertex, Tail = vertex });

					headVertex.Edges.AddRange(edges);
				}
			}
			return graph;
		}
	}
}