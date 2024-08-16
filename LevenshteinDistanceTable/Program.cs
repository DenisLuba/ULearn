namespace LevenshteinDistanceTable;

class Program
{
    public static void Main()
    {
        Console.WriteLine(LevenshteinDistance("yabx", "abcd"));
    }
    
    public static int LevenshteinDistance(string first, string second)
    {
        var opt = new int[second.Length + 1, first.Length + 1];
        for (var i = 0; i <= second.Length; ++i) opt[i, 0] = i;
        for (var i = 0; i <= first.Length; ++i) opt[0, i] = i;
        for (var i = 1; i <= second.Length; ++i)
            for (var j = 1; j <= first.Length; ++j)
            {
                if (second[i - 1] == first[j - 1])
                    opt[i, j] = opt[i - 1, j - 1];
                else
                {
                    var deleteChar = 1 + opt[i - 1, j];
                    var addChar = 1 + opt[i, j - 1];
                    var replaceChar = 1 + opt[i - 1, j - 1];

                    opt[i, j] = Math.Min(Math.Min(deleteChar, addChar), replaceChar);
                }
                    
            }

        
        for (var i = 0; i <= second.Length; ++i)
            Console.Write("\t" + string.Concat(second.Take(i)));
        Console.WriteLine("\n");

        for (var y = 0; y <= second.Length; y++)
        {
            Console.Write(string.Concat(first.Take(y)));
            for (var x = 0; x <= first.Length; x++)
                Console.Write("\t" + opt[x, y]);

            Console.WriteLine("\n");
        }

        return opt[second.Length, first.Length];

    }
}
