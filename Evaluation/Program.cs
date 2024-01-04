// Алгоритм перебора всех подмножеств и его использование для поиска разбиения множества на части с равной суммой весов.

namespace Evaluation
{
    abstract class Program
    {
        static readonly int[] Weights = new int[] { 2, 5, 6, 2, 4, 7 };

        static void Evaluate(bool[] subset)
        {
            var delta = 0;
            for (int i = 0; i < subset.Length; i++)
                if (subset[i]) delta += Weights[i];
                else delta -= Weights[i];
            foreach (var e in subset)
                Console.Write(e ? 1 : 0);
            Console.Write(" ");
            if (delta == 0)
                Console.Write("OK");
            Console.WriteLine();
        }

        static void MakeSubsets(bool[] subset, int position)
        {
            if (position == subset.Length)
            {
                Evaluate(subset);
                return;
            }
            subset[position] = false;
            MakeSubsets(subset, position + 1);
            subset[position] = true;
            MakeSubsets(subset, position + 1);
        }

        public static void Main()
        {
            MakeSubsets(new bool[Weights.Length], 0);
        }
    }
}