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
        protected Color penColour;
        protected Pen pen;
        protected SolidBrush brush;

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
            this.penColour = Color.Black;
            this.pen = new Pen(penColour, 3);
            this.brush = new SolidBrush(penColour);

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
            this.penColour = col;
            this.pen = new Pen(penColour, size);
            this.brush = new SolidBrush(penColour);
        }

        public void moveTo(int x, int y)
        {
            this.turtle.x = x;
            this.turtle.y = y;
        }

        public void reset()
        {
            this.moveTo(0, 0);
            this.fillShapes = false;
        }

        public void drawRectangle(int width, int length, int penSize = 3)
        {
            if (!this.getFillShapes())
            {
                Rectangle rec = (Rectangle)new ShapeFactory().getShape("rectangle");
                rec.set(penColour, (int)(this.clipbound.X + this.pen.Width) - 1 + this.turtle.x, this.turtle.y + (int)this.pen.Width + 12, width, length);
                rec.draw(graphicsContext);

            }
            else
            {
                //Rectangle rec = (Rectangle)new ShapeFactory(penColour, (int)(this.clipbound.X + this.pen.Width) - 1 + this.turtle.x, this.turtle.y + (int)this.pen.Width + 12, width, length).getShape("rectangle");
                //rec.isFilled(true);
                //rec.draw(graphicsContext);
            }
        }

        //public void drawCircle(int radius)
        //{
        //    Rectangle rect = new Rectangle((int)this.clipbound.X + this.turtle.x + 3, 20 + this.turtle.y - 5, radius, radius);
        //    this.graphicsContext.DrawEllipse(pen, rect);
        //    if (!this.getFillShapes())
        //    {
        //        this.graphicsContext.DrawEllipse(pen, rect);
        //    }
        //    else
        //    {
        //        this.graphicsContext.FillEllipse(brush, rect);
        //    }
        //}

        public void drawTriangle(int size)
        {
            Point[] points = 
            {
                //top point
                new Point(((int)clipbound.X + 55) + this.turtle.x, (20 - size) + this.turtle.y),
                //left point
                new Point(((int)clipbound.X + 10 - size) + this.turtle.x, (100) + this.turtle.y),
                //right point
                new Point(((int)clipbound.X + 100 + size) + this.turtle.x, 100 + this.turtle.y)
            };
            if (!this.getFillShapes())
            {
                graphicsContext.DrawPolygon(pen, points);
            }
            else
            {
                graphicsContext.FillPolygon(brush, points);
            }
        }

        public void drawTriangle(int a, int b, int c)
        {
            Point[] points =
            {
                //top point
                new Point(((int)clipbound.X + 55) + this.turtle.x, (20 - a) + this.turtle.y),
                //left point
                new Point(((int)clipbound.X + 10 - b) + this.turtle.x, (100) + this.turtle.y),
                //right point
                new Point(((int)clipbound.X + 100 + c) + this.turtle.x, 100 + this.turtle.y)
            };
            if (!this.getFillShapes())
            {
                graphicsContext.DrawPolygon(pen, points);
            }
            else
            {
                graphicsContext.FillPolygon(brush, points);
            }
        }
    }
}
