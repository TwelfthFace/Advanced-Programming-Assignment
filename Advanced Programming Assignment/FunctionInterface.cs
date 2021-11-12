using System;
using System.Collections.Generic;
using System.Text;

namespace Advanced_Programming_Assignment
{
    public interface FunctionInterface
    {

        bool run(string[] parameters);
        void enumerateCommands(params string[] parameters);

    }
}
