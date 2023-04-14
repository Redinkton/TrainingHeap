using TrainingHeap;

namespace Heapa.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SeatManager a = new SeatManager(5);
            var b1 = a.Reserve();
            var b2 = a.Reserve();
            a.Unreserve(2);
            var b3 = a.Reserve();
            var b4 = a.Reserve();
            var b5 = a.Reserve();
            var b6 = a.Reserve();
            a.Unreserve(5);
        }
    }
}