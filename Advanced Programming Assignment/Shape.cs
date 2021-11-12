using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Advanced_Programming_Assignment
{
    abstract class Shape : ShapesInterface
    {
        protected Color penColour;
        protected Pen pen;
        protected SolidBrush brush;
        protected int x, y;
        protected bool fill;

        public Shape()
        {
            this.penColour = Color.Red;
            this.pen = new Pen(penColour, 3);
            this.brush = new SolidBrush(penColour);
            x = 0;
            y = 0;
        }

        public Shape(Color colour, int x, int y)
        {
            this.penColour = colour;
            this.pen = new Pen(colour, 3);
            this.brush = new SolidBrush(colour);
            this.x = x;
            this.y = y;
        }

        public virtual void draw(Graphics graphicsContext){}

        public void isFilled(bool fill) 
        {
            this.fill = fill;
        }

        public virtual void set(Color colour, int x, int y, float penWidth = 3.0f, params int[] list)
        {
            this.penColour = colour;
            if (penWidth != 0)
            {
                this.pen = new Pen(colour, penWidth);
            }
            else
            {
                this.pen = new Pen(colour, 3);
            }
            this.brush = new SolidBrush(colour);
            this.x = x;
            this.y = y;
        }
    }
}
