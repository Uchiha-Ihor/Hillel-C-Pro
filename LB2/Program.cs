using LB2;

class Program
{
    static void Main()
    {
        Product Laptop = new Product();

        Laptop.Name = "Laptop";

        Money money = Laptop;

        money.PrintMoney();

        Laptop.ReducePrice();

        //money.PrintMoney();

        Laptop.PrintProductProperty();
    }
}