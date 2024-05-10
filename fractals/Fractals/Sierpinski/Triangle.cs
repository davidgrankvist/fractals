using System.Numerics;

namespace Fractals.Sierpinski
{
	internal struct Triangle
	{
		public Triangle(Vector2 top, Vector2 left, Vector2 right)
		{
			Top = top;
			Left = left;
			Right = right;
		}
		public Vector2 Top { get; private set; }
		public Vector2 Left { get; private set; }
		public Vector2 Right { get; private set; }

		public Triangle[] ComputeChildren()
		{
			var children = new Triangle[3];

			var leftTopMid = GetMidPoint(Left, Top);
			var leftRightMid = GetMidPoint(Left, Right);
			var topRightMid = GetMidPoint(Top, Right);

			var topTriangle = new Triangle(Top, leftTopMid, topRightMid);
			var leftTriangle = new Triangle(leftTopMid, Left, leftRightMid);
			var rightTriangle = new Triangle(topRightMid, leftRightMid, Right);

			children[0] = topTriangle;
			children[1] = leftTriangle;
			children[2] = rightTriangle;

			return children;
		}

		private static Vector2 GetMidPoint(Vector2 first, Vector2 second)
		{
			var midX = (first.X + second.X) / 2;
			var midY = (first.Y + second.Y) / 2;
			return new Vector2(midX, midY);
		}
	}
}
