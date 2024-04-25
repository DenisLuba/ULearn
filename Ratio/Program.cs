using System.Globalization;

public class Program
{
    public static void Main()
    {
        Check(1, 2);
        Check(2, 3);
        //Check(3, 0);
    }

    public static void Check(int num, int den)
    {
        var ratio = new Ratio(num, den);
        Console.WriteLine("{0}/{1} = {2}",
            ratio.Numerator, ratio.Denominator,
            ratio.Value.ToString(CultureInfo.InvariantCulture));
    }
}

public class Ratio
{
    public Ratio(int num, int den)
    {
        if (den <= 0) throw new ArgumentException();
        Denominator = den;
        Numerator = num;
        Value = (double) num / den;
    }

    public readonly int Numerator; //числитель
    public readonly int Denominator; //знаменатель
    public readonly double Value; //значение дроби Numerator / Denominator
}