using System.Collections;

namespace MinimumOfThree
{
    internal class Program
    {
        public static object Min(object array)
        {
            Array.Sort((Array)array);
            return ((Array)array).GetValue(0) ?? -1;
        }
    }

    class Book : IComparable
    {
        public string Title;
        public int Theme;

        public int CompareTo(object? obj)
        {
            if (obj is not Book book) return -100;
            var result = Theme.CompareTo(book.Theme);
            return result != 0 ? result
                : string.Compare(Title, book.Title, StringComparison.Ordinal);
        }
    }

    public class Point
    {
        public double X;
        public double Y;
    }

    public static class ArraySortExtensions
    {
        public static void Sort(this Array array, IComparer comparer)
        {
            for (var i = array.Length - 1; i > 0; i--)
                for (var j = 1; j <= i; j++)
                {
                    var e1 = array.GetValue(j - 1);
                    var e0 = array.GetValue(j);
                    if (comparer.Compare(e1, e0) >= 0) continue;
                    var temp = array.GetValue(j);
                    array.SetValue(array.GetValue(j - 1), j);
                    array.SetValue(temp, j - 1);
                }
        }
    }

    public class ClockwiseComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            if (x is null
                || y is null
                || x is not Point pointX
                || y is not Point pointY) return -100;

            var angelX = -Math.Atan2(pointX.Y, -pointX.X);
            var angelY = -Math.Atan2(pointY.Y, -pointY.X);
            return angelX.CompareTo(angelY);
        }
    }

    public class Tests
    {
        [TestCase(2, 3, 6, 2, 4)]
        [TestCase("A", "B", "A", "C", "D")]
        [TestCase('2', '4', '2', '7')]
        public void MinTest(object result, params object[] array)
        {
            Assert.That(Program.Min(array), Is.EqualTo(result));
        }
    }
}