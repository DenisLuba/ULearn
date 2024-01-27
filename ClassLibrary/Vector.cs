namespace Geometry;

public class Vector
{
    public double X, Y;

    public double GetLength() => Geometry.GetLength(this);

    public Vector Add(Vector vector) => Geometry.Add(this, vector);

    public bool Belongs(Segment segment) => Geometry.IsVectorInSegment(this, segment);
}

public class Segment
{
    public Vector Begin = new() { X = 0, Y = 0 };
    public Vector End = new() { X = 0, Y = 0 };

    public double GetLength() => Geometry.GetLength(this);

    public bool Contains(Vector vector) => Geometry.IsVectorInSegment(vector, this);
}

public class Geometry
{
    public static double GetLength(Vector vector)
        => GetLength(new Vector { X = 0, Y = 0 }, vector);

    public static double GetLength(Segment segment)
        => GetLength(segment.Begin, segment.End);

    private static double GetLength(Vector vector1, Vector vector2)
        => Math.Sqrt(Math.Pow(vector1.X - vector2.X, 2) + Math.Pow(vector1.Y - vector2.Y, 2));

    public static Vector Add(Vector vector1, Vector vector2)
        => new() { X = vector1.X + vector2.X, Y = vector1.Y + vector2.Y };

    public static bool IsVectorInSegment(Vector v, Segment s)
        => Math.Abs(GetLength(v, s.Begin) + GetLength(v, s.End) - GetLength(s)) < .1e-5;
}