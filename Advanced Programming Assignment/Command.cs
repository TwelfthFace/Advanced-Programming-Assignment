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
        protected Draw draw;
        protected Graphics graphicsContext;
        protected RectangleF clipbound;
        protected System.Windows.Forms.TextBox txtCmdLine;
        protected Pen penColor = new Pen(Color.Black, 3);


        public Command(System.Windows.Forms.TextBox txtCmdLine)
        {
            this.txtCmdLine = txtCmdLine;
            this.draw = new Draw(graphicsContext);
        }

        public Command(System.Windows.Forms.TextBox txtCmdLine, Graphics graphics)
        {
            this.txtCmdLine = txtCmdLine;
            this.graphicsContext = graphics;
            this.clipbound = graphicsContext.ClipBounds;
            this.draw = new Draw(graphicsContext);
        }

        public string TxtCmd
        {
            get => txtCmdLine.Text;
        }

        public Boolean Parser(System.Windows.Forms.ListBox errout)
        {
            string command = this.TxtCmd.Trim().ToLower();
            string[] split = command.Split(" ");
            string[] commandParameter = {"", ""};
            try { 
            
                if (split.Length > 3)
                {
                    errout.Items.Insert(0, "Too many parameters! Max parameters 2.");
                }
                if (split.Length == 2)
                {
                    commandParameter[0] = split[1];
                }

                if (split.Length == 3)
                {
                    commandParameter[0] = split[1];
                    commandParameter[1] = split[2];
                }

                switch (split[0])
                {
                    case "rectangle":
                        if(split.Length < 3)
                        {
                            errout.Items.Insert(0, "Missing parameters! [rectangle w h]");
                            return false;
                        }
                        draw.DrawRectangle(Int32.Parse(commandParameter[0]), Int32.Parse(commandParameter[1]), this.penColor.Color);
                        break;
                    case "circle":
                        if (split.Length < 2)
                        {
                            errout.Items.Insert(0, "Missing parameters! [circle c]");
                            return false;
                        }
                        draw.DrawCircle(Int32.Parse(commandParameter[0]));
                        break;
                    case "moveto":
                        if (split.Length < 3)
                        {
                            errout.Items.Insert(0, "Missing parameters! [moveto x y]");
                            return false;
                        }
                        draw.moveTo(Int32.Parse(commandParameter[0]), Int32.Parse(commandParameter[1]));
                        break;
                    default:
                        errout.Items.Insert(0, "Unknown Command!");
                        return false;
                }
            } catch (Exception e)
            {
                errout.Items.Insert(0, e.Message);
            }
            return false;
        }

        public Command() { }
    }
}
