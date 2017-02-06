using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Parser
{
    public static class BinaryDec
    {
        public static string DecToBin(int num)
        {
            return Runtime.Runtime.ReverseString(Convert.ToString(num, 2));
        }
        public static int BinToDec(string num)
        {
            try
            {
                return Convert.ToInt32(Runtime.Runtime.ReverseString(num), 2);
            }
            catch
            {
                Runtime.Runtime.RuntimePanic("(BinaryDec.cs).BinToDex(x)\n\t   Invalid Binarynumber \""+num+"\"!");
                return 0;
            }
        }

        public static void ExecuteBinaryFile(string code)
        {
            string _if = code;
            BinaryReader rdr = new BinaryReader(new FileStream(_if, FileMode.Open));
            int i;
            string c = "";

            try
            {
                while (true)
                {
                    i = rdr.ReadInt32();
                    c = c + BinaryDec.DecToBin(i) + " \n";
                }
            }
            catch (EndOfStreamException)
            {
                rdr.Close();
                // Console.WriteLine(c);

                Tokenizer tt = new Tokenizer(c);
                Parser pp = new Parser(tt.Tokenize());
                pp.Parse();
            }
        }

        public static string BinaryFileToBinaryString(string filename)
        {
            string _if = filename;
            BinaryReader rdr = new BinaryReader(new FileStream(_if, FileMode.Open));
            int i;
            string c = "";

            try
            {
                while (true)
                {
                    i = rdr.ReadInt32();
                    c = c + BinaryDec.DecToBin(i) + " \n";
                }
            }
            catch (EndOfStreamException)
            {
                rdr.Close();
                return c;
            }
        }

        public static void ExecuteBinaryProgramm(string binarycode)
        {
            string[] line = binarycode.Split('\n');
            string code = "";

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
            Parser p1 = new Parser(t1.Tokenize());
            p1.Parse();
        }

        public static void WriteTBIBinaryProgrammToBinaryFile(string programm)
        {
            string _if = programm;
            string code = "";
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
            List<int> bits = new List<int>();

            for (int i = 0; i < line.Length; i++)
            {
                string bin = line[i];

                if (bin != "")
                    bits.Add(BinaryDec.BinToDec(bin.Trim()));

                text = text + bin + "\n";
                Runtime.Runtime.Line++;
            }
            string of = _if;
            string fname = of.Replace(".tbi", ".bin");

            BinaryWriter wrt = new BinaryWriter(new FileStream(fname, FileMode.Create));

            for (int i = 0; i < bits.Count; i++)
            {
                wrt.Write(bits[i]);
                Console.WriteLine(bits[i]);
            }

            wrt.Close();
        }
       
    }
}
