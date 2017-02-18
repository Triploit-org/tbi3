using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BININ.Runtime
{
    public static class Runtime
    {
        private static bool init = false;
        private static int arg1 = 0;
        private static int arg2 = 0;
        public static bool Shell = false;
        public static int Line = 1;
        public static bool ConvertOutPut = true;
        public static bool Loop = true;
        public static bool ParserExit = false;
        public static bool Parser = false;
        public static bool LoopThreadManagerRunning = false;
        private static Thread Controler = new Thread(LoopThreadManager);

        /*do {
    while (! Console.KeyAvailable) {
        // Do something
   }
} while (Console.ReadKey(true).Key != ConsoleKey.Escape);*/

        public static void LoopThreadManager()
        {
            // Console.WriteLine("RUNTIME: Gestartet!");
            // Console.ReadKey();

            while (true)
            {
                if (Parser)
                {
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        ParserExit = true;
                    }
                }
            }
        }

        public static void ControlerStart()
        {
            if (Loop && !LoopThreadManagerRunning)
            {
                LoopThreadManagerRunning = true;
                Controler.Start();
            }
        }
        public static void ControlerAbort()
        {
            if (LoopThreadManagerRunning)
            {
                LoopThreadManagerRunning = false;
                Controler.Abort();
            }
        }

        public static void Argument(int a)
        {
            int a1 = arg1;

            arg1 = a;
            arg2 = a1;
        }

        public static int GetArg1()
        {
            return arg1;
        }
        public static int GetArg2()
        {
            return arg2;
        }

        public static void InitRuntime()
        {
            if (!init)
            {
                init = true;

                Registers.AddRegister(new Register("ax", 0, 1));
                Registers.AddRegister(new Register("bx", 0, 2));
                Registers.AddRegister(new Register("cx", 0, 3));
                Registers.AddRegister(new Register("dx", 0, 4));
                Registers.AddRegister(new Register("ex", 0, 5));
                Registers.AddRegister(new Register("fx", 0, 6));
                Registers.AddRegister(new Register("gx", 0, 7));
                Registers.AddRegister(new Register("hx", 0, 8));

                Commands.AddCommands(new Parser.commands.CLS());
                Commands.AddCommands(new Parser.commands.HLT());
                Commands.AddCommands(new Parser.commands.STA());
                Commands.AddCommands(new Parser.commands.MOV());
                Commands.AddCommands(new Parser.commands.ADD());
                Commands.AddCommands(new Parser.commands.ATS());
                Commands.AddCommands(new Parser.commands.OUT());
                Commands.AddCommands(new Parser.commands.ATS());
                Commands.AddCommands(new Parser.commands.MUL());
                Commands.AddCommands(new Parser.commands.DIV());
                Commands.AddCommands(new Parser.commands.SUB());
                Commands.AddCommands(new Parser.commands.PTC());
                Commands.AddCommands(new Parser.commands.INP());
                Commands.AddCommands(new Parser.commands.OUTL());
                Commands.AddCommands(new Parser.commands.MOD());
                Commands.AddCommands(new Parser.commands.NTS());
                Commands.AddCommands(new Parser.commands.OTS());
                Commands.AddCommands(new Parser.commands.STO());
                Commands.AddCommands(new Parser.commands.POP());
            }
            else
            {
                RuntimePanic("(Runtime.cs).InitRuntime");
            }
        }
        
        public static void RuntimePanic(string err)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("BININ.Runtime.Runtime.RuntimePanic: FATAL ERROR:\n\t" +
                "!! Runtime Error in ...\n\t   ... "+err);
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Gray;

            if (!Runtime.Shell)
                Environment.Exit(1);
        }

        public static string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
