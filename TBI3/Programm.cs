using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BININ.Runtime;
using BININ.Parser;
using System.IO;
using System.Threading;

namespace BININ
{
    class Programm
    {
        static void Main(string[] args)
        {
            Runtime.Runtime.InitRuntime();
            Parser.Converter.Init();
            List<string> mcode = new List<string>();

            Thread th = new Thread(Runtime.Runtime.LoopThreadManager);
            th.Start();

            if (args.Length < 1)
            {
                while (true)
                {
                    Runtime.Runtime.Shell = true;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(Directory.GetCurrentDirectory()+"\n > ");
                    Console.ForegroundColor = ConsoleColor.White;

                    string code = "0000000";
                    code = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    code = code.Trim();

                    if (code.StartsWith("d:"))
                    {
                        code = code.Replace("d:", "");
                        code = Parser.BinaryDec.DecToBin(Convert.ToInt32(code));
                    }

                    if (Converter.IsConvertAble(code.ToUpper()))
                    {
                        Runtime.Runtime.ConvertOutPut = false;
                        code = Converter.Parse(code).Trim();
                        Runtime.Runtime.ConvertOutPut = true;
                    }

                    switch (code)
                    {
                        case ".a":
                            Console.WriteLine("Argument 1: " + Runtime.Runtime.GetArg1());
                            Console.WriteLine("Argument 2: " + Runtime.Runtime.GetArg2());
                            continue;
                        case ".s":
                            Runtime.Stack.OutPutStack();
                            continue;
                        case "s":
                            Runtime.Stack.OutPutStack();
                            continue;
                        case ",s":
                            Runtime.Stack.OutPutStack();
                            continue;
                        case ".r":
                            Register[] r = Registers.GetRegisterValues();
                            for (int i = 0; i < r.Length; i++)
                            {
                                Console.WriteLine(r[i].GetName() + ": " + Parser.BinaryDec.DecToBin(r[i].GetValue()) + "\t| " + r[i].GetValue());
                            }
                            continue;
                        case ",a":
                            Console.WriteLine("Argument 1: " + Runtime.Runtime.GetArg1());
                            Console.WriteLine("Argument 2: " + Runtime.Runtime.GetArg2());
                            continue;
                        case ",r":
                            Register[] r2 = Registers.GetRegisterValues();
                            for (int i = 0; i < r2.Length; i++)
                            {
                                Console.WriteLine(r2[i].GetName() + ": " + Parser.BinaryDec.DecToBin(r2[i].GetValue()) + "\t| " + r2[i].GetValue());
                            }
                            continue;
                        case "a":
                            Console.WriteLine("Argument 1: " + Runtime.Runtime.GetArg1());
                            Console.WriteLine("Argument 2: " + Runtime.Runtime.GetArg2());
                            continue;
                        case "r":
                            Register[] r3 = Registers.GetRegisterValues();

                            for (int i = 0; i < r3.Length; i++)
                            {
                                Console.WriteLine(r3[i].GetName() + ": " + Parser.BinaryDec.DecToBin(r3[i].GetValue()) + "\t| " + r3[i].GetValue());
                            }
                            continue;
                        case ".l":
                            for (int i = 0; i < mcode.Count; i++)
                            {
                                Console.WriteLine(mcode[i]);
                            }
                            continue;

                        case ",l":
                            for (int i = 0; i < mcode.Count; i++)
                            {
                                Console.WriteLine(mcode[i]);
                            }
                            continue;

                        case "l":
                            for (int i = 0; i < mcode.Count; i++)
                            {
                                Console.WriteLine(mcode[i]);
                            }
                            continue;
                        case ".ls":
                            string[] fileEntries = Directory.GetFiles(Directory.GetCurrentDirectory());
                            foreach (string fileName in fileEntries)
                                Console.WriteLine(fileName.Replace(Directory.GetCurrentDirectory() + "\\", ""));
                            fileEntries = Directory.GetDirectories(Directory.GetCurrentDirectory());
                            foreach (string fileName in fileEntries)
                                Console.WriteLine(fileName.Replace(Directory.GetCurrentDirectory() + "\\", "")+"\\");
                            continue;
                        case "ls":
                            string[] fileEntries2 = Directory.GetFiles(Directory.GetCurrentDirectory());
                            foreach (string fileName in fileEntries2)
                                Console.WriteLine(fileName.Replace(Directory.GetCurrentDirectory()+"\\", ""));
                            fileEntries2 = Directory.GetDirectories(Directory.GetCurrentDirectory());
                            foreach (string fileName in fileEntries2)
                                Console.WriteLine(fileName.Replace(Directory.GetCurrentDirectory() + "\\", "") + "\\");
                            continue;
                        case ".help":
                            Console.WriteLine(
                                "This shell is a binary interpreter\n" +
                                "and BASM-Converter. (BASM is the Assembly Language\n" +
                                "of this Runtime.)\n" +
                                "  .l         - Lists all inputs.\n" +
                                "  .r         - Lists all register and their value.\n" +
                                "  .s         - Lists the stack.\n" +
                                "  .c [File] - Convert BASM to Binary.\n" +
                                "  .o [File] - Open and runs a TBI-Binary file.\n" +
                                "  .q         - Quit.\n" +
                                "  [File]    - A TBI-Binaryfile can be opened by its name\n" +
                                "               (without or with \".bin\"-Ending).\n" +
                                "  .f         - Get Text from File." +
                                "");
                            continue;
                        case "help":
                            Console.WriteLine(
                                "This shell is a binary interpreter\n" +
                                "and BASM-Converter. (BASM is the Assembly Language\n" +
                                "of this Runtime.)\n" +
                                "  .l         - Lists all inputs.\n" +
                                "  .r         - Lists all register and their value.\n" +
                                "  .s         - Lists the stack.\n" +
                                "  .c [File] - Convert BASM to Binary.\n" +
                                "  .o [File] - Open and runs a TBI-Binary file.\n" +
                                "  .q         - Quit.\n" +
                                "  [File]    - A TBI-Binaryfile can be opened by its name\n" +
                                "               (without or with \".bin\"-Ending).\n" +
                                "  .f         - Get Text from File." +
                                "");
                            continue;
                        case ",help":
                            Console.WriteLine(
                                "This shell is a binary interpreter\n" +
                                "and BASM-Converter. (BASM is the Assembly Language\n" +
                                "of this Runtime.)\n" +
                                "  .l         - Lists all inputs.\n" +
                                "  .r         - Lists all register and their value.\n" +
                                "  .s         - Lists the stack.\n" +
                                "  .c [File] - Convert BASM to Binary.\n" +
                                "  .o [File] - Open and runs a TBI-Binary file.\n" +
                                "  .q         - Quit.\n" +
                                "  [File]    - A TBI-Binaryfile can be opened by its name\n" +
                                "               (without or with \".bin\"-Ending).\n" +
                                "  .f         - Get Text from File."+
                                "");
                            continue;
                    }

                    if (code.StartsWith(".f "))
                    {
                        string f = code.Replace(".f ", "");

                        if (File.Exists(f))
                        {
                            Console.WriteLine(File.ReadAllText(f));
                            continue;
                        }
                        else
                        {
                            Runtime.Runtime.RuntimePanic("(Programm.cs).Main(x[])\n\t   File not found!");
                            continue;
                        }
                    }

                    if (code == ".q" || code == "q" || code == ",q")
                    {
                        string ans = "";

                        while (ans.ToLower() != "yes" && ans.ToLower() != "no" && ans.ToLower() != "cancel")
                        {
                            Console.Write("Do you want to save your input?\n(Yes/No/Cancel) ");
                            ans = Console.ReadLine();
                        }

                        if (ans.ToLower() == "yes")
                        {
                            Console.Write("Filename? ");
                            File.WriteAllLines(Console.ReadLine(), mcode.ToArray());
                        }
                        else if (ans.ToLower() == "cancel")
                        {
                            continue;
                        }
                        else
                        {
                            Environment.Exit(0);
                        }

                        break;
                    }

                    if (code.StartsWith(".cd ") || code.StartsWith("cd "))
                    {
                        string cd = code.Replace(".cd ", "");
                        cd = code.Replace("cd ", "");

                        if (Directory.Exists(cd))
                            Directory.SetCurrentDirectory(cd);
                        else
                            Runtime.Runtime.RuntimePanic("(Programm.cs).Main(x[])\n\t   Directory \""+cd+"\" doesn't exists!");
                        continue;
                    }

                    if (code.StartsWith(".o "))
                    {
                        code = code.Replace(".o ", "");

                        if (!File.Exists(code))
                            Runtime.Runtime.RuntimePanic("(Programm.cs).Main(x[])\n\t   File not found!");

                        if (!code.EndsWith(".bin"))
                        {
                            code = code + ".bin";
                        }

                        string[] line;
                        line = File.ReadAllLines(code);
                        code = "00000000";

                        for (int i = 0; i < line.Length; i++)
                        {
                            if (line[i] == "" || line[i] == "\n" || line[i] == " \n")
                                continue;

                            if (!line[i].Trim().StartsWith("#"))
                            {
                                char[] cs = line[i].ToCharArray();
                                line[i] = "";

                                for (int i2 = 0; i2 < cs.Length; i2++)
                                {
                                    if (cs[i2] != '#')
                                    {
                                        line[i] = line[i] + cs[i2];
                                    }
                                    else
                                        break;
                                }

                                code = code + " " + line[i].Trim();
                            }
                        }

                        Tokenizer t1 = new Tokenizer(code);
                        Parser.Parser p1 = new Parser.Parser(t1.Tokenize());
                        p1.Parse();

                        continue;
                    }
                    else if (code.StartsWith(".c "))
                    {
                        string _if = code.Replace(".c ", "");
                        if (!File.Exists(_if))
                        {
                            Runtime.Runtime.RuntimePanic("(Programm.cs).Main(x[])\n\t   File not found!");
                            continue;
                        }

                        string[] line = File.ReadAllLines(_if);

                        for (int i = 0; i < line.Length; i++)
                        {
                            if (line[i] == "" || line[i] == "\n" || line[i] == " \n")
                                continue;

                            if (!line[i].Trim().StartsWith("#"))
                            {
                                char[] cs = line[i].ToCharArray();
                                line[i] = "";

                                for (int i2 = 0; i2 < cs.Length; i2++)
                                {
                                    if (cs[i2] != '#')
                                    {
                                        line[i] = line[i] + cs[i2];
                                    }
                                    else
                                        break;
                                }

                                code = code + " " + line[i].Trim();
                            }
                            else
                                line[i] = "";
                        }

                        string text = "";
                        for (int i = 0; i < line.Length; i++)
                        {
                            text = text + Parser.Converter.Parse(line[i]) + "\n";
                            Runtime.Runtime.Line++;
                        }
                        string of = _if;

                        if (of.EndsWith(".bsm"))
                            File.WriteAllText(of.Replace(".bsm", ".bin"), text);
                        else
                            File.WriteAllText(of+".bin", text);

                        continue;
                    }
                    else
                    {
                        if (File.Exists(code) || File.Exists((code + ".bin")))
                        {
                            if (!File.Exists(code))
                                code = code + ".bin";

                            string[] line;
                            line = File.ReadAllLines(code);
                            code = "00000000";

                            for (int i = 0; i < line.Length; i++)
                            {
                                if (line[i] == "" || line[i] == "\n" || line[i] == " \n")
                                    continue;

                                if (!line[i].Trim().StartsWith("#"))
                                {
                                    char[] cs = line[i].ToCharArray();
                                    line[i] = "";

                                    for (int i2 = 0; i2 < cs.Length; i2++)
                                    {
                                        if (cs[i2] != '#')
                                        {
                                            line[i] = line[i] + cs[i2];
                                        }
                                        else
                                            break;
                                    }

                                    code = code + " " + line[i].Trim();
                                }
                            }

                            Tokenizer t1 = new Tokenizer(code);
                            Parser.Parser p1 = new Parser.Parser(t1.Tokenize());
                            p1.Parse();

                            continue;
                        }
                        else if (code.EndsWith(".bin"))
                        {
                            Console.WriteLine("MAIN: Error: Programm \"{0}\" doesn't exists!", code);
                            continue;
                        }
                    }

                    if (code == "" || code == "\n")
                        code = "00000000";

                    Tokenizer t = new Tokenizer(code);
                    Parser.Parser p = new Parser.Parser(t.Tokenize());
                    p.Parse();
                    mcode.Add(code);
                }
            }
            else
            {
                string code = "00000000";
                string[] line;
                line = File.ReadAllLines(args[0]);

                if (args[0].Trim().EndsWith(".bsm"))
                {
                    string _if = args[0];
                    if (!File.Exists(_if))
                    {
                        Console.WriteLine("MAIN: Error: File not found!");
                        return;
                    }

                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == "" || line[i] == "\n" || line[i] == " \n")
                            continue;

                        if (!line[i].Trim().StartsWith("#"))
                        {
                            char[] cs = line[i].ToCharArray();
                            line[i] = "";

                            for (int i2 = 0; i2 < cs.Length; i2++)
                            {
                                if (cs[i2] != '#')
                                {
                                    line[i] = line[i] + cs[i2];
                                }
                                else
                                    break;
                            }

                            code = code + " " + line[i].Trim();
                        }
                        else
                            line[i] = "";
                    }

                    string text = "";
                    for (int i = 0; i < line.Length; i++)
                    {
                        text = text + Parser.Converter.Parse(line[i]) + "\n";
                        Runtime.Runtime.Line++;
                    }
                    string of = _if;

                    if (of.EndsWith(".bsm"))
                        File.WriteAllText(of.Replace(".bsm", ".bin"), text);
                    else
                        File.WriteAllText(of + ".bin", text);

                }
                else
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == "" || line[i] == "\n" || line[i] == " \n")
                            continue;

                        if (!line[i].Trim().StartsWith("#"))
                        {
                            char[] cs = line[i].ToCharArray();
                            line[i] = "";

                            for (int i2 = 0; i2 < cs.Length; i2++)
                            {
                                if (cs[i2] != '#')
                                {
                                    line[i] = line[i] + cs[i2];
                                }
                                else
                                    break;
                            }

                            code = code + " " + line[i].Trim();
                        }
                    }

                    Tokenizer t = new Tokenizer(code);
                    Parser.Parser p = new Parser.Parser(t.Tokenize());
                    p.Parse();
                }

            }

            Console.WriteLine("\n\n[PROGRAMM END]");
            Console.ReadKey();
            th.Abort();
            Environment.Exit(0);
        }
    }
}
