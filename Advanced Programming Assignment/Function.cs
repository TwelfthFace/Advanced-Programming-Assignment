using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Advanced_Programming_Assignment
{
    public abstract class Function : FunctionInterface
    {
        protected Graphics graphicsContext;
        public List<string> commands = new List<string>();
        protected System.Windows.Forms.ListBox errBox;
        protected Command cmd;

        protected Function(System.Windows.Forms.ListBox errBox, Graphics g)
        {
            this.graphicsContext = g;
            this.errBox = errBox;
            this.cmd = new Command(errBox, graphicsContext);
        }

        public abstract bool run(params string[] parameters);

        public void enumerateCommands(string[] parameters)
        {
            foreach (string str in parameters)
            {
                this.commands.Add(str);
            }
        }
    }
}
