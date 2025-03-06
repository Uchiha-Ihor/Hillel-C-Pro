using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LB3.Task_1;
using LB3.Task_2;


namespace LB3
{
    internal partial class MyArray : IMath
    {

        public int Max() => array.Max();
        public int Min() => array.Min();
        public float Avg() => (float)array.Average();
        public bool Search(int valueToSearch) => array.Contains(valueToSearch);

    }
}
