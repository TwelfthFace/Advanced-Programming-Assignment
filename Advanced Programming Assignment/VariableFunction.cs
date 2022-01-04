using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Advanced_Programming_Assignment
{
    public class VariableFunction : Function
    {
       protected Dictionary<string,string> keyValuePairs = new Dictionary<string,string>();

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

        public string findValue(string key)
        {
            string value;
            keyValuePairs.TryGetValue(key, out value);
            return value;
        }

        public string substituteValues(string command, string value)
        {
            //bool regexCommand = Regex.IsMatch(command, @"\b(" + value + @")\b");
            string regexCommand = Regex.Replace(command, @"\b(" + value + @")\b", findValue(value), RegexOptions.IgnorePatternWhitespace, TimeSpan.FromSeconds(.25));
            return regexCommand;
        }

        public override void enumerateCommands(string parameters)
        {
            string[] keyValue = parameters.Split("=");
            string key = keyValue[0].Trim();
            string value = keyValue[1].Trim();
            if (!keyValuePairs.ContainsKey(key))
            {
                keyValuePairs.Add(key, value);
            }
        }

        public VariableFunction(ListBox errBox, Canvas canvas) : base(errBox, canvas){}
    }
}
