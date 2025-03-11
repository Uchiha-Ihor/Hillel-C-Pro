using LB4.Task_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB4.Task_2
{
    internal class City(int _inhabitants) : ObjectService<City>(_inhabitants)
    {
        private int inhabitants = _inhabitants;


        protected override City CreateInstance(int newValue)
        {
            return new City(newValue);
        }
    }
}
