using LB6;

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
            Play Gamlet = new Play("Gamlet", "William Shakespeare", "Tragedy", 1600);
            
            Gamlet.StartPlay();

        }
        
        // TASK 2
        if (Task2)
        {
            Store store;

            using (store = new Store("Products 24", "Shevchenko St, 1", Store.StoreType.Grocery))
            {
                store.DisplayInfo();
            }

            store.DisplayInfo();

        }

        // TASK 3
        if (Task3)
        {
            Store store;
            Play Gamlet;

            using (Gamlet = new Play("Gamlet", "William Shakespeare", "Tragedy", 1600))
            {
                Gamlet.StartPlay();
                Gamlet.DisplayInfo();
            }
            Gamlet.DisplayInfo();


            using (store = new Store("Products 24", "Shevchenko St, 1", Store.StoreType.Grocery))
            {
                store.DisplayInfo();
            }

            store.DisplayInfo();
        }

        //GC.Collect();
        //GC.WaitForPendingFinalizers();
        //Console.WriteLine("Програма завершила роботу.");
    }
}