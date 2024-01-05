namespace BubbleSortRange;

public class ProgramTest
{
    public static void BubbleSortRange(int[] array, int left, int right)
    {
        left = left >= 0 && left < array.Length ? left : 0;
        right = right >= 0 && right < array.Length ? right : array.Length - 1;
        for (var i = left; i <= right; i++)
            for (var j = left; j < right; j++)
                if (array[j] > array[j + 1])
                    (array[j + 1], array[j]) = (array[j], array[j + 1]);
    }
}

[TestFixture]
public class Tests
{
    [TestCase(new int[] { }, 1, 2, new int[] { })]
    [TestCase(new[] { 4, 3, 2, 1 }, 1, 2, new[] { 4, 2, 3, 1 })]
    [TestCase(new[] { 4, 3, 2, 1 }, 0, 2, new[] { 2, 3, 4, 1 })]
    [TestCase(new[] { 4, 3, 2, 1 }, 2, 3, new[] { 4, 3, 1, 2 })]
    [TestCase(new[] { 4, 3, 2, 1 }, 0, 12, new[] { 1, 2, 3, 4 })]
    [TestCase(new[] { 4, 3, 2, 1 }, 0, 0, new[] { 4, 3, 2, 1 })]
    public void TestBubbleSortRange(int[] array, int left, int right, int[] result)
    {
        ProgramTest.BubbleSortRange(array, left, right);
        Assert.That(result, Is.EqualTo(array));
    }
}
