using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Parser.commands
{
    class NTS : Command
    {
        public override void Execute()
        {
            Runtime.Stack.PushToStack(Runtime.Runtime.GetArg1());
        }

        public override int GetAddress()
        {
            return 23;
        }
    }
}
