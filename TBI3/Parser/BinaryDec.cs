using System;
using System.Collections.Generic;
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
    }
}
