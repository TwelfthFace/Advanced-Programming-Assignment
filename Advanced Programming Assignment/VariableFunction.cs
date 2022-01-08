using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Advanced_Programming_Assignment
{
    public class VariableFunction : Function
    {
       protected Dictionary<string,int> keyValuePairs = new Dictionary<string, int>();

        public override bool run(string parameters)
        {
            throw new NotImplementedException();
        }

        public string[] getKeys()
        {
            List<string> keys = new List<string>();

            foreach (string key in keyValuePairs.Keys)
            {
                keys.Add(key);
            }
            return keys.ToArray();
        }

        public void clearKeys()
        {
            keyValuePairs.Clear();
        }

        public void iterateValue(string command)
        {
            foreach (string key in this.getKeys())
            {
                if (command.Contains(key + "++"))
                {
                    int value = keyValuePairs[key];
                    int iterator = value+1;
                    keyValuePairs[key] = iterator;
                }
            }
        }

        public void appendValues(string command)
        {
            foreach (string key in this.getKeys())
            {
                if (command.Contains(key + "++"))
                {
                    int value = keyValuePairs[key];
                    int iterator = value+1;
                    keyValuePairs[key] = iterator;
                }
            }
        }

        public void addValue(string command)
        {
            if (command.Contains('='))
            {
                string[] commandSplit = command.Split('=');
                string key = commandSplit[0].Trim();
                string value = commandSplit[1].Trim();
                string[] valueSum = value.Split('+');
                List<string> numbers = new List<string>();
                foreach (string num in valueSum) {
                    if (keyValuePairs.ContainsKey(num.Trim()))
                    {
                        numbers.Add(keyValuePairs[num.Trim()].ToString());
                    }else
                    {
                        numbers.Add(num);
                    }
                }
                keyValuePairs[key] = int.Parse(numbers[0]) + int.Parse(numbers[1]);
            }
        }

        public string substituteValues(string[] commands)
        {
            string substitutedCommands = "";

            foreach (string cmd in commands)
            {
                substitutedCommands += cmd+"\r\n";
            }
            foreach (string key in keyValuePairs.Keys)
            {
                substitutedCommands = Regex.Replace(substitutedCommands, @"\b(" + key + @")\b", keyValuePairs[key].ToString(), RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline, TimeSpan.FromSeconds(.25));
            }
            return substitutedCommands;
        }

        public override void enumerateCommands(string parameters)
        {
            string[] keyValue = parameters.Split("=");
            string key = keyValue[0].Trim();
            string value = keyValue[1].Trim();

            if (parameters.Contains("+"))
            {
                addValue(parameters);
            }
            else
            {
                try
                {
                    keyValuePairs[key] = int.Parse(value);
                }
                catch (Exception e) 
                {
                    errBox.Items.Insert(0, "ERROR: " + e.Message + " line: [" + parameters + "]");
                }  

            }
            
        }

        public VariableFunction(ListBox errBox, Canvas canvas, Script script):base(errBox, canvas, script)
        {
        }
    }
}
