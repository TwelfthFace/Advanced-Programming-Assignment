using Microsoft.VisualStudio.TestTools.UnitTesting;
using Advanced_Programming_Assignment;
using System.Drawing;

namespace Advanced_Programming_Assignment.TestProject
{
    [TestClass]
    public class UnitTest1
    {
        // rectangle testing functions
        [TestMethod]
        public void TestDrawRectangleMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("rectangle 500,500"));
        }
        [TestMethod]
        public void TestDrawRectangleIncorrectParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("rectangle 500,x"));
        }
        [TestMethod]
        public void TestDrawRectangleMissingParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("rectangle"));
        }

        // triangle testing functions
        [TestMethod]
        public void TestDrawTriangleMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("triangle 500"));
        }
        [TestMethod]
        public void TestDrawTriangleIncorrectParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("triangle x"));
        }
        [TestMethod]
        public void TestDrawTriangleMissingParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("triangle"));
        }
        [TestMethod]
        public void TestDrawTrianglePointsMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("triangle 500,400,200"));
        }
        [TestMethod]
        public void TestDrawTrianglePointsIncorrectParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("triangle 500,x,200"));
        }
        [TestMethod]
        public void TestDrawTrianglePointsMissingParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("triangle 500,200"));
        }

        //circle testing functions
        [TestMethod]
        public void TestDrawCircleMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("circle 500"));
        }
        [TestMethod]
        public void TestDrawCircleIncorrectParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("circle x"));
        }
        [TestMethod]
        public void TestDrawCircleMissingParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("circle"));
        }

        //drawto testing functions
        [TestMethod]
        public void TestDrawToMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("drawto 500,200"));
        }
        [TestMethod]
        public void TestDrawToIncorrectParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("drawto 500,x"));
        }
        [TestMethod]
        public void TestDrawToMissingParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("drawto 500,"));
        }

        //pen testing functions
        // black green blue red yellow
        [TestMethod]
        public void TestPenDefaultSettingMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.AreEqual(form1.cmd.draw.getPen().Color, Color.Black);
            Assert.AreEqual(form1.cmd.draw.getPen().Width, 3);
        }
        [TestMethod]
        public void TestPenColorBlackMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("pen black"));
            Assert.AreEqual(form1.cmd.draw.getPen().Color, Color.Black);
        }
        [TestMethod]
        public void TestPenColorGreenMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("pen green"));
            Assert.AreEqual(form1.cmd.draw.getPen().Color, Color.Green);
        }
        [TestMethod]
        public void TestPenColorBlueMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("pen blue"));
            Assert.AreEqual(form1.cmd.draw.getPen().Color, Color.Blue);
        }
        [TestMethod]
        public void TestPenColorRedMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("pen red"));
            Assert.AreEqual(form1.cmd.draw.getPen().Color, Color.Red);
        }
        [TestMethod]
        public void TestPenColorYellowMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("pen yellow"));
            Assert.AreEqual(form1.cmd.draw.getPen().Color, Color.Yellow);
        }
        [TestMethod]
        public void TestPenColorOptionalParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("pen green,10"));
            Assert.AreEqual(form1.cmd.draw.getPen().Color, Color.Green);
            Assert.AreEqual(form1.cmd.draw.getPen().Width, 10);
        }
        [TestMethod]
        public void TestPenColorInvalidColourMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("pen x"));
        }
        [TestMethod]
        public void TestPenColorIncorrectParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("pen green,x"));
        }

        //moveto testing functions
        [TestMethod]
        public void TestMoveToMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("moveto 500,400"));
            Assert.AreEqual(form1.cmd.draw.getTurtleX(), 500);
            Assert.AreEqual(form1.cmd.draw.getTurtleY(), 400);
        }
        [TestMethod]
        public void TestMoveToDefaultSettingMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.AreEqual(form1.cmd.draw.getTurtleX(), 0);
            Assert.AreEqual(form1.cmd.draw.getTurtleY(), 0);
        }
        [TestMethod]
        public void TestMoveToIncorrectParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("moveto 500,x"));
        }

        //fill testing functions
        [TestMethod]
        public void TestFillDefaultSettingMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.draw.getFillShapes());
        }
        [TestMethod]
        public void TestFill1ParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("fill 1"));
            Assert.IsTrue(form1.cmd.draw.getFillShapes());
        }
        [TestMethod]
        public void TestFillTrueParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("fill true"));
            Assert.IsTrue(form1.cmd.draw.getFillShapes());
        }
        [TestMethod]
        public void TestFillTFalseParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("fill false"));
            Assert.IsFalse(form1.cmd.draw.getFillShapes());
        }
        [TestMethod]
        public void TestFill0ParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("fill 0"));
            Assert.IsFalse(form1.cmd.draw.getFillShapes());
        }
        [TestMethod]
        public void TestFillInvalidParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("fill x"));
        }
        [TestMethod]
        public void TestFillMissingParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("fill"));
        }
    }
}
