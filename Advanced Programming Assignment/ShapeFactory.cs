using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Advanced_Programming_Assignment
{
    class ShapeFactory
    {
        protected Color colour;
        protected int x, y;
        protected int[] list;

        public ShapeFactory(Color colour, int x, int y, params int[] list)
        {
            this.colour = colour;
            this.x = x;
            this.y = y;
            this.list = list;
        }

        public Shape getShape(String shape)
        {
            shape = shape.ToLower().Trim();

            switch (shape)
            {
                case "rectangle":
                    return new Rectangle(colour, x, y, list[0], list[1]);
                default:
                    return null;
            }
        }
    }
}
