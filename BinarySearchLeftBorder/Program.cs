using NUnit.Framework;

namespace BinarySearchLeftBorder;

class Program
{
    public static int BinSearchLeftBorder(long[] array, long value, int left, int right)
    {
        if (left >= right) return left;
        var m = (left + right) / 2;
        if (array[m] < value)
            return BinSearchLeftBorder(array, value, m, right);
        return BinSearchLeftBorder(array, value, left, m - 1);
    }
}

[TestFixture]
class BinarySearchTest
{
    [TestCase(new long[] { 2, 4, 4, 6 }, 1, -1)]
    [TestCase(new long[] { 2, 4, 4, 6 }, 2, -1)]
    [TestCase(new long[] { 2, 4, 4, 6 }, 3, 0)]
    [TestCase(new long[] { 2, 4, 4, 6 }, 4, 0)]
    [TestCase(new long[] { 2, 4, 4, 6 }, 5, 2)]
    [TestCase(new long[] { 2, 4, 4, 6 }, 6, 2)]
    [TestCase(new long[] { 2, 4, 4, 6 }, 7, 3)]
    [TestCase(new long[] { }, 1, -1)]

    public void BinSearchLeftBorderTest(long[] array, long value, int expected)
    {
        var result = Program.BinSearchLeftBorder(array, value, -1, array.Length);
        Assert.AreEqual(expected, result);
    }
}
