using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AreaTriangleLib.Tests
{
    [TestClass]
    public class MyAreaTests
    {
        [TestMethod]
        public void Area_10and20_100returned()
        {
            //arrange
            int bottom = 10;
            int height = 20;
            int expected = 100;
            //act
            MyArea s = new MyArea();
            int actual = s.Area(bottom, height);
            //assert
            Assert.AreEqual(expected,actual);
        }
    }
}
