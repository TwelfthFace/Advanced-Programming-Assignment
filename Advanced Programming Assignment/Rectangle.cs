﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Advanced_Programming_Assignment
{
    class Rectangle : Shape
    {
        protected int width, height;

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

        public override void set(Color colour, int x, int y, params int[] list)
        {
            base.set(colour, x, y);
            this.width = list[0];
            this.height = list[1];
        }
        public Rectangle()
        {
        }
    }
}
