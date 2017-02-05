using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Parser.commands
{
    public class HLT : Command
    {
        int address = BININ.Parser.BinaryDec.BinToDec("1011");
        public override void Execute()
        {
            Console.ReadKey();
            if (!Runtime.Runtime.Shell)
                Environment.Exit(0);
            else
                Console.WriteLine("Exit: "+Runtime.Registers.GetRegister(1).GetValue());
        }

        public override int GetAddress()
        {
            return address;
        }
    }
}
