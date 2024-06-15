using System.Reflection.Metadata.Ecma335;

namespace TakeMethod
{
    [TestFixture]
    public class Tests
    {
        // delegate of func
        delegate string MyFunc(int[] nums, int count);
        static MyFunc myFunc = (source, count) => string.Join(" ", TakeClass.MyTake(source, count));

        // TestCases
        static string expected_1 = "1 2";
        static int[] enumerable_1 = [1, 2, 3, 4];
        static int count_1 = 2;

        static string expected_2 = "4";
        static int[] enumerable_2 = [4];
        static int count_2 = 1;

        static string expected_3 = "";
        static int[] enumerable_3 = [5];
        static int count_3 = 0;

        static string expected_4 = "1 2";
        static int[] enumerable_4 = [1, 2];
        static int count_4 = 5;


        // TestDataCases
        static IEnumerable<TestCaseData> testDataCases
        { 
            get
            {
                yield return new TestCaseData(enumerable_1, count_1).Returns(expected_1);
                yield return new TestCaseData(enumerable_2, count_2).Returns(expected_2);
                yield return new TestCaseData(enumerable_3, count_3).Returns(expected_3);
                yield return new TestCaseData(enumerable_4, count_4).Returns(expected_4);
            }
        }

        [Test, TestCaseSource(nameof(testDataCases))]
        public string Test(int[] nums, int count) => myFunc(nums, count);
    }

    public class TakeClass
    {
        public static IEnumerable<T?> MyTake<T> (IEnumerable<T> source, int count)
        {
            if (count == 0) yield break;
            foreach (var i in source)
            {
                yield return i;
                if (--count == 0) yield break;
            }
        }
    }
}

