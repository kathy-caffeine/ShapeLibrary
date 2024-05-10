using ShapeLibrary;

namespace ShapeLibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodCircle()
        {
            var c = new List<double> { 1.0 };
            var s = ShapeCreator.CreateShape(c);
            Assert.AreEqual(s.GetArea(), Math.PI);
        }

        [TestMethod]
        public void TestMethodTriangle()
        {
            var c = new List<double> { 3.0, 4.0, 5.0 };
            var s = ShapeCreator.CreateShape(c);
            Assert.AreEqual(s.GetArea(), 6);
        }

        [TestMethod]
        public void TestMethodWrongTriangle()
        {
            var c = new List<double> { 3.0, 2.0, 1.0 };
            var s = ShapeCreator.CreateShape(c);
            Assert.ThrowsException<ArgumentException>(() => s.GetArea());
        }

        [TestMethod]
        public void TestMethodRightAngled()
        {
            var c = new List<double> { 3.0, 4.0, 5.0 };
            var s = (Triangle)ShapeCreator.CreateShape(c);
            Assert.IsTrue(s.IsRigrhAngled());
        }

        [TestMethod]
        public void TestMethodWrongRightAngled()
        {
            var c = new List<double> { 3.0, 2.0, 1.0 };
            var s = (Triangle)ShapeCreator.CreateShape(c);
            Assert.ThrowsException<ArgumentException>(() => s.IsRigrhAngled());
        }

        [TestMethod]
        public void TestMethodWrongFigure0()
        {
            var c = new List<double> { };
            Assert.ThrowsException<ArgumentException>(() => ShapeCreator.CreateShape(c));
        }

        [TestMethod]
        public void TestMethodWrongFigure2()
        {
            var c = new List<double> { 1.0, 1.0 };
            Assert.ThrowsException<ArgumentException>(() => ShapeCreator.CreateShape(c));
        }

        [TestMethod]
        public void TestMethodNegative()
        {
            var c = new List<double> { -1.0, 1.0, 1.0 };
            Assert.ThrowsException<ArgumentException>(() => ShapeCreator.CreateShape(c));
        }
    }
}