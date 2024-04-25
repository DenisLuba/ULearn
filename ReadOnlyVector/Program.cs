namespace ReadOnlyVector;

public class ReadOnlyVector
{
    public readonly double X, Y;

    public ReadOnlyVector(double x, double y)
    {
        X = x; Y = y;
    }

    public ReadOnlyVector Add(ReadOnlyVector other)
        => new ReadOnlyVector(X + other.X, Y + other.Y);

    public ReadOnlyVector WithX(double x) => new ReadOnlyVector(x, Y);

    public ReadOnlyVector WithY(double y) => new ReadOnlyVector(X, y);
}