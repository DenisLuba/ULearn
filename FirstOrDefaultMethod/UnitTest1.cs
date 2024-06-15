namespace FirstOrDefaultMethod
{
    //[TestFixture]
    //public class Tests
    //{
    //    private static IEnumerable<TestCaseData> testCases
    //    {
    //        get
    //        {
    //            yield return new TestCaseData(new int[0], x => true).Returns(0);
    //        }
    //    }

    //    [Test, TestCaseSource(nameof(testCases))]
    //    public T? Test<T>(IEnumerable<T> enumerable, Func<T, bool> predicate) => enumerable.MyFirstOrDefault(predicate);
    //}

    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            Assert.That(FirstOrDefaultClass.MyFirstOrDefault(new int[0], x => true), Is.EqualTo(0));
            Assert.That(FirstOrDefaultClass.MyFirstOrDefault(new string[0], x => true), Is.EqualTo(null));
            Assert.That(FirstOrDefaultClass.MyFirstOrDefault(new[] { 1, 2, 3 }, x => x > 2), Is.EqualTo(3));
            Assert.That(FirstOrDefaultClass.MyFirstOrDefault(new[] { 3, 2, 1 }, x => x > 2), Is.EqualTo(3));
            Assert.That(FirstOrDefaultClass.MyFirstOrDefault(new[] { 2, 3, 1 }, x => x > 2), Is.EqualTo(3));
        }
    }
}