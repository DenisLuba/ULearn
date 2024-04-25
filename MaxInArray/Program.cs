


namespace MaxInArray
{

    class Program
    {

        public static T? Max<T>(T[] source) where T : IComparable
        {
            if (source.Length == 0)
                return default(T);

            var result = source[0];
            foreach (var item in source)
            {
                if (item.CompareTo(result) > 0)
                    result = item;
            }
            return result;
        }
    }

    [TestFixture]
    class Test
    {
        [TestCase(new int[0], 0)]
        [TestCase(new[] { 3 }, 3)]
        [TestCase(new[] { 3, 1, 2 }, 3)]

        public static void TesIntMaxInArray(int[] source, int max)
        {
            Assert.That(max, Is.EqualTo(Program.Max(source)));
        }

        [TestCase(new[] { "A", "B", "C" }, "C")]
        public static void TestStringMaxInArray(string[] source, string max)
        {
            Assert.That(max, Is.EqualTo(Program.Max(source)));
        }
    }
}