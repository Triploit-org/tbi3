using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Parser.commands
{
    class INP : Command
    {
        public override void Execute()
        {
            string d = Console.ReadLine();

            try
            {
                int num = Int32.Parse(d);
                Runtime.Stack.PushToStack(num);
            }
            catch
            {
                Console.WriteLine("INP: Error: Die Eingabe muss eine Zahl sein!");
            }
        }

        public override int GetAddress()
        {
            return 19;
        }
    }
}
