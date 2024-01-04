namespace PoweredArray
{
    internal class Program
    {
        public static void Main(string[] args)
        {

        }
        public static int[] GetPoweredArray(int[] arr, int power)
        {
            var result = new int[arr.Length];
            for (var i = 0; i < arr.Length; i++)
            {
                // result[i] = (int) Math.Pow(arr[i], power);
                result[i] = Pow(arr[i], power);
            }

            return result;
        }

        private static int Pow(int num, int power)
        {
            if (power == 0) return 1;
            var result = num;
            for (var i = 1; i < power; i++)
            {
                result *= num;
            }

            return result;
        }
    }
}