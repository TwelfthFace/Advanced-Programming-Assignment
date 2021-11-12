using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Advanced_Programming_Assignment
{
    class Rectangle : Shape
    {
        protected int width, height;

        //this function draws the shape.
        public override void draw(Graphics graphicsContext)
        {
            if (!fill)
            {
                graphicsContext.DrawRectangle(pen, new System.Drawing.Rectangle(x, y, width, height));
            }
            else
            {
                graphicsContext.FillRectangle(brush, new System.Drawing.Rectangle(x, y, width, height));
            }
        }

        //this function sets the colour, position, and optionally penwidth.
        public override void set(Color colour, int x, int y, float penWidth = 3.0f, params int[] list)
        {
            base.set(colour, x, y, penWidth);
            this.width = list[0];
            this.height = list[1];
        }

        public Rectangle() : base(){}
    }
}
