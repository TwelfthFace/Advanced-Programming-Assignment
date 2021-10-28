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
            penColour = Color.Red;
            x = y - 100;
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

        public virtual void isFilled(bool fill) 
        {
            this.fill = fill;
        }

    }
}
