using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Parser
{
    public static class Converter
    {
        private static List<string> bin_ops = new List<string>();
        private static List<string> norm_ops = new List<string>();

        private static void add(string from, string to)
        {
            norm_ops.Add(from);
            bin_ops.Add(to);
        }

        public static bool IsConvertAble(string command)
        {
            if (norm_ops.Contains(command))
                return true;
            return false;
        }

        public static void Init()
        {
            add("AX", " 10000000 ");
            add("BX", " 01000000 ");
            add("CX", " 11000000 ");
            add("DX", " 00100000 ");
            add("EX", " 10100000 ");
            add("FX", " 01100000 ");
            add("GX", " 11100000 ");
            add("HX", " 00010000 ");
            add("ADD", " 10010000 ");
            add("MOV", " 01010000 ");
            add("ATS", " 11010000 ");
            add("STA", " 00110000 ");
            add("HLT", " 10110000 ");
            add("CLS", " 01110000 ");
            add("MUL", " 11110000 ");
            add("DIV", " 00001000 ");
            add("SUB", " 10001000 ");
            add("OUT", " 01001000 ");
            add("INP", " 11001000 ");
            add("PTC", " 00101000 ");
            add("OUTL", " 10101000 ");
            add("MOD", " 01101000 ");
            add("NTS", " 11101000 ");
            add("OTS", " 00011000 ");
            add("STO", " 10011000 ");
            add("POP", " 01011000 ");
            add("MRK", " 11011000 ");
            add("JNN", " 00111000 ");
            add("JEN", " 10111000 ");
            add("JLN", " 01111000 ");
            add("JGN", " 11111000 ");
        }

        public static string Parse(string code)
        {
            code = code.Trim();

            if (code.Split(' ').Length > 1)
            {
                // Console.WriteLine("CONVERTER: Error: There may be only one word per line!");

                Runtime.Runtime.RuntimePanic("(Converter.cs).Parse(x)\n\t   Error at Line " + Runtime.Runtime.Line + ": \n\t   There may be only one word per line, there are more:\n\t   " + code + "");
                Environment.Exit(0);
                return "";
            }

            if (code == "")
                return "";

            for (int i = 0; i < norm_ops.Count; i++)
            {
                if (norm_ops[i].ToLower().Equals(code.ToLower()))
                {
                    code = code.Replace(code, bin_ops[i]);
                    if (Runtime.Runtime.ConvertOutPut)
                        Console.WriteLine(code);
                    return code;
                }
            }

            try
            {
                int c = Convert.ToInt32(code);
                string bin = BinaryDec.DecToBin(c);
                if (Runtime.Runtime.ConvertOutPut)
                    Console.WriteLine(" "+bin);
                return (" "+bin);
            }
            catch
            {
                Runtime.Runtime.RuntimePanic("(Converter.cs).Parse(x)\n\t   Error at Line " +Runtime.Runtime.Line+": \n\t   Not convertable command:\n\t   "+code);
                Environment.Exit(0);
            }
            return "";
        }
    }
}
