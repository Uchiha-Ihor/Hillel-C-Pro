using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LB8
{
    internal class BarberShop
    {
        private int number_of_seats;

        private int visitors = 0;

        private Thread Barber;

        private readonly object lockObject = new object();

        internal BarberShop(int number_of_seats)
        { 
            this.number_of_seats = number_of_seats;

            Barber = new Thread(BarberWorking);

            Barber.Start();
        }

        internal void AddVisitors()
        {
            lock (lockObject)
            {
                Console.WriteLine("Enter numbers of visitors in Barber Shop");
                visitors = Convert.ToInt32(Console.ReadLine());

                if (visitors > number_of_seats)
                {
                    visitors = number_of_seats;
                }
                else
                {
                    Console.WriteLine("No free seats, visitor left.");
                }
            }
        }

        void BarberWorking()
        {
            int current_visitors;

            while (true)
            {
                lock (lockObject)
                {
                    current_visitors = visitors;
                }
                if (current_visitors > 0)
                {
                    for (int i = 0; i < current_visitors; i++)
                    {
                        Console.WriteLine("Barber start cut visitor " + i);
                        Thread.Sleep(1000);
                        Console.WriteLine("Barber end cut visitor " + i);
                        Thread.Sleep(200);
                    }
                    lock (lockObject)
                    {
                        visitors = 0;
                    }

                    Console.WriteLine(Environment.NewLine + "Barber sleep" + Environment.NewLine);
                }
                else
                {
                    Thread.Sleep(200);

                }

            }
        }

    }
}