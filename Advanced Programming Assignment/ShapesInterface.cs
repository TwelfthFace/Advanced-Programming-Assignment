using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing; 

namespace Advanced_Programming_Assignment
{
    interface ShapesInterface
    {
        void set(Color colour, int x, int y, float penWidth, params int[] list);

        void draw(Graphics graphicsContext);

        void isFilled(bool fill);
    }
}
