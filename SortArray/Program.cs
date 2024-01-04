namespace SortArray
{

    // не работает. Надо доделвывать
    static class Program
    {
        public static void Main(string[] args)
        {
            var array = new[] { 0.0, 2.4, -1.0, 20.5, 30.6, 30.6 };
            foreach (var d in array.Sort())
            {
                Console.WriteLine(d);
            }
        }

        private static double[] Sort(this double[] array)
        {
            var length = array.Length;
            if (length == 1) return array;
            var middle = length / 2;
            var leftArray = array[..middle];
            var rightArray = array[middle..length];
            return Merge(leftArray.Sort(), rightArray.Sort());
        }

        private static double[] Merge(double[] leftArray, double[] rightArray)
        {
            if (leftArray.Length == 0) return rightArray;
            if (rightArray.Length == 0) return leftArray;
            return leftArray[0] < rightArray[0]
                ? Concat(leftArray[0], Merge(leftArray[1..], rightArray))
                : Concat(rightArray[0], Merge(leftArray, rightArray[1..]));
        }

        private static double[] Concat(double start, double[] rightArray)
        {
            var array = new double[rightArray.Length + 1];
            array[0] = start;
            for (var i = 1; i < rightArray.Length; i++)
                array[i] = rightArray[i];

            return array;
        }
    }
}