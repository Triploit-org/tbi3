using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Runtime
{
    public static class Registers
    {
        private static List<Register> bin_registers = new List<Register>();

        public static bool ExistsRegister(Register name)
        {
            if (bin_registers.Contains(name))
                return true;

            return false;
        }

        public static bool ExistsRegister(int name)
        {
            for (int i = 0; i < bin_registers.Count; i++)
            {
                if (bin_registers[i].GetAddress() == name)
                {
                    return true;
                }
            }

            return false;
        }

        public static Register GetRegister(int addr)
        {
            for (int i = 0; i < bin_registers.Count; i++)
            {
                if (bin_registers[i].GetAddress() == addr)
                {
                    return bin_registers[i];
                }
            }

            return (new Register("NULL", 0, -999));
        }

        public static void AddRegister(Register r)
        {
            if (!ExistsRegister(r))
            {
                bin_registers.Add(r);
            }
            else
            {
                Runtime.RuntimePanic("(Registers.cs).AddRegisters(x)");
            }
        }

        public static void SetRegister(int addr, int value)
        {
            foreach (Register i in bin_registers)
            {
                if (i.GetAddress() == addr)
                {
                    i.SetValue(value);
                    // Console.WriteLine("[ REGISTERS ] "+i.GetName() + " = " + value);
                    return;
                }
            }

            Runtime.RuntimePanic("(Registers.cs).SetRegisters(x, y)");
        }

        public static Register[] GetRegisterValues()
        {
            return bin_registers.ToArray();
        }

    }
}
