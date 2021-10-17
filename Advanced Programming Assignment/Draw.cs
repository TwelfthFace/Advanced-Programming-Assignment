using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Advanced_Programming_Assignment
{
    class Draw : Command
    {

        protected Turtle turtle;
        protected bool penDown;
        protected bool fillShapes;
        protected Pen pen = new Pen(Color.Black, 3);
        protected SolidBrush brush = new SolidBrush(Color.Black);

        protected struct Turtle
        {
            public int x;
            public int y;
            public Pen turtleColour;
        }

        public Draw(Graphics g)
        {
            this.graphicsContext = g;
            this.clipbound = g.ClipBounds;
            this.penDown = false;
            this.fillShapes = false;

            turtle = new Turtle
            {
                x = 0,
                y = 0,
                turtleColour = this.pen
            };
        }

        public bool getPendown()
        {
            return this.penDown;
        }

        public void setPendown(bool value)
        {
            this.penDown = value;
        }

        public Pen getPen()
        {
            return this.pen;
        }

        public bool getFillShapes()
        {
            return this.fillShapes;
        }

        public void setFillShapes(bool value)
        {
            this.fillShapes = value;
        }

        public void setPenColour(Color col, int size = 3)
        {
            this.pen = new Pen(col, size);
        }

        public void moveTo(int x, int y)
        {
            turtle.x = x;
            turtle.y = y;
        }

        public void DrawRectangle(int width, int length, int penSize = 3)
        {
            graphicsContext.DrawRectangle(pen, ((this.clipbound.X + penSize) - 1) + turtle.x, turtle.y + penSize + 12, width, length);
        }

        public void DrawCircle(int radius)
        {
            Rectangle rect = new Rectangle((int)clipbound.X + turtle.x, 20 + turtle.y, radius, radius);
            this.graphicsContext.DrawEllipse(pen, rect);
        }

        public void DrawTriangle(int size)
        {
            SolidBrush brush = new SolidBrush(Color.Blue);
            Point[] points = 
            {
                //top point
                new Point(((int)clipbound.X + 55) + turtle.x, (20 - size) + turtle.y),
                //left point
                new Point(((int)clipbound.X + 10 - size) + turtle.x, (100) + turtle.y),
                //right point
                new Point(((int)clipbound.X + 100 + size) + turtle.x, 100 + turtle.y)
            };
            graphicsContext.DrawPolygon(pen, points);
        }
    }
}
