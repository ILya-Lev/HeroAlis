using HeroAlis.DataModel;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroAlis.Logic
{
	public static class DijkstraPath
	{
		public static List<Vertex> FindPath(Graph graph, Vertex heroVertex, Vertex monsterVertex)
		{
			var frontier = new Frontier();
			frontier.AddTailVertex(heroVertex, null);

			var current = heroVertex;
			while (current != monsterVertex && frontier.Count < graph.Vertices.Count)
			{
				var edge = frontier.BetterEdge();
				current = edge.Tail;
				frontier.AddTailVertex(edge.Tail, edge);
			}

			if (current != monsterVertex)
				throw new ArgumentException("Unable to find monster vertex.");

			var path = new List<Vertex>();
			while (current != null)
			{
				path.Add(current);
				current = frontier.PreviousVertex(current);
			}
			return path;
		}

		private class Frontier
		{
			private readonly Dictionary<Vertex, Edge> _seenVertices = new Dictionary<Vertex, Edge>();
			private readonly HashSet<Edge> _outerEdges = new HashSet<Edge>();
			public int Count => _seenVertices.Count;

			public Edge BetterEdge()
			{
				if (_outerEdges.IsNullOrEmpty())
					return null;

				return _outerEdges.Where(e => !e.Tail.Cell.IsHole).MaxBy(e => e.Length);
			}

			public void AddTailVertex(Vertex vertex, Edge edge)
			{
				_seenVertices.Add(vertex, edge);
				vertex.Edges.ForEach(e => _outerEdges.Add(e));

				_outerEdges.RemoveWhere(e => _seenVertices.ContainsKey(e.Tail));
			}

			public Vertex PreviousVertex(Vertex currentVertex) => _seenVertices[currentVertex]?.Head;
		}
	}
}
