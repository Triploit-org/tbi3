using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Parser.commands
{
    public class STA : Command
    {
        int address = BININ.Parser.BinaryDec.BinToDec("0011");
        public override void Execute()
        {
            Runtime.Registers.SetRegister(1, Runtime.Stack.GetFromStack());
        }

        public override int GetAddress()
        {
            return address;
        }
    }
}
