namespace MakeSubsets
{
    class Program
    {
        public static void Main()
        {
            WriteAllWordsOfSize(1);
            WriteAllWordsOfSize(2);
            WriteAllWordsOfSize(0);
            WriteAllWordsOfSize(4);
        }

        static void WriteAllWordsOfSize(int size)
        {
            MakeSubsets(new char[size]);
        }

        static void MakeSubsets(char[] subset, int position = 0)
        {
            var result = MakeSubsets(new[] { 'a', 'b', 'c' }, subset, new List<string>(), position);
            foreach (var line in result)
            {
                Console.WriteLine(line);
            }
        }

        private static List<string> MakeSubsets(char[] chars, char[] subset, List<string> result, int position = 0)
        {
            if (position == 0) Array.Sort(chars);
            if (position == subset.Length)
                result.Add(new string(subset));
            else
                foreach (var ch in chars)
                {
                    subset[position] = ch;
                    result = MakeSubsets(chars, subset, result, position + 1);
                }

            return result;
        }
    }
}