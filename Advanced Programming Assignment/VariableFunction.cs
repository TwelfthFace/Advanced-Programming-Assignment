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
            List<string> keys = new List<string>();
            foreach(string key in this.getKeys())
            {
                keys.Add(key.Trim());
            }
            foreach (string key in keys)
            {
                if (command.Contains(key+" +")){
                    string op = key;
                    foreach (string value in keys)
                    {
                        if (value.Equals(op)) {
                            string[] additionSum = command.Split('+');
                            string addition = additionSum[1].Trim();
                            int add = keyValuePairs[op];
                            int iterator = 0;
                            if (keys.Contains(addition))
                            {
                                iterator = add + keyValuePairs[addition];
                            }
                            else
                            {
                                iterator = add + int.Parse(addition);
                            }
                            keyValuePairs[key] = iterator;
                        }
                    }
                }
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

            if (!keyValuePairs.ContainsKey(key))
            {
                keyValuePairs.Add(key, int.Parse(value));
            }
        }

        public VariableFunction(ListBox errBox, Canvas canvas) : base(errBox, canvas){}
    }
}
