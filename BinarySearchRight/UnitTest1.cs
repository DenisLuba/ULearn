namespace BinarySearchRight;
class Program
{
    public static int BinSearchRightBorder(long[] array, long value, int left, int right)
    {
        if (array.Length == 0) return 0;
        left = left <= 0 || left >= array.Length ? 0 : left;
        right = right <= 0 || right >= array.Length ? array.Length - 1 : right;
        while (left < right)
        {
            var middle = left + (right - left) / 2;
            if (array[middle] > value)
                right = middle - 1;
            else left = middle + 1;
        }
        right = right < 0 ? 0 : right;
        return array[right] > value ? right : right + 1;
    }
}

[TestFixture]
class BinarySearchTest
{
    [TestCase(new long[] { 2, 4, 4, 6 }, 1, 0)]
    [TestCase(new long[] { 2, 4, 4, 6 }, 2, 1)]
    [TestCase(new long[] { 2, 4, 4, 6 }, 3, 1)]
    [TestCase(new long[] { 2, 4, 4, 6 }, 4, 3)]
    [TestCase(new long[] { 2, 4, 4, 6 }, 5, 3)]
    [TestCase(new long[] { 2, 4, 4, 6 }, 6, 4)]
    [TestCase(new long[] { 2, 4, 4, 6 }, 7, 4)]
    [TestCase(new long[] { }, 1, 0)]
    [TestCase(new long[] { 0, 1, 2, 3, 4, 5, 6, 7, 9, 9, 10, 11, 12 }, 8, 8)]
    [TestCase(new long[] { 2, 2, 2, 2 }, 1, 0)]

    public void BinSearchRightBorderTest(long[] array, long value, int expected)
    {
        var result = Program.BinSearchRightBorder(array, value, -1, array.Length);
        Assert.That(result, Is.EqualTo(expected));
    }
}