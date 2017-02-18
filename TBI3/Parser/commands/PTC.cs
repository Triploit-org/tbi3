using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Parser.commands
{
    class PTC : Command
    {
        public override void Execute()
        {
            // Console.Write(Runtime.Stack.GetFromStack());
            Console.Write((char) Runtime.Stack.GetFromStack());
        }

        public override int GetAddress()
        {
            return 20;
        }
    }
}
