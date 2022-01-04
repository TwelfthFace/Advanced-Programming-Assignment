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
            string substitutedCommand = null;
            bool substituted = false;

            List<string> commandsToBeExecuted = new List<string>();
            foreach(string cmd in lines)
            {
                commandsToBeExecuted.Add(cmd);
            }

            foreach(string cmd in commandsToBeExecuted.ToArray())
            {
               
                string[] spaceSplit = cmd.Trim().Split(" ");
                if(spaceSplit.Length > 1){
                    if (spaceSplit[1].Contains("=")) {
                        variables.enumerateCommands(cmd);
                        this.keys = variables.getKeys();
                        commandsToBeExecuted.Remove(cmd);
                        continue;
                    }
                }
                if (keys[0].Length > 0)
                {
                    foreach (string key in keys)
                    {
                        if (Regex.IsMatch(cmd, @"\b(" + key + @")\b"))
                        {
                            if (!spaceSplit[1].Contains("="))
                            {
                                string substitionCheck = cmd;
                                foreach (string value in keys)
                                {
                                    substitionCheck = variables.substituteValues(substitionCheck, value);
                                    substitutedCommand = substitionCheck;
                                    substituted = true;
                                }
                            }
                        }
                    }
                }
                switch (spaceSplit[0])
                {
                    default:
                        if (substituted) {
                            base.parser(substitutedCommand);
                            substituted = false;
                        }
                        else
                        {
                            base.parser(cmd);
                        }
                        break;
                }
                commandsToBeExecuted.Remove(cmd);
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

        //public new bool parser(string txtScript, System.Windows.Forms.ListBox errout)
        //{
        //    errout.Items.Clear();

        //    string command = txtScript.Trim().ToLower();
        //    string[] lines = command.Split("\r");
        //    List<string> commands = new List<string>();

        //    for (int i = 0; i < lines.Length; i++)
        //    {
        //        string formatLine = lines[i].Replace("\n", "");
        //        commands.Add(formatLine);
        //        if (i == lines.Length)
        //        {
        //            switch (formatLine)
        //            {
        //                case "for":
        //                    Function forFunction = new FunctionFactory().getFunction("for");
        //                    forFunction.enumerateParameters(commands.ToArray());
        //                    break;
        //            }
        //            base.parser(formatLine, errout);
        //        }
        //    }

        //    return true;
        //}

    }
}
