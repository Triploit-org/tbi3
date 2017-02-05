using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Parser.commands
{
    class OUT : Command
    {
        public override void Execute()
        {
            Console.Write(Runtime.Stack.GetFromStack());
        }

        public override int GetAddress()
        {
            return 18;
        }
    }
}
