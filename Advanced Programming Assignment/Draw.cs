using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Advanced_Programming_Assignment
{
    class Draw : Command
    { 

        public Draw(Graphics g)
        {
            this.graphicsContext = g;
            this.clipbound = g.ClipBounds;
        }

        public void DrawRectangle(int x, int y, int width, int length, Color colour, int penSize = 3)
        {
            graphicsContext.DrawRectangle(penColor, ((this.clipbound.X + penSize) - 1) + x, y + penSize + 12, width, length);
        }

        public void DrawCircle(int radius)
        {
            Rectangle rect = new Rectangle((int)clipbound.X, 20, radius, radius);
            this.graphicsContext.DrawEllipse(penColor, rect);
        }
    }
}
