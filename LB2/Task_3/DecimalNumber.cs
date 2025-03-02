using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB2.Task_3
{
    public struct DecimalNumber
    {
        public int Value;

        public DecimalNumber(int value)
        {
            Value = value;
        }

        public string ToBin()
        {
            return Convert.ToString(Value, 2);
        }

        public string ToOct()
        {
            return Convert.ToString(Value, 8);
        }

        public string ToHex()
        {
            return Convert.ToString(Value, 16).ToUpper();
        }
    }



}
