using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Advanced_Programming_Assignment
{
    public class VariableFunction : Function
    {
        Dictionary<string,string> keyValuePairs = new Dictionary<string,string>();

        public override bool run(string parameters)
        {
            throw new NotImplementedException();
        }

        public string findValue(string key)
        {
            string value;
            keyValuePairs.TryGetValue(key, out value);
            return value;
        }

        public override void enumerateCommands(string parameters)
        {
            string[] keyValue = parameters.Split("=");
            string key = keyValue[0].Trim();
            string value = keyValue[1].Trim();
            keyValuePairs.Add(key, value);
        }

        public VariableFunction(ListBox errBox, Canvas canvas) : base(errBox, canvas){}
    }
}
