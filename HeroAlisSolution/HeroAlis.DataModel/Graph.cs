using System.Collections.Generic;
using System.Diagnostics;

namespace HeroAlis.DataModel
{
	public class Graph
	{
		public List<Vertex> Vertices { get; } = new List<Vertex>();
	}

	[DebuggerDisplay("idx={Cell.Index}")]
	public class Vertex
	{
		public Cell Cell { get; set; }
		public List<Edge> Edges { get; } = new List<Edge>();
	}

	public class Edge
	{
		public Vertex Head { get; set; }
		public Vertex Tail { get; set; }

		public int Length => Tail.Cell.IsHole
			? 100000
			: 1000 - (Tail.Cell.Attack + Tail.Cell.Defence + Tail.Cell.Mana + Tail.Cell.Stamina);
	}
}
