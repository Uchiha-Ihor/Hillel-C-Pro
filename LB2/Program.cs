using LB2.Task_1;
using LB2.Task_2;

class Program
{
    // you can switch some task to OFF state
    private bool Task1 = true;
    private bool Task2 = true;
    private bool Task3 = true;


    void Main()
    {
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
            
        }

    }
}