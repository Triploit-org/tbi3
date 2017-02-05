using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Parser.commands
{
    public class ATS : Command
    {
        int address = BININ.Parser.BinaryDec.BinToDec("1101");
        public override void Execute()
        {
            Runtime.Stack.PushToStack(Runtime.Registers.GetRegister(1).GetValue());
        }

        public override int GetAddress()
        {
            return address;
        }
    }
}
