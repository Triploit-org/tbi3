using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Parser
{
    abstract public class Command
    {
        int address;

        abstract public void Execute();
        abstract public int GetAddress();
    }
}
