using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Parser.commands
{
    public class CLS : Command
    {
        int address = BININ.Parser.BinaryDec.BinToDec("0111");
        public override void Execute()
        {
            while (Runtime.Stack.GetFromStack() != 0)
            { Runtime.Stack.Pop();  }
        }

        public override int GetAddress()
        {
            return 14;
        }
    }
}
