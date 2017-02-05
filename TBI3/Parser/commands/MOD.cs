using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Parser.commands
{
    class MOD : Command
    {
        public override void Execute()
        {
            int z1 = Runtime.Stack.GetFromStack();
            int z2 = Runtime.Stack.GetFromStack();
            //Console.WriteLine("Zahl1: " + z1 + "\nZahl2: " + z2);

            Runtime.Stack.PushToStack(z2 % z1);
        }

        public override int GetAddress()
        {
            return 22;
        }
    }
}
