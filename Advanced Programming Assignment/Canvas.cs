using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Advanced_Programming_Assignment
{
    public class Canvas
    {
        readonly Bitmap bitmapImage;
        readonly Graphics graphicsContext;

        public Canvas()
        {
            this.bitmapImage = new Bitmap(1228, 824);
            this.graphicsContext = Graphics.FromImage(bitmapImage);
        }

        public Graphics getGraphicsContext()
        {
            return this.graphicsContext;
        }

        public Bitmap getBitmap()
        {
            return bitmapImage;
        }

        public void clearCanvas()
        {
            graphicsContext.Clear(Color.Gray);
        }

    }
}
