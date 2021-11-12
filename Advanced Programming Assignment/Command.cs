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
        public Draw draw;
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

        /// <summary>
        /// This function takes input as a string and process that string to asertain the command to 
        /// run and the parameters sent. 
        /// This function returns true by default if an error occurs the function returns false.
        /// </summary>
        /// <param name="txtCmds"></param>
        /// <returns>bool true if no errors are encounterd</returns>
        public bool parser(string txtCmds)
        {
            string command = txtCmds.Trim().ToLower();
            string[] split = command.Split(" ");
            string[] paramsSplit = null;
            
            try {
                if (split.Length == 2)
                {
                    paramsSplit = split[1].Split(",");
                }
                else
                {
                    if (split.Length > 2)
                    {
                        errBox.Items.Insert(0, "Too many parameters specified!");
                        return false;
                    }
                    else
                    {
                        if(!(split[0].Equals("reset")))
                        {
                            errBox.Items.Insert(0, "No parameters specified!");
                            return false;
                        }
                    }
                }

                switch (split[0])
                {
                    case "rectangle":
                        if (paramsSplit.Length > 2)
                        {
                            errBox.Items.Insert(0, "Too many parameters! [rectangle w,h]");
                            return false;
                        }

                        if (paramsSplit.Length != 2)
                        {
                            errBox.Items.Insert(0, "Missing parameters! [rectangle w,h]");
                            return false;
                        }
                        draw.drawRectangle(Int32.Parse(paramsSplit[0]), Int32.Parse(paramsSplit[1]));
                        break;
                    case "circle":
                        if (paramsSplit.Length > 1)
                        {
                            errBox.Items.Insert(0, "Too many parameters! [circle c]");
                            return false;
                        }

                        if (paramsSplit.Length != 1)
                        {
                            errBox.Items.Insert(0, "Missing parameter! [circle c]");
                            return false;
                        }
                        draw.drawCircle(Int32.Parse(paramsSplit[0]));
                        break;
                    case "moveto":
                        if (paramsSplit.Length > 2)
                        {
                            errBox.Items.Insert(0, "Too many parameters! [moveto x,y] or [moveto x]");
                            return false;
                        }

                        if (paramsSplit.Length != 1 && paramsSplit.Length != 2)
                        {
                            errBox.Items.Insert(0, "Missing parameters! [moveto x,y] or [moveto x]");
                            return false;
                        }

                        if (paramsSplit.Length == 2)
                        {
                            draw.moveTo(Int32.Parse(paramsSplit[0]), Int32.Parse(paramsSplit[1]));
                        }

                        if (paramsSplit.Length == 1)
                        {
                            draw.moveTo(Int32.Parse(paramsSplit[0]));
                        }
                        break;
                    case "triangle":
                        if (paramsSplit.Length > 3)
                        {
                            errBox.Items.Insert(0, "Too many parameters! [triangle a,b,c] or [triangle s]");
                            return false;
                        }

                        if (paramsSplit.Length != 3 && paramsSplit.Length != 1)
                        {
                            errBox.Items.Insert(0, "Missing parameters! [triangle a,b,c] or [triangle s]");
                            return false;
                        }
                        
                        if(paramsSplit.Length == 1)
                            draw.drawTriangle(Int32.Parse(paramsSplit[0]));
                        
                        if(paramsSplit.Length == 3)
                            draw.drawTriangle(Int32.Parse(paramsSplit[0]), Int32.Parse(paramsSplit[1]), Int32.Parse(paramsSplit[2]));
                        
                        break;
                    case "pen":
                        if (paramsSplit.Length > 2)
                        {
                            errBox.Items.Insert(0, "Too many parameters! [setcolour colour,{pensize}]");
                            return false;
                        }

                        if (paramsSplit.Length != 1 && paramsSplit.Length != 2)
                        {
                            errBox.Items.Insert(0, "Missing parameter! [setcolour colour,{pensize}]");
                            return false;
                        }

                        switch (paramsSplit[0])
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
                        if (paramsSplit.Length == 2)
                        {
                            switch (paramsSplit[0])
                            {
                                case "black":
                                    draw.setPenColour(Color.Black, Int32.Parse(paramsSplit[1]));
                                    break;
                                case "green":
                                    draw.setPenColour(Color.Green, Int32.Parse(paramsSplit[1]));
                                    break;
                                case "blue":
                                    draw.setPenColour(Color.Blue, Int32.Parse(paramsSplit[1]));
                                    break;
                                case "red":
                                    draw.setPenColour(Color.Red, Int32.Parse(paramsSplit[1]));
                                    break;
                                case "yellow":
                                    draw.setPenColour(Color.Yellow, Int32.Parse(paramsSplit[1]));
                                    break;
                                default:
                                    errBox.Items.Insert(0, "Unknown Colour!");
                                    return false;
                            }
                        }
                    break;
                    case "fill":
                        if (paramsSplit.Length > 1)
                        {
                            errBox.Items.Insert(0, "Too many parameters! [fill 1 | true | 0 | false]");
                            return false;
                        }

                        if (paramsSplit.Length != 1)
                        {
                            errBox.Items.Insert(0, "Missing parameters! [fill 1 | true | 0 | false]");
                            return false;
                        }

                        if (paramsSplit[0].Equals("1") || paramsSplit[0].Equals("true"))
                        {
                            draw.setFillShapes(true);
                            return true;
                        }

                        if (paramsSplit[0].Equals("0") || paramsSplit[0].Equals("false"))
                        {
                            draw.setFillShapes(false);
                            return true;
                        }

                        errBox.Items.Insert(0, "Unknown Parameter Supplied! Expecting one of '1, true, 0, false'.");
                        return false;
                    case "drawto":
                        if (paramsSplit.Length > 2)
                        {
                            errBox.Items.Insert(0, "Too many parameters! [drawto x,y]");
                            return false;
                        }

                        if (paramsSplit.Length != 2)
                        {
                            errBox.Items.Insert(0, "Missing parameters! [drawto x,y]");
                            return false;
                        }

                        draw.drawLine(Int32.Parse(paramsSplit[0]), Int32.Parse(paramsSplit[1]));
                        break;
                    case "reset":
                        draw.moveTo(0, 0);
                        draw.setFillShapes(false);
                        draw.setPenColour(Color.Black);
                        errBox.Items.Clear();
                        break;
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
