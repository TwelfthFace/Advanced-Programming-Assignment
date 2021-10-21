﻿using System;
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
            
            string command = txtScript.Trim().ToLower();
            string[] lines = command.Split("\r");
            foreach (string line in lines)
            {
                string formatLine = line.Replace("\n", "");
                string[] split = formatLine.Split(" ");
                string[] commandParameter = { null, null };

                base.parser(formatLine, errout);
               
            }
            
            return true;
        }

    }
}
