namespace SortedWords;

class Program
{
    public static void Main()
    {
        var vocabulary = GetSortedWords(
            "Hello, hello, hello, how low",
            "",
            "With the lights out, it's less dangerous",
            "Here we are now; entertain us",
            "I feel stupid and contagious",
            "Here we are now; entertain us",
            "A mulatto, an albino, a mosquito, my libido...",
            "Yeah, hey"
        );

        foreach (var word in vocabulary)
            Console.WriteLine(word);
    }

    public static string[] GetSortedWords(params string[] textLines)
    {
        return textLines
            .SelectMany(s => s.Split(new[] { ' ', ',', '.', '\'', ';' }
                , StringSplitOptions.RemoveEmptyEntries 
                | StringSplitOptions.TrimEntries))
            .Select(s => s.ToLower())
            .Distinct()
            .OrderBy(s => s)
            .ToArray();
    }

    
}
