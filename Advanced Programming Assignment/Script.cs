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
        VariableFunction variables = null;
        FunctionWhile functionWhile = null;
        public Script(System.Windows.Forms.ListBox errBox, Canvas canvas):base(errBox, canvas)
        {
            this.errBox = errBox;
            this.factory = new FunctionFactory(errBox, canvas);
            this.variables = (VariableFunction)factory.getFunction("variables");
        }

        public new bool parser(string txtScript)
        {
            errBox.Items.Clear();

            string commands = txtScript.Trim().ToLower();
            string[] lines = commands.Split("\r\n");
            List<string> commandsToBeExecuted = new List<string>();

            foreach(string cmd in lines)
            {
                commandsToBeExecuted.Add(cmd);
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
                if (cmd.Contains('+'))
                {
                    if (!cmd[cmd.IndexOf("+")+1].Equals("+")) {
                        variables.addValue(cmd);
                        commandsToBeExecuted.Remove(cmd);
                    }
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
                    case "while":
                        this.functionWhile = (FunctionWhile)factory.getFunction("while");
                        List<string> whileCommands = new List<string>();
                        int whileIndex = 0;
                        int a = 0;
                        string value = "";
                        do
                        {
                            a++;
                            whileIndex = commandsToBeExecuted.IndexOf(cmd);
                            value = commandsToBeExecuted[whileIndex + a];
                            if (value.Contains("endwhile"))
                            {
                                commandsToBeExecuted[whileIndex + a] = "";
                                break;
                            }
                            else {
                                if (!value.Equals("")){
                                    whileCommands.Add(value);
                                    commandsToBeExecuted[whileIndex + a] = "";
                                }
                            }
                        } while (!value.Contains("endwhile"));
                        foreach (string whileCommand in whileCommands)
                        {
                            functionWhile.enumerateCommands(whileCommand);
                        }
                        functionWhile.run(commandsToBeExecuted[whileIndex]);
                        commandsToBeExecuted.RemoveAt(whileIndex + a);
                        break;
                    case "reset":
                        canvas.clearCanvas();
                        draw.reset();
                        draw.setFillShapes(false);
                        draw.setPenColour(Color.Black);
                        errBox.Items.Clear();
                        break;
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
