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

        public override void enumerateCommands(string parameters)
        {
            string[] keyValue = parameters.Split("=");
            keyValuePairs.Add(keyValue[0], keyValue[2]);
         
        }

        public VariableFunction(ListBox errBox, Canvas canvas) : base(errBox, canvas){}
    }
}
