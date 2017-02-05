using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Parser.commands
{
    public class MOV : Command
    {
        int address = BININ.Parser.BinaryDec.BinToDec("0101");
        public override void Execute()
        {
            int arg2 = Runtime.Runtime.GetArg2();
            int arg1 = Runtime.Runtime.GetArg1();

            // Aufbau:          ARG2  ARG1         MOV
            //
            // Moeglichkeiten:  MOV   ARG2[W]  ->  ARG1[Z]
            //                  MOV   ARG2[Z]  ->  ARG1[Z]

            // 1000
            // 0100
            // 0101

            if (Runtime.Registers.ExistsRegister(arg1))
            {
                if (!Runtime.Registers.ExistsRegister(arg2))
                {
                    Runtime.Registers.SetRegister(arg1, arg2);
                }
                else
                {
                    Runtime.Registers.SetRegister(arg1, Runtime.Registers.GetRegister(arg2).GetValue());
                }
            }
            else
            {
                Console.WriteLine("MOV: Error: Register "+arg1+" doesn't exist!");
            }
        }

        public override int GetAddress()
        {
            return address;
        }
    }
}
