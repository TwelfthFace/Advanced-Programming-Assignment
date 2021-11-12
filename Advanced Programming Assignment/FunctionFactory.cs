using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Advanced_Programming_Assignment
{
    public class FunctionFactory
    {

        protected Graphics graphicsContext;
        protected System.Windows.Forms.ListBox errBox;

        public FunctionFactory(System.Windows.Forms.ListBox errBox, Graphics g)
        {
            this.graphicsContext = g;
            this.errBox = errBox;
        }

        public Function getFunction(string function)
        {
            function = function.ToLower().Trim();
            switch (function)
            {
                case "for":
                    return new ForFunction(errBox, graphicsContext);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
