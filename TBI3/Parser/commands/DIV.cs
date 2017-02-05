using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Parser.commands
{
    class DIV : Command
    {
        public override void Execute()
        {

            // Aufbau:          ARG2  ARG1         MOV
            //
            // Moeglichkeiten:  MOV   ARG2[W]  ->  ARG1[Z]
            //                  MOV   ARG2[Z]  ->  ARG1[Z]

            // 1000
            // 0100
            // 0101

			try
			{

                int z1 = Runtime.Stack.GetFromStack();
                int z2 = Runtime.Stack.GetFromStack(1);
                //Console.WriteLine("Zahl1: " + z1 + "\nZahl2: " + z2);

                Runtime.Stack.PushToStack(z2 / z1);
            }
			catch
			{
				Console.WriteLine("SUB: Warning: Es wurde versucht durch 0 zu teilen!");
				return;
			}
        }

        public override int GetAddress()
        {
            return 16;
        }
    }
}
