using Microsoft.VisualStudio.TestTools.UnitTesting;
using Advanced_Programming_Assignment;
using System.Drawing;

namespace Advanced_Programming_Assignment.TestProject
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestDrawRectangleMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("rectangle 500 500"));
        }
        [TestMethod]
        public void TestDrawTriangleMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("triangle 500"));
        }
        [TestMethod]
        public void TestDrawTrianglePointsMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("triangle 500 400 200"));
        }
        [TestMethod]
        public void TestDrawCircleMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("circle 500"));
        }
    }
}
