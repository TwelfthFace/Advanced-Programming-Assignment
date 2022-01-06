using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Advanced_Programming_Assignment
{
    public class FunctionWhile : Function
    {
        private Script script = null;

        public override void enumerateCommands(string command)
        {
            this.commands.Add(command);
        }

        public override bool run(string parameters)
        {
            string[] command = parameters.Split(" ");
            switch (command[2])
            {
                case ">":
                    for (int i = Int32.Parse(command[1]); i < Int32.Parse(command[3]); i++)
                    {
                        foreach (String cmds in this.commands)
                        {
                            script.parser(cmds);
                        }
                    }
                    break;
                case "<":
                    for (int i = Int32.Parse(command[1]); i > Int32.Parse(command[3]); i++)
                    {
                        foreach (String cmds in this.commands)
                        {
                            script.parser(cmds);
                        }
                    }
                    break;
            }
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
        public FunctionWhile(System.Windows.Forms.ListBox errBox, Canvas canvas) : base(errBox, canvas) 
        {
            this.script = new Script(errBox, canvas);
        }
    }
}
