using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LB8
{
    public class Program
    {
        //Thread BarberShop;

        static void Main()
        {
            Console.WriteLine("Enter numbers of seats in Barber Shop");
            int number_of_seats = Convert.ToInt32(Console.ReadLine());

            BarberShop barberShop = new BarberShop(number_of_seats);

            while (true)
            {
                barberShop.AddVisitors();
            }
        }




    }
}