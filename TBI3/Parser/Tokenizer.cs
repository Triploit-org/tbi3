using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Parser
{
    public class Tokenizer
    {
        private string codeStr = "";

        public Tokenizer(string s)
        {
            codeStr = s;
        }

        public List<int> Tokenize()
        {
            string s = codeStr;
            s = s.Trim();
            string[] code;
            List<int> commands = new List<int>();

            for (int i = 0; i < s.Length; i++)
            {
                s = s.Replace("  ", " ");
                s = s.Replace("\n", " ");
                s = s.Replace("\n\n", " ");
                s = s.Replace("\t", " ");

                char[] c = s.ToCharArray();
                s = "";
                bool kmt = false;

                for (int i2 = 0; i2 < c.Length; i2++)
                {
                        s = s + c[i2];
                }
            }

            code = s.Split(' ');

            for (int i = 0; i < code.Length; i++)
            {
                commands.Add(BININ.Parser.BinaryDec.BinToDec(code[i]));
                // Console.WriteLine("[ Tokenizer ] Konvertiere {0} in {1}", code[i], BININ.Parser.BinaryDec.BinToDec(code[i]));
            }

            return commands;
        }
    }
}
