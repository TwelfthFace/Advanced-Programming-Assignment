using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Advanced_Programming_Assignment
{
    class Draw : Command
    {

        private Turtle turtle;

        struct Turtle
        {
            public int x;
            public int y;
            public Pen turtleColour;

        }

        public Draw(Graphics g)
        {
            this.graphicsContext = g;
            this.clipbound = g.ClipBounds;

            turtle = new Turtle
            {
                x = 0,
                y = 0,
                turtleColour = this.penColor
            };
        }

        public void moveTo(int x, int y)
        {
            turtle.x = x;
            turtle.y = y;
        }

        public void DrawRectangle(int width, int length, Color colour, int penSize = 3)
        {
            graphicsContext.DrawRectangle(penColor, ((this.clipbound.X + penSize) - 1) + turtle.x, turtle.y + penSize + 12, width, length);
        }

        public void DrawCircle(int radius)
        {
            Rectangle rect = new Rectangle((int)clipbound.X + turtle.x, 20, radius, radius);
            this.graphicsContext.DrawEllipse(penColor, rect);
        }
    }
}
