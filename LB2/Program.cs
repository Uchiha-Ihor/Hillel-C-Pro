using LB2.Task_1;
using LB2.Task_2;
using LB2.Task_3;

class Program
{
    
    static void Main()
    {
        // you can switch some task to OFF state
        bool Task1 = true;
        bool Task2 = true;
        bool Task3 = true;

        // TASK 1
        if (Task1)
        {
            Product Laptop = new Product("Laptop");

            Money money = Laptop;

            money.PrintMoney();

            Laptop.ReducePrice();

            //money.PrintMoney();

            Laptop.PrintProductProperty();
        }

        // TASK 2
        if (Task2)
        {
            MusicalInstrument[] instruments = {
                new Violin(),
                new Trombone(),
                new Ukulele(),
                new Cello()
            };

            foreach (var instr in instruments)
            {
                instr.Show();
                instr.Sound();
                instr.Desc();
                instr.History();
                Console.WriteLine();
            }
        }

        // TASK 3
        if (Task3)
        {
            DecimalNumber decimalNumber = new DecimalNumber(255);

            Console.WriteLine("Binary: " + decimalNumber.ToBin());
            Console.WriteLine("Octal: " + decimalNumber.ToOct());
            Console.WriteLine("Hexadecimal: " + decimalNumber.ToHex());
        }

    }
}