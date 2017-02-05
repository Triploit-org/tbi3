using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Parser.commands
{
    public class OTS : Command
    {
        public override void Execute()
        {
            if (!Runtime.Registers.ExistsRegister(Runtime.Runtime.GetArg1()))
                Console.WriteLine("OTS: Error: Register {0} doesn't exist!", Runtime.Runtime.GetArg1());
            else
                Runtime.Stack.PushToStack(Runtime.Registers.GetRegister(Runtime.Runtime.GetArg1()).GetValue());
        }

        public override int GetAddress()
        {
            return 24;
        }
    }
}
