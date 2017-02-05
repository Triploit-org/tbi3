using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Parser.commands
{
    class MUL : Command
    {
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


            int z1 = Runtime.Stack.GetFromStack();
            int z2 = Runtime.Stack.GetFromStack(1);
            //Console.WriteLine("Zahl1: " + z1 + "\nZahl2: " + z2);

            Runtime.Stack.PushToStack(z2 * z1);
        }

        public override int GetAddress()
        {
            return 15;
        }
    }
}
