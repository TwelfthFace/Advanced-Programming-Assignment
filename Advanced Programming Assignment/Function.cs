using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Advanced_Programming_Assignment
{
    public abstract class Function : FunctionInterface
    {
        protected Canvas canvas;
        protected Graphics graphicsContext;
        public List<string> commands = new List<string>();
        protected System.Windows.Forms.ListBox errBox;
        protected Command cmd;
        protected Script script;

        protected Function(System.Windows.Forms.ListBox errBox, Canvas canvas, Script script)
        {
            this.canvas = canvas;
            this.graphicsContext = canvas.getGraphicsContext();
            this.errBox = errBox;
            this.script = script;
        }

        public abstract bool run(string parameters);

        public abstract void enumerateCommands(string parameters);
    }
}
