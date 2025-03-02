// LB2 Task 1

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB2
{
    internal class Product : Money
    {
        public string Name { get; set; }

        public void ReducePrice()
        {
            int command = 0;

            while (true)
            {
                decimal tempCoin = 0;

                try
                {
                    Console.WriteLine("What are you wont to reduce?");
                    Console.WriteLine("Choose command (1-6): ");
                    Console.WriteLine("1 - dollars price");
                    Console.WriteLine("2 - euros price");
                    Console.WriteLine("3 - hryvnias price");
                    Console.WriteLine("4 - cents price");
                    Console.WriteLine("5 - euroCents price");
                    Console.WriteLine("6 - kopecks price");

                    command = Convert.ToInt32(Console.ReadLine());

                    switch (command)
                    {
                        case 1:
                            Console.WriteLine("How much is the reduction in dollars?");
                            dollars -= Convert.ToDecimal(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine("How much is the reduction in euros?");
                            euros -= Convert.ToDecimal(Console.ReadLine());
                            break;
                        case 3:
                            Console.WriteLine("How much is the reduction in hryvnias?");
                            hryvnias -= Convert.ToDecimal(Console.ReadLine());
                            break;
                        case 4:
                            Console.WriteLine("How much is the reduction in cents?");
                            tempCoin = Convert.ToDecimal(Console.ReadLine());
                            if (tempCoin > 0 && tempCoin < 99)
                            {
                                cents -= tempCoin;
                            }
                            else
                            {
                                throw new Exception("Invalid input. Please enter a valid number.");
                            }
                            break;
                        case 5:
                            Console.WriteLine("How much is the reduction in euroCents?");
                            tempCoin = Convert.ToDecimal(Console.ReadLine());
                            if (tempCoin > 0 && tempCoin < 99)
                            {
                                euroCents -= tempCoin;
                            }
                            else
                            {
                                throw new Exception("Invalid input. Please enter a valid number.");
                            }
                            break;
                        case 6:
                            Console.WriteLine("How much is the reduction in kopecks?");
                            tempCoin = Convert.ToDecimal(Console.ReadLine());
                            if (tempCoin > 0 && tempCoin < 99)
                            {
                                kopecks -= tempCoin;
                            }
                            else
                            {
                                throw new Exception("Invalid input. Please enter a valid number.");
                            }
                            break;
                        default:
                            throw new Exception();

                    }

                    return;
                }
                catch (Exception ex)  
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void PrintProductProperty()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine($"Dollars: {dollars}, Cents: {cents}");
            Console.WriteLine($"Euros: {euros}, Euro Cents: {euroCents}");
            Console.WriteLine($"Hryvnias: {hryvnias}, Kopecks: {kopecks}");
        }

    }
}
