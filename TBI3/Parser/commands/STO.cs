using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Parser.commands
{
    class STO : Command
    {
        public override void Execute()
        {
            if (!Runtime.Registers.ExistsRegister(Runtime.Runtime.GetArg1()))
                Console.WriteLine("STO: Error: Register {0} doesn't exist!", Runtime.Runtime.GetArg1());
            else
                Runtime.Registers.SetRegister(Runtime.Runtime.GetArg1(), Runtime.Stack.GetFromStack());
        }

        public override int GetAddress()
        {
            return 25;
        }
    }
}
