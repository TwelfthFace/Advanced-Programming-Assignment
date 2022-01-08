using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace Advanced_Programming_Assignment
{
    public class Script : Command
    {
        FunctionFactory factory = null;
        public VariableFunction variables = null;
        FunctionWhile functionWhile = null;
        FunctionIf functionIf = null;
        int WhileIndex = 0;
        int EndWhileIndex = 0;
        int IfIndex = 0;
        int EndIfIndex = 0;

        public Script(System.Windows.Forms.ListBox errBox, Canvas canvas):base(errBox, canvas)
        {
            this.errBox = errBox;
            this.factory = new FunctionFactory(errBox, canvas, this);
            this.variables = (VariableFunction)factory.getFunction("variables");
            this.functionWhile = (FunctionWhile)factory.getFunction("while");
            this.functionIf = (FunctionIf)factory.getFunction("if");
        }

        public new bool parser(string txtScript)
        {
            errBox.Items.Clear();

            string commands = txtScript.Trim().ToLower();
            List<string> lines = new List<string>(commands.Split("\r\n"));
            List<string> commandsToBeExecuted = new List<string>();
            List<string> whileCommandsToBeExecuted = new List<string>();
            List<string> ifCommandsToBeExecuted = new List<string>();

            foreach (string cmd in lines)
            {
                if (cmd.Contains("while") && !cmd.Equals("endwhile"))
                {
                    WhileIndex = lines.IndexOf(cmd);
                }
                if (cmd.Contains("endwhile"))
                {
                    EndWhileIndex = lines.IndexOf(cmd);
                }
                if (cmd.Contains("if") && !cmd.Equals("endif"))
                {
                    IfIndex = lines.IndexOf(cmd);
                }
                if (cmd.Contains("endif"))
                {
                    EndIfIndex = lines.IndexOf(cmd);
                }
            }

            foreach (string cmd in lines)
            {
                if (lines.IndexOf(cmd) > WhileIndex && lines.IndexOf(cmd) < EndWhileIndex)
                {
                    whileCommandsToBeExecuted.Add(cmd);
                }

                if (lines.IndexOf(cmd) > IfIndex && lines.IndexOf(cmd) < EndIfIndex)
                {
                    ifCommandsToBeExecuted.Add(cmd);
                }

                if (!cmd.Contains("endwhile") && !cmd.Contains("endif") && !whileCommandsToBeExecuted.Contains(cmd) && !ifCommandsToBeExecuted.Contains(cmd))
                {
                    commandsToBeExecuted.Add(cmd);
                }
            }
            
            foreach (string cmd in lines)
            {
                string[] spaceSplit = cmd.Trim().Split(" ");
                if (cmd.Contains("="))
                {
                    variables.enumerateCommands(cmd);
                    commandsToBeExecuted.Remove(cmd);
                }
                if (cmd.Contains("++"))
                {
                    variables.iterateValue(cmd);
                    commandsToBeExecuted.Remove(cmd);
                }
            }

            string substitutedScript = variables.substituteValues(commandsToBeExecuted.ToArray());
            string[] substitutedScriptLines = substitutedScript.Split("\r\n");
            commandsToBeExecuted.Clear();

            foreach (string line in substitutedScriptLines)
            {
                commandsToBeExecuted.Add(line.Trim());
            }

            for (int i = 0; i < commandsToBeExecuted.Count; i++)
            {
                string cmd = commandsToBeExecuted[i];
                string[] spaceSplit = cmd.Trim().Split(" ");
                switch (spaceSplit[0])
                {
                    case "if":
                        functionIf.enumerateCommands(ifCommandsToBeExecuted.ToArray());
                        functionIf.run(cmd);
                        break;
                    case "while":
                        functionWhile.enumerateCommands(whileCommandsToBeExecuted.ToArray());
                        functionWhile.run(cmd);
                        break;
                    case "reset":
                        canvas.clearCanvas();
                        draw.reset();
                        draw.setFillShapes(false);
                        draw.setPenColour(Color.Black);
                        errBox.Items.Clear();
                        break;
                    default:
                        if(ifCommandsToBeExecuted.Count > 0)
                        {
                            foreach(string ifCmd in ifCommandsToBeExecuted.ToArray())
                            {
                                functionIf.run();
                            }
                        }
                        base.parser(cmd);
                        break;
                }
            }
            return true;
        }
    }
}
