using NUnit.Framework;

namespace BinarySearchLeft;

class Program
{
    public static int BinSearchLeftBorder(long[] array, long value, int left, int right)
    {
        if (array.Length == 0) return -1;
        left = left <= 0 || left >= array.Length ? 0 : left;
        right = right <= 0 || right >= array.Length ? array.Length - 1 : right;
        return BinarySearchLeftBorder(array, value, left, right);
    }

    public static int BinarySearchLeftBorder(long[] array, long value, int left, int right)
    {
        if (left >= right)
        {
            if (array[left] < value) return left;
            return left - 1;
        }
        var middle = left + (right - left) / 2;
        return array[middle] < value 
            ? BinarySearchLeftBorder(array, value, middle + 1, right) 
            : BinarySearchLeftBorder(array, value, left, middle - 1);
    }

    //public static int BinSearchLeftBorder(long[] array, long value, int left, int right)
    //{
    //    if (right == left
    //        || (left + right == 1 && right - left == 1)
    //        || array.Length == 0
    //        || left == array.GetUpperBound(0))
    //        return left;
    //    var m = (left + right) / 2;
    //    if (array[m] < value)
    //        return BinSearchLeftBorder(array, value, m, right);
    //    return BinSearchLeftBorder(array, value, left, m - 1);
    //}
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
    [TestCase(new long[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 8, 7)]

    public void BinSearchLeftBorderTest(long[] array, long value, int expected)
    {
        var result = Program.BinSearchLeftBorder(array, value, -1, array.Length);
        Assert.That(result, Is.EqualTo(expected));
    }
}