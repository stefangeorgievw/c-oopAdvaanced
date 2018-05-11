using NUnit.Framework;
using System;

namespace HackTests
{
    public class HackTests
    {
        [Test]
        public void MathAbsDecimalShouldWorkCorrectly()
        {
            decimal expectedDecimal = 1000.0m;
            decimal actualDecimal = Math.Abs(-1000.0m);

            Assert.AreEqual(expectedDecimal, actualDecimal);
        }

        [Test]
        public void MathAbsDoubleShouldWorkCorrectly()
        {
            double expectedDouble = 100.0d;
            double actualDouble = Math.Abs(-100.0d);

            Assert.AreEqual(expectedDouble, actualDouble);

            double expectedPositiveDouble = 100.0d;
            double actualPositiveDouble = Math.Abs(100.0d);

            Assert.AreEqual(expectedPositiveDouble, actualPositiveDouble);
        }

        [Test]
        public void MathFloorDoublePositiveShouldWorkCorrectly()
        {
            double expectedPositiveDouble = 100.0d;
            double actualPositiveDouble = Math.Floor(100.897d);

            Assert.AreEqual(expectedPositiveDouble, actualPositiveDouble);
        }

        [Test]
        public void MathFloorDoubleNegativeShouldWorkCorrectly()
        {
            double expectedNegativeDouble = -1001.0d;
            double actualNegativeDouble = Math.Floor(-1000.897d);

            Assert.AreEqual(expectedNegativeDouble, actualNegativeDouble);
        }

        [Test]
        public void MathFloorDecimalPositiveShouldWorkCorrectly()
        {
            decimal expectedPositiveDecimal = 100.0m;
            decimal actualPositiveDecimal = Math.Floor(100.897m);

            Assert.AreEqual(expectedPositiveDecimal, actualPositiveDecimal);
        }

        [Test]
        public void MathFloorDecimalNegativeShouldWorkCorrectly()
        {
            decimal expectedNegativeDecimal = -1001.0m;
            decimal actualNegativeDecimal = Math.Floor(-1000.897m);

            Assert.AreEqual(expectedNegativeDecimal, actualNegativeDecimal);
        }
    }
}
