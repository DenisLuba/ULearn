namespace BenfordStatistics
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
        }

        public static int[] GetBenfordStatistics(string text)
        {
            var statistics = new int[10];
            for (var i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]) && (i == 0 || !char.IsDigit(text[i - 1])))
                    statistics[text[i] - '0']++;
            }

            return statistics;
        }
    }
}