using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Advanced_Programming_Assignment
{
    internal class FunctionIf : Function
    {
        string condition;

        public void enumerateCommands(string[] parameters)
        {
            foreach (string cmds in parameters)
            {
                if (cmds.Contains("if"))
                {
                    condition = cmds;
                }
                else
                {
                    commands.Add(cmds);
                }
            }
        }

        public override bool run(string parameters = "")
        {
            if (!parameters.Contains("if"))
            {
                string[] command = condition.Split(" ");
                int firstNum = int.Parse(command[1]);
                int secNum = int.Parse(command[3]);
                switch (command[2])
                {
                    case "==":
                        if (firstNum == secNum)
                        {
                            foreach (String cmds in this.commands)
                            {
                                script.parser(cmds);
                            }
                        }
                        break;
                    case "!=":
                        if (firstNum != secNum)
                        {
                            foreach (String cmds in this.commands)
                            {
                                script.parser(cmds);
                            }
                        }
                        break;
                    case ">":
                        if (firstNum > secNum)
                        {
                            foreach (String cmds in this.commands)
                            {
                                script.parser(cmds);
                            }
                        }
                        break;
                    case "<":
                        if (firstNum < secNum)
                        {
                            foreach (String cmds in this.commands)
                            {
                                script.parser(cmds);
                            }
                        }
                        break;
                }
                commands.Clear();
            }
            else {
                condition = parameters;
                return true;
            }
            return true;
        }

        public override void enumerateCommands(string parameters)
        {
            if (parameters.Contains("if"))
            {
                condition = parameters;
            }
        }

        public FunctionIf(ListBox errBox, Canvas canvas, Script script) : base(errBox, canvas, script)
        {
        }

    }
}
