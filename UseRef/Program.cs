class Program
{
    public static void Main()
    {
        WriteAllNumbersFromText("abc123def45gh ij67jf");
    }

    public static void SkipSpaces(string text, ref int pos)
    {
        while (pos < text.Length && char.IsWhiteSpace(text[pos]))
            pos++;
    }

    public static string ReadNumber(string text, ref int pos)
    {
        var start = pos;
        while (pos < text.Length && char.IsDigit(text[pos]))
            pos++;
        return text.Substring(start, pos - start);
    }

    public static void SkipLetters(string text, ref int pos)
    {
        while (pos < text.Length && char.IsLetter(text[pos])) 
            pos++;
    }

    public static void WriteAllNumbersFromText(string text)
    {
        int pos = 0;
        while (true)
        {
            SkipSpaces(text, ref pos);
            SkipLetters(text, ref pos);
            var num = ReadNumber(text, ref pos);
            SkipLetters(text, ref pos);
            if (num == "") break;
            Console.Write(num + " ");
        }
        Console.WriteLine();

    }
}
