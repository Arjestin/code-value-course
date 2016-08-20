using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Backgammon.Test
{
    [TestClass]
    public class TempTest
    {
        [TestMethod]
        public void TempTest_01()
        {
            var x = 1;
            if (x == 1)
            {
                x = 2;
            }
            if (x == 2)
            {
                x = 3;
            }
            Assert.AreEqual(3, x);
        }

        [TestMethod]
        public void TempTest_02()
        {
            var x = 1;
            if (x == 1)
            {
                x = 2;
            }
            else if (x == 2)
            {
                x = 3;
            }
            Assert.AreEqual(2, x);
        }

        [TestMethod]
        public void TempTest_03()
        {
            var x = 1;
            switch (x)
            {
                case 1:
                    x = 2;
                    break;
                case 2:
                    x = 3;
                    break;
            }
            Assert.AreEqual(2, x);
        }
    }
}
