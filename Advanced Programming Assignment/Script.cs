using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Advanced_Programming_Assignment
{
    class Script : Command
    {

        public Script(Graphics graphics)
        {
            this.graphicsContext = graphics;
            this.draw = new Draw(graphics);
        }

        public new bool parser(string txtScript, System.Windows.Forms.ListBox errout)
        {
            errout.Items.Clear();

            string command = txtScript.Trim().ToLower();
            string[] lines = command.Split("\r");
            foreach (string line in lines)
            {
                string formatLine = line.Replace("\n", "");
                base.parser(formatLine, errout);
            }
            
            return true;
        }

    }
}
