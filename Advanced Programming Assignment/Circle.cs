using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Advanced_Programming_Assignment
{
    class Circle : Shape
    {
        protected int radius;

        //this function draws the shape.
        public override void draw(Graphics graphicsContext)
        {
            if (!fill)
            {
                graphicsContext.DrawEllipse(pen, new System.Drawing.Rectangle(x, y, radius, radius));
            }
            else
            {
                graphicsContext.FillEllipse(brush, new System.Drawing.Rectangle(x, y, radius, radius));
            }
        }

        //this function sets the colour, position, and optionally penwidth.
        public override void set(Color colour, int x, int y, float penWidth = 3.0f, params int[] list)
        {
            base.set(colour, x, y, penWidth);
            this.radius = list[0];
        }

        public Circle() : base()
        {}
    }
}
