using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Advanced_Programming_Assignment
{
    public class ForFunction : Function
    {
        public ForFunction(System.Windows.Forms.ListBox errBox, Graphics g): base(errBox, g)
        {

        }

        public override bool run(string[] parameters)
        {
            switch (parameters[2])
            {
                case ">":
                    for (int i = Int32.Parse(parameters[1]); i < Int32.Parse(parameters[3]); i++)
                    {
                        foreach (String cmds in this.commands)
                        {
                            if (!cmds.Equals("end"))
                            {
                                this.cmd.parser(cmds);
                            }
                        }
                    }
                    return true;
                case "<":
                    for (int i = Int32.Parse(parameters[1]); i > Int32.Parse(parameters[3]); i++)
                    {
                        foreach(String cmds in this.commands.ToArray())
                        {
                            if (!cmds.Equals("end"))
                            {
                                this.cmd.parser(cmds);
                            }
                        }
                    }
                    return true;
            }   
            return false;
        }
    }
}
