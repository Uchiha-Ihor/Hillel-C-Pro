using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LB3.Task_1;
using LB3.Task_2;

namespace LB3
{
    internal partial class MyArray (int[] array) : IOutput
    {

        public void Show()
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");
        }

        public void Show(string info)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n", "Information: " + info + "\n");
        }

    }
}
