using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Advanced_Programming_Assignment
{
    public class FunctionFactory
    {
        protected Canvas canvas;
        protected Graphics graphicsContext;
        protected System.Windows.Forms.ListBox errBox;

        public FunctionFactory(System.Windows.Forms.ListBox errBox, Canvas canvas)
        {
            this.canvas = canvas;
            this.graphicsContext = canvas.getGraphicsContext();
            this.errBox = errBox;
        }

        public Function getFunction(string function)
        {
            function = function.ToLower().Trim();
            switch (function)
            {
                case "for":
                    return new ForFunction(errBox, this.canvas);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
