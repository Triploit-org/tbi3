using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BININ.Parser
{
    public class Parser
    {
        private List<int> code;
        private int li = 0;

        public Parser(List<int> commands)
        {
            this.code = commands;
        }

        public void Parse()
        {
            Runtime.Runtime.ParserExit = false;
            Runtime.Runtime.Parser = true;


            for (int i = 0; i < code.Count; i++)
            {
                // Console.WriteLine("CMD: "+code[i]);
                if (Runtime.Runtime.ParserExit)
                {
                    Runtime.Runtime.ParserExit = false;
                    Runtime.Runtime.Parser = false;
                    break;
                }

                if (li == 0)
                    li = i;

                if (Runtime.Commands.ExistsCommand(code[i]))
                {
                    Runtime.Commands.RunCommand(code[i]);
                }
                else if (code[i] == 27)
                {
                    li = i;
                    // Console.WriteLine("Setze Marke");
                }
                else if (code[i] == 28)
                {
                    if (Runtime.Registers.GetRegister(8).GetValue() != 0)
                    {
                        i = li;
                        // Console.WriteLine("HX!0; Gehe zu: " + li);
                    }
                }
                else if (code[i] == 29)
                {
                    if (Runtime.Registers.GetRegister(8).GetValue() == 0)
                    {
                        i = li;
                        // Console.WriteLine("HX=0; Gehe zu: " + li);
                    }
                }
                else if (code[i] == 30)
                {
                    if (Runtime.Registers.GetRegister(8).GetValue() < 0)
                    {
                        i = li;
                        // Console.WriteLine("HX<0; Gehe zu: " + li);
                    }
                }
                else if (code[i] == 31)
                {
                    if (Runtime.Registers.GetRegister(8).GetValue() > 0)
                    {
                        i = li;
                        // Console.WriteLine("HX>0; Gehe zu: " + li);
                    }
                }
                else
                {
                    // Console.WriteLine("[ Parser ] Kein Befehl: {0}", code[i]);
                    Runtime.Runtime.Argument(code[i]);
                }
            }

            Runtime.Runtime.Parser = false;
        }
    }
}
