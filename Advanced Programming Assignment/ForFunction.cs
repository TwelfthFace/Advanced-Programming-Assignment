using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Advanced_Programming_Assignment
{
    public class ForFunction : Function
    {
        public override void enumerateCommands(string parameters)
        {

            //foreach (string str in parameters)
            //{
            //    this.commands.Add(str);
            //}
        }

        public override bool run(string parameters)
        {
            //switch (parameters[2])
            //{
            //    case ">":
            //        for (int i = Int32.Parse(parameters[1]); i < Int32.Parse(parameters[3]); i++)
            //        {
            //            foreach (String cmds in this.commands)
            //            {
            //                if (!cmds.Equals("end"))
            //                {
            //                    if (!this.cmd.parser(cmds))
            //                    {
            //                        return false;
            //                    }
            //                }
            //            }
            //        }
            //        return true;
            //    case "<":
            //        for (int i = Int32.Parse(parameters[1]); i > Int32.Parse(parameters[3]); i++)
            //        {
            //            foreach(String cmds in this.commands.ToArray())
            //            {
            //                if (!cmds.Equals("end"))
            //                {
            //                    this.cmd.parser(cmds);
            //                }
            //            }
            //        }
            //        return true;
            //}   
            return false;
        }
        public ForFunction(System.Windows.Forms.ListBox errBox, Canvas canvas) : base(errBox, canvas) { }
    }
}
