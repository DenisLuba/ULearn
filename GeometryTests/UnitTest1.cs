using Geometry;

namespace GeometryTests
{
    [TestFixture]
    public class Tests
    {
        [TestCase(-1, -1, 0, 0, 2, 2, false)]
        [TestCase(1, -1, 0, 0, 2, 2, false)]
        [TestCase(-1, 1, 0, 0, 2, 2, false)]
        [TestCase(1, 1, 0, 0, 2, 2, true)]
        [TestCase(0, -1, 0, 0, 2, 2, false)]
        [TestCase(0, 0, 0, 0, 2, 2, true)]
        [TestCase(-2, 2, 0, 0, 2, 2, false)]
        [TestCase(2, 2, 0, 0, 2, 2, true)]
        public static void IsVectorInSegmentTest(double vectorX, double vectorY, double beginX, double beginY, double endX, double endY, bool result)
        {
            Vector vector = new() { X = vectorX, Y = vectorY };
            Segment segment = new()
            {
                Begin = new Vector { X = beginX, Y = beginY },
                End = new Vector { X = endX, Y = endY }
            };

            Assert.That(Geometry.Geometry.IsVectorInSegment(vector, segment), Is.EqualTo(result));
        }
    }
}