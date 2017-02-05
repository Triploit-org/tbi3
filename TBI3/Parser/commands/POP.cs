using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Parser.commands
{
    class POP : Command
    {
        public override void Execute()
        {
            Runtime.Stack.Pop();
        }

        public override int GetAddress()
        {
            return 26;
        }
    }
}
