using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Advanced_Programming_Assignment
{
    public class FunctionFactory
    {
        protected Canvas canvas;
        protected Script script;
        protected Graphics graphicsContext;
        protected System.Windows.Forms.ListBox errBox;

        public FunctionFactory(System.Windows.Forms.ListBox errBox, Canvas canvas, Script script)
        {
            this.canvas = canvas;
            this.graphicsContext = canvas.getGraphicsContext();
            this.errBox = errBox;
            this.script = script;
        }

        public Function getFunction(string function)
        {
            function = function.ToLower().Trim();
            switch (function)
            {
                case "while":
                    return new FunctionWhile(errBox, this.canvas, script);
                case "variables":
                    return new VariableFunction(errBox, this.canvas, script);
                case "if":
                    return new FunctionIf(errBox, this.canvas, script);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
