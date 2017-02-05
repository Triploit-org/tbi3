using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Runtime
{
    public static class Stack
    {
        private static List<int> bin_stack = new List<int>();

        public static void PushToStack(int num)
        {
            bin_stack.Add(num);
        }

        public static int GetFromStack()
        {
            if (bin_stack.Count == 0)
                return 0;

            int num = 0;
            num = bin_stack[bin_stack.Count - 1];
            // Console.WriteLine("BININ.Stack.GetFromStack: Stack_Size = "+bin_stack.Count);
            return num;
        }

        public static int GetFromStack(int i)
        {
            if (bin_stack.Count == 0)
                return 0;

            int num = 0;
            num = bin_stack[bin_stack.Count - (1+i)];
            // Console.WriteLine("BININ.Stack.GetFromStack: Stack_Size = "+bin_stack.Count);
            return num;
        }

        public static void Pop()
        {
            if (bin_stack.Count > 0)
                bin_stack.RemoveAt(bin_stack.Count - 1);
        }

        public static void ClearStack()
        {
            bin_stack.Clear();
        }

        public static void OutPutStack()
        {
            for (int i = (bin_stack.Count-1); i >= 0; i--)
            {
                Console.WriteLine("[{0}] {1}", i, bin_stack[i]);
            }
        }
    }
}
