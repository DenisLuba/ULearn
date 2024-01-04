namespace MakeCombinations
{
    class Program
    {
        static void MakeCombinations(bool[] combination, int elementsLeft, int position)
        {
            if (elementsLeft == 0)
            {
                foreach (var c in combination)
                    Console.Write(c ? 1 : 0);
                Console.WriteLine();
                return;
            }
            if (position == combination.Length)
                return;

            combination[position] = true;
            MakeCombinations(combination, elementsLeft - 1, position + 1);
            combination[position] = false;
            MakeCombinations(combination, elementsLeft, position + 1);
        }

        public static void Main()
        {
            MakeCombinations(new bool[5], 3, 0);
        }
    }
}