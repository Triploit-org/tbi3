using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Runtime
{
    public static class Commands
    {
        private static List<Parser.Command> bin_commands = new List<Parser.Command>();

        public static bool ExistsCommand(Parser.Command name)
        {
            if (bin_commands.Contains(name))
                return true;

            return false;
        }

        public static bool ExistsCommand(int address)
        {
            for (int i = 0; i < bin_commands.Count; i++)
            {
                if (bin_commands[i].GetAddress() == address)
                {
                    return true;
                }
            }
            return false;
        }

        public static void AddCommands(Parser.Command r)
        {
            if (!ExistsCommand(r))
            {
                bin_commands.Add(r);
            }
            else
            {
                Runtime.RuntimePanic("(Commands.cs).AddCommands(x)");
            }
        }

        public static void RunCommand(int address)
        {
            for (int i = 0; i < bin_commands.Count; i++)
            {
                if (bin_commands[i].GetAddress() == address)
                {
                    bin_commands[i].Execute();
                    return;
                }
            }
        }
    }
}
