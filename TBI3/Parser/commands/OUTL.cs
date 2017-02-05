using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Parser.commands
{
    class OUTL : Command
    {
        public override void Execute()
        {
            Console.WriteLine(Runtime.Stack.GetFromStack());
        }

        public override int GetAddress()
        {
            return 21;
        }
    }
}
