using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB3.Task_2
{
    internal interface IMath
    {

        public int Max();
        public int Min();

        public float Avg();

        public bool Search(int valueToSearch);
    }
}
