using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Advanced_Programming_Assignment
{
     //class to define commands and facilitate appropriate feature expansion.
    class Command
    {
        protected Graphics graphicsContext;
        protected RectangleF clipbound;
        protected System.Windows.Forms.TextBox txtCmdLine;
        protected Pen penColor = new Pen(Color.Black, 3);
        
        public Command()
        {

        }

        public Command(System.Windows.Forms.TextBox txtCmdLine)
        {
            this.txtCmdLine = txtCmdLine;
        }

        public Command(System.Windows.Forms.TextBox txtCmdLine, Graphics graphics)
        {
            this.txtCmdLine = txtCmdLine;
            this.graphicsContext = graphics;
            this.clipbound = graphicsContext.ClipBounds;
        }

        public string TxtCmd
        {
            get => txtCmdLine.Text;
        }

        public void Parser()
        {
            string command = this.TxtCmd.Trim().ToLower();
            string[] split = command.Split(" ");
            int commandParameter = 0;
            try { 
            
                if (split.Length > 2)
                {
                    Console.WriteLine("Error!");
                }
                if (split.Length == 2)
                {
                    commandParameter = Int32.Parse(split[1]);
                }

                switch (split[0])
                {
                    case "rectangle":
                        new Draw(this.graphicsContext).DrawRectangle(0, 0, commandParameter, commandParameter, this.penColor.Color);
                        break;
                    case "circle":
                        new Draw(this.graphicsContext).DrawCircle(commandParameter);
                        break;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}
