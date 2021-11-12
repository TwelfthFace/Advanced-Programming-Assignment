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
        //test the parser to see if it can draw a rectangle.
        public void TestDrawRectangleMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("rectangle 500,500"));
        }
        [TestMethod]
        //test to see if the parser can identify when a non-numeric parameter is inputed.
        public void TestDrawRectangleIncorrectParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("rectangle 500,x"));
        }
        [TestMethod]

        //test to see if the parser can identify when a parameter is missing.
        public void TestDrawRectangleMissingParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("rectangle"));
        }

        // triangle testing functions
        [TestMethod]
        //test the parser to see if it can draw a triangle.
        public void TestDrawTriangleMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("triangle 500"));
        }
        [TestMethod]
        //test to see if the parser can identify when a non-numeric parameter is inputed.
        public void TestDrawTriangleIncorrectParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("triangle x"));
        }
        [TestMethod]
        //test to see if the parser can identify when a parameter is missing.
        public void TestDrawTriangleMissingParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("triangle"));
        }
        [TestMethod]
        //test the parser to see if it can draw a triangle via specified points.
        public void TestDrawTrianglePointsMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("triangle 500,400,200"));
        }
        [TestMethod]
        //test to see if the parser can identify when a non-numeric parameter is inputed.
        public void TestDrawTrianglePointsIncorrectParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("triangle 500,x,200"));
        }
        [TestMethod]
        //test to see if the parser can identify when a parameter is missing.
        public void TestDrawTrianglePointsMissingParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("triangle 500,200"));
        }

        //circle testing functions
        [TestMethod]
        //test the parser to see if it can draw a circle.
        public void TestDrawCircleMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("circle 500"));
        }
        [TestMethod]
        //test to see if the parser can identify when a non-numeric parameter is inputed.
        public void TestDrawCircleIncorrectParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("circle x"));
        }
        [TestMethod]
        //test to see if the parser can identify when a parameter is missing.
        public void TestDrawCircleMissingParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("circle"));
        }

        //drawto testing functions
        [TestMethod]
        //testing to see if the parser can draw a line between specified points.
        public void TestDrawToMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("drawto 500,200"));
        }
        [TestMethod]
        //test to see if the parser can identify when a non-numeric parameter is inputed.
        public void TestDrawToIncorrectParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("drawto 500,x"));
        }
        [TestMethod]
        //test to see if the parser can identify when a parameter is missing.
        public void TestDrawToMissingParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("drawto 500,"));
        }

        //pen testing functions
        [TestMethod]
        //test to see if the default pen is configured as expected.
        public void TestPenDefaultSettingMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.AreEqual(form1.cmd.draw.getPen().Color, Color.Black);
            Assert.AreEqual(form1.cmd.draw.getPen().Width, 3);
        }
        [TestMethod]
        //test to see if the parser can set the pen colour to black
        public void TestPenColorBlackMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("pen black"));
            Assert.AreEqual(form1.cmd.draw.getPen().Color, Color.Black);
        }
        [TestMethod]
        //test to see if the parser can set the pen colour to green
        public void TestPenColorGreenMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("pen green"));
            Assert.AreEqual(form1.cmd.draw.getPen().Color, Color.Green);
        }
        [TestMethod]
        //test to see if the parser can set the pen colour to blue
        public void TestPenColorBlueMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("pen blue"));
            Assert.AreEqual(form1.cmd.draw.getPen().Color, Color.Blue);
        }
        [TestMethod]
        //test to see if the parser can set the pen colour to red
        public void TestPenColorRedMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("pen red"));
            Assert.AreEqual(form1.cmd.draw.getPen().Color, Color.Red);
        }
        [TestMethod]
        //test to see if the parser can set the pen colour to yellow
        public void TestPenColorYellowMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("pen yellow"));
            Assert.AreEqual(form1.cmd.draw.getPen().Color, Color.Yellow);
        }
        [TestMethod]
        //test to see if the parser can set the pen colour to green and set the pen width to 10
        public void TestPenColorOptionalParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("pen green,10"));
            Assert.AreEqual(form1.cmd.draw.getPen().Color, Color.Green);
            Assert.AreEqual(form1.cmd.draw.getPen().Width, 10);
        }
        [TestMethod]
        //test to see if the parser can identify an invalid colour.
        public void TestPenColorInvalidColourMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("pen x"));
        }
        [TestMethod]
        //test to see if the parser can identify a missing parameter.
        public void TestPenColorIncorrectParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("pen green,x"));
        }

        //moveto testing functions
        [TestMethod]
        //testing to see if the parser can correctly set pen position.
        public void TestMoveToMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("moveto 500,400"));
            Assert.AreEqual(form1.cmd.draw.getTurtleX(), 500);
            Assert.AreEqual(form1.cmd.draw.getTurtleY(), 400);
        }
        [TestMethod]
        //testing to see if the parser can correctly set pen position incrementally.
        public void TestMoveToAppendMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("moveto 20"));
            Assert.AreEqual(form1.cmd.draw.getTurtleX(), 20);
            Assert.AreEqual(form1.cmd.draw.getTurtleY(), 20);
        }
        [TestMethod]
        //testing to see if the default pen position is 0, 0.
        public void TestMoveToDefaultSettingMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.AreEqual(form1.cmd.draw.getTurtleX(), 0);
            Assert.AreEqual(form1.cmd.draw.getTurtleY(), 0);
        }
        [TestMethod]
        //test to see if the parser can identify a non-numeric parameter.
        public void TestMoveToIncorrectParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("moveto 500,x"));
        }

        //fill testing functions
        [TestMethod]
        //test to see if the default setting for filling shapes is false.
        public void TestFillDefaultSettingMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.draw.getFillShapes());
        }
        [TestMethod]
        //test to see if the parser can set the fill flag via the "1" parameter
        public void TestFill1ParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("fill 1"));
            Assert.IsTrue(form1.cmd.draw.getFillShapes());
        }
        [TestMethod]
        //test to see if the parser can set the fill flag via the "true" parameter
        public void TestFillTrueParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("fill true"));
            Assert.IsTrue(form1.cmd.draw.getFillShapes());
        }
        [TestMethod]
        //test to see if the parser can set the fill flag via the "false" parameter
        public void TestFillTFalseParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("fill false"));
            Assert.IsFalse(form1.cmd.draw.getFillShapes());
        }
        [TestMethod]
        //test to see if the parser can set the fill flag via the "0" parameter
        public void TestFill0ParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.cmd.parser("fill 0"));
            Assert.IsFalse(form1.cmd.draw.getFillShapes());
        }
        [TestMethod]
        //test to see if the parser can identify an unexpected parameter
        public void TestFillInvalidParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("fill x"));
        }
        [TestMethod]
        //test to see if the parser can identify a missing parameter
        public void TestFillMissingParameterMethod()
        {
            Advanced_Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.cmd.parser("fill"));
        }
    }
}
