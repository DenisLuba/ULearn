namespace MiddleOfThree
{
    internal class Program
    {
        public static object MiddleOfThree(object a, object b, object c)
        {
            var list = new List<IComparable>
            {
                (IComparable)a,
                (IComparable)b,
                (IComparable)c
            };
            list.Sort();
            return list[1];
        }
    }

    public class Tests
    {
        [TestCase(1, 2, 3, 2)]
        [TestCase(2, 5, 4, 4)]
        [TestCase(3, 1, 2, 2)]
        [TestCase(3,5, 9, 5)]
        [TestCase("B", "Z", "A", "B")]
        [TestCase(3.45, 2.67, 3.12, 3.12)]
        public void MiddleOfThreeTest(object a, object b, object c, object result)
        {
            var middle = Program.MiddleOfThree(a, b, c);
            Assert.AreEqual(result, middle);
        }
    }
}