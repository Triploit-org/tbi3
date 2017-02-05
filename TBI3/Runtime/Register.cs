using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BININ.Runtime
{
    public class Register
    {
        private int value;
        private string name;
        int address;

        public Register(string name, int value, int address)
        {
            this.value = value;
            this.name = name;
            this.address = address;
        }

        public int GetValue()
        {
            return value;
        }

        public void SetValue(int num)
        {
            value = num;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string s)
        {
            name = s;
        }

        public void SetAdress(int adr)
        {
            address = adr;
        }

        public int GetAddress()
        {
            return address;
        }
    }
}
