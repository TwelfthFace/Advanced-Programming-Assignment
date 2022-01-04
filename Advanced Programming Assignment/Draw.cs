using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Advanced_Programming_Assignment
{
    public class Draw : Command
    {

        protected Turtle turtle;
        protected bool fillShapes;
        protected Color penColour;
        protected Pen pen;
        protected SolidBrush brush;

        protected struct Turtle
        {
            public int x;
            public int y;
            public Pen turtleColour;
        }

        public Draw() { }

        public Draw(Canvas canvas)
        {
            this.canvas = canvas;
            this.graphicsContext = canvas.getGraphicsContext();
            this.fillShapes = false;
            this.penColour = Color.Black;
            this.pen = new Pen(penColour, 3);
            this.brush = new SolidBrush(penColour);

            turtle = new Turtle
            {
                x = (int)(0 + pen.Width),
                y = (int)(0 + pen.Width),
                turtleColour = this.pen
            };

        }
        /// <summary>
        /// Returns the currect X setting for the pens position.
        /// </summary>
        /// <returns>value of turtle.x</returns>
        public int getTurtleX()
        {
            return turtle.x;
        }
        /// <summary>
        /// Returns the currect Y setting for the pens position.
        /// </summary>
        /// <returns>value of turtle.y</returns>
        public int getTurtleY()
        {
            return turtle.y;
        }

        /// <summary>
        /// returns the pen that will be drawn with. Used for testing purposes.
        /// </summary>
        /// <returns></returns>
        public Pen getPen()
        {
            return this.pen;
        }

        /// <summary>
        /// Used to check to see if the next shape drawn will be filled or now.
        /// </summary>
        /// <returns>value of fillShapes</returns>
        public bool getFillShapes()
        {
            return this.fillShapes;
        }
        /// <summary>
        /// sets the fillShapes value to either true of false.
        /// </summary>
        /// <param name="value"></param>
        public void setFillShapes(bool value)
        {
            this.fillShapes = value;
        }

        /// <summary>
        /// Sets the pen color to a Color and as an optional specification also accepts a size parameter to set pen width.
        /// Also sets SolidBrush to the same colour in order to keep the colour consistent between filled and non-filled shapes.
        /// </summary>
        /// <param name="col"></param>
        /// <param name="size"></param>
        public void setPenColour(Color col, int size = 3)
        {
            this.penColour = col;
            this.pen = new Pen(penColour, size);
            this.brush = new SolidBrush(penColour);
        }

        /// <summary>
        /// Sets the pen position to the specified values of x and y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void moveTo(int x, int y)
        {
            this.turtle.x = x;
            this.turtle.y = y;
        }

        /// <summary>
        /// Sets the pen position incrementally to the already set positions by value of z.
        /// </summary>
        /// <param name="z"></param>
        public void moveTo(int z)
        {
            this.turtle.x += z;
            this.turtle.y += z;
        }

        /// <summary>
        /// The function that draws a rectangle. It sets the position of the rectangle in relation to the pens x and y setting as well as its width and length.
        /// </summary>
        /// <param name="width">Width of the rectangle.</param>
        /// <param name="height">Height of the rectangle</param>
        public void drawRectangle(int width, int height)
        {
            Shape rec = new ShapeFactory().getShape("rectangle");
            rec.set(penColour, this.turtle.x, this.turtle.y, pen.Width, width, height);
            if (!this.getFillShapes())
            { 
                rec.draw(graphicsContext);
            }
            else
            {
                rec.isFilled(true);
                rec.draw(graphicsContext);
            }
        }

        /// <summary>
        /// The function that draws a circle. It sets the position of the circle in relation to the pens x and y setting as well as its radius.
        /// </summary>
        /// <param name="radius"></param>
        public void drawCircle(int radius)
        {
            Shape circ = new ShapeFactory().getShape("circle");
            circ.set(penColour, this.turtle.x, this.turtle.y, pen.Width, radius);
            if (!this.getFillShapes())
            {
                circ.draw(graphicsContext);
            }
            else
            {
                circ.isFilled(true);
                circ.draw(graphicsContext);
            }
        }

        /// <summary>
        /// The function that draws an equilateral triangle. It sets the position of the triangle in relation to the pens x and y setting as well as its size. 
        /// </summary>
        /// <param name="size"></param>
        public void drawTriangle(int size)
        {
            Shape tri = new ShapeFactory().getShape("triangle");
            tri.set(penColour, this.turtle.x, this.turtle.y, pen.Width, size);
            if (!this.getFillShapes())
            {
                tri.draw(graphicsContext);
            }
            else
            {
                tri.isFilled(true);
                tri.draw(graphicsContext);
            }
        }

        /// <summary>
        /// The function that draws a triangle in accordance to the points specified, the parameters will be added to the triangle default points.
        /// It sets the position of the triangle in relation to the pens x and y setting as well as the points a,b,c specified.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public void drawTriangle(int a, int b, int c)
        {
            Shape tri = new ShapeFactory().getShape("triangle");
            tri.set(penColour, this.turtle.x, this.turtle.y, pen.Width, a,b,c);
            if (!this.getFillShapes())
            {
                tri.draw(graphicsContext);
            }
            else
            {
                tri.isFilled(true);
                tri.draw(graphicsContext);
            }
        }

        /// <summary>
        /// The function that draws a line between the x and y points. It sets the position of the line in relation to the pens x and y setting.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void drawLine(int x, int y)
        {
            graphicsContext.DrawLine(pen, this.turtle.x, this.turtle.y, this.turtle.x + x, this.turtle.y + y);
        }

        public void reset()
        {
            this.turtle.x = (int)(0 + pen.Width);
            this.turtle.y = (int)(0 + pen.Width);
            this.canvas.clearCanvas();
        }

    }
}
