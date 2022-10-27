using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMath;
using System;

namespace MathTests
{
    [TestClass]
    public class MyMathUnitTests
    {
        [TestMethod]
        public void BasicRooterTest()
        {
            //Create a instance to test
            Rooter rooter = new Rooter();

            double expectedResult = 2.0;
            double input = expectedResult * expectedResult;

            double actualResult = rooter.SquareRoot(input);

            //delta is the expected accuracy
            Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 100);

        }

        [TestMethod]
        public void RooterValueRange()
        {
            Rooter rooter = new Rooter();

            //Try a range of values
            // 1e-8 = 0.00000001 decimal
            // 1e+8 = 100000000 decimal
            for (double expected = 1e-8; expected  < 1e+8; expected *= 3.2)
            {
                RooterOneValue(rooter, expected);
            }
        }

        private void RooterOneValue(Rooter rooter, double expectedResult)
        {
            double input = expectedResult * expectedResult;
            double actualResult = rooter.SquareRoot(input);
            Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 100);
        }

        [TestMethod]
        public void RooterTestNegativeInput()
        {
            Rooter rooter = new Rooter();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => rooter.SquareRoot(-1));
        }
    }
}