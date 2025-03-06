using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB3.Task_3
{
    internal interface ISort
    {

        public void SortAsc();
        public void SortDesc();
        public void SortByParam(bool isAsc);

    }
}
