using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Advanced_Programming_Assignment
{
    class Rectangle : Shape
    {
        int width, height;

        public Rectangle(Color colour, int x, int y, int width, int height) : base(colour, x, y)
        {
            this.width = width;
            this.height = height;
        }

        public override void draw(Graphics graphicsContext)
        {
            base.draw(graphicsContext);
            if (!fill)
            {
                graphicsContext.DrawRectangle(pen, new System.Drawing.Rectangle(x, y, width, height));
            }
            else
            {
                graphicsContext.FillRectangle(brush, new System.Drawing.Rectangle(x, y, width, height));
            }
        }
        public Rectangle()
        {
        }
    }
}
