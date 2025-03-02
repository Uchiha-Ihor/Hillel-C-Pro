using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB2
{
    internal class Money
    {
        public decimal dollars { get; set; }
        public decimal euros { get; set; }
        public decimal hryvnias { get; set; }

        public decimal cents { get; set; }
        public decimal euroCents { get; set; }
        public decimal kopecks { get; set; }

        public Money()
        {
            SetValue();
        }

        private void SetValue()
        {
            while (true)
            {
                decimal tempCoin = 0;

                try
                {
                    if (dollars == 0)
                    {
                        Console.WriteLine("Set Dollars");
                        dollars = Convert.ToDecimal(Console.ReadLine());
                    }
                    if (euros == 0)
                    {
                        Console.WriteLine("Set Euros");
                        euros = Convert.ToDecimal(Console.ReadLine());
                    }
                    if (hryvnias == 0)
                    {
                        Console.WriteLine("Set Hryvnias");
                        hryvnias = Convert.ToDecimal(Console.ReadLine());
                    }


                    if (cents == 0)
                    {
                        Console.WriteLine("Set cents");
                        tempCoin = Convert.ToDecimal(Console.ReadLine());
                        if (tempCoin > 0 && tempCoin < 99)
                        {
                            cents = tempCoin;
                        }
                        else
                        {
                            throw new Exception("Invalid input. Please enter a valid number.");
                        }
                    }
                    if (euroCents == 0)
                    {
                        Console.WriteLine("Set Euro Cents");
                        tempCoin = Convert.ToDecimal(Console.ReadLine());
                        if (tempCoin > 0 && tempCoin < 99)
                        {
                            euroCents = tempCoin;
                        }
                        else
                        {
                            throw new Exception("Invalid input. Please enter a valid number.");
                        }
                    }
                    if (kopecks == 0)
                    {
                        Console.WriteLine("Set Kopecks");
                        tempCoin = Convert.ToDecimal(Console.ReadLine());
                        if (tempCoin > 0 && tempCoin < 99)
                        {
                            kopecks = tempCoin;
                        }
                        else
                        {
                            throw new Exception("Invalid input. Please enter a valid number.");
                        }
                    }

                    return;
                }
                catch (Exception ex)  
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        public void PrintMoney()
        {
            Console.WriteLine($"Dollars: {dollars}, Cents: {cents}");
            Console.WriteLine($"Euros: {euros}, Euro Cents: {euroCents}");
            Console.WriteLine($"Hryvnias: {hryvnias}, Kopecks: {kopecks}");
        }


    }
}
