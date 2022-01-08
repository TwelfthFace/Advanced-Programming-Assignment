using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Advanced_Programming_Assignment
{
    public class FunctionWhile : Function
    {
 
        public void enumerateCommands(string[] command)
        {
            foreach (var cmd in command) { 
                commands.Add(cmd);
            }
        }
        public override void enumerateCommands(string command)
        {
            throw new NotImplementedException();
        }

        public override bool run(string parameters)
        {
            string[] command = parameters.Split(" ");
            switch (command[2])
            {
                case "<":
                    for (int i = Int32.Parse(command[1]); i < Int32.Parse(command[3]); i++)
                    {
                        foreach (String cmds in this.commands)
                        {
                            script.parser(cmds);
                        }
                    }
                    script.variables.clearKeys();
                    commands.Clear();
                    break;
                case ">":
                    for (int i = Int32.Parse(command[1]); i > Int32.Parse(command[3]); i++)
                    {
                        foreach (String cmds in this.commands)
                        {
                            cmd.parser(cmds);
                        }
                    }
                    script.variables.clearKeys();
                    commands.Clear();
                    break;
            }
             return false;
        }

        public FunctionWhile(System.Windows.Forms.ListBox errBox, Canvas canvas, Script script) : base(errBox, canvas, script) {}
    }
}
