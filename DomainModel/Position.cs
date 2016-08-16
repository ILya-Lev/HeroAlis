namespace DomainModel
{
	public class Position
	{
		public int X { get; set; }
		public int Y { get; set; }

		public bool IsNeighbor (Position position)
		{
			var dx = position.X - X;
			var dy = position.Y - Y;

			return (dx == 0 && (dy == 1 || dy == -1))
				   || (dy == 0 && (dx == 1 || dx == -1));
		}

		public bool IsInRange (int width, int height) => 0 <= X && X < width && 0 <= Y && Y < height;

		public override string ToString () => $"[{X}; {Y}]";

		public static bool operator == (Position lhs, Position rhs) => lhs?.X == rhs?.X && lhs?.Y == rhs?.Y;

		public static bool operator != (Position lhs, Position rhs) => !(lhs == rhs);

		#region automatically generated equality members
		protected bool Equals (Position other)
		{
			return X == other.X && Y == other.Y;
		}

		public override bool Equals (object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Position) obj);
		}

		public override int GetHashCode ()
		{
			unchecked
			{
				return (X * 397) ^ Y;
			}
		}
		#endregion automatically generated equality members
	}
}