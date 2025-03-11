using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LB4.Task_1
{
    internal class Employee (int _salary) : ObjectService<Employee>(_salary)
    {
        int salary = _salary;

        protected override Employee CreateInstance(int newValue)
        {
            return new Employee(newValue);
        }
        
    }
}
