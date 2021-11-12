using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Advanced_Programming_Assignment
{
    //class to define commands and facilitate appropriate feature expansion.
    public class Command
    {
        protected Draw draw;
        protected Script script;
        protected Graphics graphicsContext;
        protected RectangleF clipbound;
        protected System.Windows.Forms.ListBox errBox;

        public Command(System.Windows.Forms.ListBox errBox, Graphics g)
        {
            this.graphicsContext = g;
            this.draw = new Draw(graphicsContext);
            this.errBox = errBox;
        }

        public Command(System.Windows.Forms.TextBox txtCmdLine, System.Windows.Forms.ListBox errBox, Graphics graphics)
        {
            this.graphicsContext = graphics;
            this.clipbound = graphicsContext.ClipBounds;
            this.draw = new Draw(graphicsContext);
            this.script = new Script(errBox, graphicsContext);
            this.errBox = errBox;
        }

        public bool parser(string txtCmds)
        {
            string command = txtCmds.Trim().ToLower();
            string[] split = command.Split(" ");
            string[] commandParameter = {null, null, null};
            try { 
            
                if (split.Length > 4)
                {
                    errBox.Items.Insert(0, "Too many parameters! Max parameters 3.");
                    return false;
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
                if (split.Length == 4)
                {
                    commandParameter[0] = split[1];
                    commandParameter[1] = split[2];
                    commandParameter[2] = split[3];
                }

                switch (split[0])
                {
                    case "rectangle":
                        if(split.Length != 3)
                        {
                            errBox.Items.Insert(0, "Missing parameters! [rectangle w h]");
                            return false;
                        }
                        draw.drawRectangle(Int32.Parse(commandParameter[0]), Int32.Parse(commandParameter[1]));
                        break;
                    case "circle":
                        if (split.Length != 2)
                        {
                            errBox.Items.Insert(0, "Missing parameter! [circle c]");
                            return false;
                        }
                        draw.drawCircle(Int32.Parse(commandParameter[0]));
                        break;
                    case "moveto":
                        if (split.Length != 2 && split.Length != 3)
                        {
                            errBox.Items.Insert(0, "Missing parameters! [moveto x y] or [moveto x]");
                            return false;
                        }

                        if (split.Length == 3)
                        {
                            draw.moveTo(Int32.Parse(commandParameter[0]), Int32.Parse(commandParameter[1]));
                        }

                        if (split.Length == 2)
                        {
                            draw.moveTo(Int32.Parse(commandParameter[0]));
                        }
                        break;
                    case "triangle":
                        if (split.Length != 4 && split.Length != 2)
                        {
                            errBox.Items.Insert(0, "Missing parameters! [triangle a,b,c] or [triangle s]");
                            return false;
                        }
                        
                        if(split.Length == 2)
                            draw.drawTriangle(Int32.Parse(commandParameter[0]));
                        
                        if(split.Length == 4)
                            draw.drawTriangle(Int32.Parse(commandParameter[0]), Int32.Parse(commandParameter[1]), Int32.Parse(commandParameter[2]));
                        
                        break;
                    case "pen":
                        if (split.Length != 2 && split.Length != 3)
                        {
                            errBox.Items.Insert(0, "Missing parameter! [setcolour colour {pensize}]");
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
                                errBox.Items.Insert(0, "Unknown Colour!");
                                return false;
                        }
                        if (split.Length == 3)
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
                                    errBox.Items.Insert(0, "Unknown Colour!");
                                    return false;
                            }
                        }
                    break;
                    case "fill":
                        if (commandParameter[0].Equals("1") || commandParameter[0].Equals("true"))
                        {
                            draw.setFillShapes(true);
                            return true;
                        }
                        if (commandParameter[0].Equals("0") || commandParameter[0].Equals("false"))
                        {
                            draw.setFillShapes(false);
                            return true;
                        }
                        errBox.Items.Insert(0, "Unknown Parameter Supplied! Expecting one of '1, true, 0, false'.");
                        break;
                    case "reset":
                        draw.moveTo(0, 0);
                        draw.setFillShapes(false);
                        draw.setPenColour(Color.Black);
                        return true;
                    default:
                        errBox.Items.Insert(0, "Unknown Command! \"" + split[0] +"\"");
                        return false;
                }
            }
            catch (Exception e)
            {
                errBox.Items.Insert(0, "ERROR: " + e.Message);
                return false;
            }
            return true;
        }

        public Command() { }
    }
}
