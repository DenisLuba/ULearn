class Program
{
    public static void Main()
    {
        foreach (var number in GenerateCycle(4).Take(8))
        {
            Console.WriteLine(number);
        }
    }

    public static IEnumerable<int> GenerateCycle(int maxValue)
    {
        int i = 0;
        while (i < maxValue)
        {
            yield return i++;
            if (i == maxValue) i = 0;
        }
    }
}
