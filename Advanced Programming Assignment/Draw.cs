using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Advanced_Programming_Assignment
{
    public class Draw : Command
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

        public Draw() { }

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

        public void moveTo(int z)
        {
            this.turtle.x += z;
            this.turtle.y += z;
        }

        public void drawRectangle(int width, int length)
        {
            Shape rec = new ShapeFactory().getShape("rectangle");
            rec.set(penColour, (int)(this.clipbound.X + this.pen.Width) - 1 + this.turtle.x, this.turtle.y + (int)this.pen.Width + 12, pen.Width, width, length);
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

        public void drawCircle(int radius)
        {
            Shape circ = new ShapeFactory().getShape("circle");
            circ.set(penColour, (int)this.clipbound.X + this.turtle.x + 3, 20 + this.turtle.y - 5, pen.Width, radius);
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

        public void drawTriangle(int size)
        {
            Shape tri = new ShapeFactory().getShape("triangle");
            tri.set(penColour, (int)this.clipbound.X + this.turtle.x + 3, (int)this.clipbound.Y + 20 +  this.turtle.y - 5, pen.Width, size);
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

        public void drawTriangle(int a, int b, int c)
        {
            Shape tri = new ShapeFactory().getShape("triangle");
            tri.set(penColour, (int)(this.clipbound.X + this.turtle.x) + 3, 20 + ((int)this.clipbound.Y + 20 + this.turtle.y) - 5, pen.Width, a, b, c);
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
    }
}
