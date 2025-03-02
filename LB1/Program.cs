using LB1;
using System.Net.Security;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Available operations: +, -, *, /, !, %, sin, cos, tag, cot");

            Console.WriteLine("Write first number");
            string a = Console.ReadLine();

            Console.WriteLine("Choose operation");
            string operation = Console.ReadLine();

            Console.WriteLine("Write second number");
            string b = Console.ReadLine();

            Console.WriteLine("Answer: " + Calculator.Calculate(a, b, operation) +"\n\n");

        }

        

    }



}

class Man
{ 
    public virtual void Print()
    {
        Console.WriteLine("HI");
    }


}

class ultraman : Man
{
    public override void Print()
    {
        Console.WriteLine("He");
    }
}