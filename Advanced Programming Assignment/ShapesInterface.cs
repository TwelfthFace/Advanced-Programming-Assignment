using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing; 

namespace Advanced_Programming_Assignment
{
    interface ShapesInterface
    {
        //backbone function.
        void set(Color colour, int x, int y, float penWidth, params int[] list);

        //backbone function.
        void draw(Graphics graphicsContext);

        //backbone function.
        void isFilled(bool fill);
    }
}
