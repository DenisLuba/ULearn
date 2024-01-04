namespace ReversedArray

{
    class Program
    {
        public static void WriteReversed(char[] items, int startIndex = 0)
        {
            if (startIndex < items.GetUpperBound(0))
                WriteReversed(items, startIndex + 1);
            if (startIndex < items.Length) Console.Write(items[startIndex]);
        }

        public static void Main(string[] args)
        {
            var ch = new char[] { 'a', 'b' };
            WriteReversed(ch);
        }
    }
}