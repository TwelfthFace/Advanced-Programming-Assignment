using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace Advanced_Programming_Assignment
{
    public class Script : Command
    {
        VariableFunction variables = null;
        string[] keys = { "" };

        public Script(System.Windows.Forms.ListBox errBox, Canvas canvas):base(errBox, canvas)
        {
            this.canvas = canvas;
            this.graphicsContext = canvas.getGraphicsContext();
            this.draw = new Draw(canvas);
            this.errBox = errBox;
            this.variables = new VariableFunction(errBox, canvas);
        }

        public new bool parser(string txtScript)
        {
            errBox.Items.Clear();

            string commands = txtScript.Trim().ToLower();
            string[] lines = commands.Split("\r\n");
            string substitutedScript = null;
            string[] substitutedScriptLines = null;
            List<string> commandsToBeExecuted = new List<string>();

            foreach(string cmd in lines)
            {
                commandsToBeExecuted.Add(cmd);
            }
            foreach (string cmd in lines)
            {
                string[] spaceSplit = cmd.Trim().Split(" ");
                if (spaceSplit.Length > 1)
                {
                    if (spaceSplit[1].Contains("="))
                    {
                        variables.enumerateCommands(cmd);
                        this.keys = variables.getKeys();
                        commandsToBeExecuted.Remove(cmd);
                        continue;
                    }
                }
            }
            substitutedScript = variables.substituteValues(commandsToBeExecuted.ToArray());
            substitutedScriptLines = substitutedScript.Split("\r\n");
            commandsToBeExecuted.Clear();
            foreach (string line in substitutedScriptLines)
            {
                commandsToBeExecuted.Add(line.Trim());
            }
            foreach (string cmd in commandsToBeExecuted.ToArray())
            {
                string[] spaceSplit = cmd.Trim().Split(" ");
                switch (spaceSplit[0])
                {
                    default:
                        base.parser(cmd);
                        break;
                }
            }
            variables.clearKeys();
            return true;
        }

        //public new bool parser(string txtScript)
        //{
        //    errBox.Items.Clear();

        //    string command = txtScript.Trim().ToLower();
        //    string[] lines = command.Split("\r\n");
        //    string[] commandParameters = {"","","",""};
        //    List<string> commands = new List<string>();
        //    int indexOfCmd = 0; //Array.IndexOf(lines, "for");

        //    foreach (string line in lines)
        //    {
        //        string[] split = line.Split(" ");

        //        switch (split[0])
        //        {
        //            case "for":
        //                for (int i = 0; i < lines.Length; i++)
        //                {
        //                    if (Regex.IsMatch(lines[i], @"\b(for)\b"))
        //                    {
        //                        indexOfCmd = i;
        //                    }

        //                        if (Regex.IsMatch(lines[i], @"\b(for)\b")) 
        //                        {
        //                            for (int f = i; i < lines.Length; f++)
        //                            {
        //                                string[] commandParametersSplit = lines[i].Split(" ");
        //                                commandParameters[0] = commandParametersSplit[0];
        //                                commandParameters[1] = commandParametersSplit[1];
        //                                commandParameters[2] = commandParametersSplit[2];
        //                                commandParameters[3] = commandParametersSplit[3];
        //                                if (lines[indexOfCmd + f].Equals("end"))
        //                                {
        //                                    break;
        //                                }
        //                                commands.Add(lines[indexOfCmd + f + 1]);
        //                            }
        //                        }
        //                }
        //                Function forFunction = new FunctionFactory(errBox, canvas).getFunction("for");
        //                forFunction.enumerateCommands(commands.ToArray());
        //                forFunction.run(commandParameters[0], commandParameters[1], commandParameters[2], commandParameters[3]);
        //                break;
        //            default:
        //                if(!line.Equals("end"))
        //                    base.parser(line);
        //                break;
                        
        //        }
        //    }
        //    return true;
        //}

    }
}
