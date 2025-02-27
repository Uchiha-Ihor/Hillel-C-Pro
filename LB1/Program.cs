using LB1;

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