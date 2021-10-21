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
        protected string txtCmd
        {
            get => txtCmdLine.Text;
        }


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

        public bool parser(System.Windows.Forms.ListBox errout)
        {
            string command = this.txtCmd.Trim().ToLower();
            string[] split = command.Split(" ");
            string[] commandParameter = {null, null};
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
                        draw.drawRectangle(Int32.Parse(commandParameter[0]), Int32.Parse(commandParameter[1]));
                        break;
                    case "circle":
                        if (split.Length < 2)
                        {
                            errout.Items.Insert(0, "Missing parameters! [circle c]");
                            return false;
                        }
                        draw.drawCircle(Int32.Parse(commandParameter[0]));
                        break;
                    case "moveto":
                        if (split.Length < 3)
                        {
                            errout.Items.Insert(0, "Missing parameters! [moveto x y]");
                            return false;
                        }
                        draw.moveTo(Int32.Parse(commandParameter[0]), Int32.Parse(commandParameter[1]));
                        break;
                    case "triangle":
                        if (split.Length < 2)
                        {
                            errout.Items.Insert(0, "Missing parameters! [triangle s]");
                            return false;
                        }
                        draw.drawTriangle(Int32.Parse(commandParameter[0]));
                        break;
                    case "pen":
                        if (commandParameter[1] == null)
                        {
                            if (split.Length < 2)
                            {
                                errout.Items.Insert(0, "Missing parameter! [setcolour colour {pensize}]");
                                return false;
                            }
                            switch (commandParameter[0])
                            {
                                case "black":
                                    draw.setPenColour(Color.Black);
                                    break;
                                case "green":
                                    draw.setPenColour(Color.Green);
                                    break;
                                case "blue":
                                    draw.setPenColour(Color.Blue);
                                    break;
                                case "red":
                                    draw.setPenColour(Color.Red);
                                    break;
                                case "yellow":
                                    draw.setPenColour(Color.Yellow);
                                    break;
                                default:
                                    errout.Items.Insert(0, "Unknown Colour!");
                                    return false;
                            }
                        }
                        else
                        {
                            switch (commandParameter[0])
                            {
                                case "black":
                                    draw.setPenColour(Color.Black, Int32.Parse(commandParameter[1]));
                                    break;
                                case "green":
                                    draw.setPenColour(Color.Green, Int32.Parse(commandParameter[1]));
                                    break;
                                case "blue":
                                    draw.setPenColour(Color.Blue, Int32.Parse(commandParameter[1]));
                                    break;
                                case "red":
                                    draw.setPenColour(Color.Red, Int32.Parse(commandParameter[1]));
                                    break;
                                case "yellow":
                                    draw.setPenColour(Color.Yellow, Int32.Parse(commandParameter[1]));
                                    break;
                                default:
                                    errout.Items.Insert(0, "Unknown Colour!");
                                    return false;
                            }
                        }
                    break;
                    case "fill":
                        if (commandParameter[0].Equals("1") || commandParameter[0].Equals("true"))
                        {
                            draw.setFillShapes(true);
                            break;
                        }
                        if (commandParameter[0].Equals("0") || commandParameter[0].Equals("false"))
                        {
                            draw.setFillShapes(false);
                            break;
                        }
                        errout.Items.Insert(0, "Unknown Parameter Supplied! Expecting one of '1, true, 0, false'.");
                        break;
                    case "reset":
                        draw.reset();
                        break;
                    default:
                        errout.Items.Insert(0, "Unknown Command!");
                        return false;
                }
            } catch (Exception e)
            {
                errout.Items.Insert(0, "ERROR: " + e.Message);
                return false;
            }
            return true;
        }

        public Command() { }
    }
}
