using LB4.Task_1;
using LB4.Task_2;
using LB4.Task_3;
using LB4.Task_4;

class Program
{

    static void Main()
    {
        // you can switch some task to OFF state
        bool Task1 = true;
        bool Task2 = true;
        bool Task3 = true;
        bool Task4 = true;


        // TASK 1
        if (Task1)
        {
            Employee manager = new Employee(1000);
            Employee programmer = new Employee(1500) ;

            Console.WriteLine(manager);
            Console.WriteLine(programmer);

            manager += 240;
            programmer -= 150;

            Console.WriteLine(manager);
            Console.WriteLine(programmer);

            Console.WriteLine(manager == programmer);
            Console.WriteLine(manager != programmer);

            Console.WriteLine(manager < programmer);
            Console.WriteLine(manager > programmer);
        }

        // TASK 2
        if (Task2)
        {
            City Zhytomyr = new City(261624);
            City Poltava = new City(279593);

            Console.WriteLine(Zhytomyr);
            Console.WriteLine(Poltava);

            Zhytomyr += 78000;
            Poltava -= 20750;

            Console.WriteLine(Zhytomyr);
            Console.WriteLine(Poltava);

            Console.WriteLine(Zhytomyr == Poltava);
            Console.WriteLine(Zhytomyr != 15000);

            Console.WriteLine(Zhytomyr < 300000);
            Console.WriteLine(Zhytomyr > Poltava);
        }

        // TASK 3
        if (Task3)
        {
            CreditCard Visa = new CreditCard(43500, 678);

            Console.WriteLine(Visa);

            Visa += 1700;

            Console.WriteLine(Visa);

            Visa -= 9850;

            Console.WriteLine(Visa);

            Console.WriteLine(Visa == 678);
            Console.WriteLine(Visa != 678);

            Console.WriteLine(Visa < 20000);
            Console.WriteLine(Visa > 11000);

        }

        // TASK 4
        if (Task4)
        {
            int colums = 24; int rows = 14;

            Matrix matrix1 = new Matrix(colums, rows);
            Matrix matrix2 = new Matrix(colums, rows);

            matrix1.GenMatrixValue();
            matrix2.GenMatrixValue();

            Console.WriteLine(matrix1 + Environment.NewLine);
            Console.WriteLine(matrix2 + Environment.NewLine);

            matrix1 = matrix1 + matrix2;

            Console.WriteLine(matrix1 + Environment.NewLine);

            matrix1 = matrix1 - matrix2;

            Console.WriteLine(matrix1 + Environment.NewLine);

            matrix1 = matrix1 * matrix2;

            Console.WriteLine(matrix1 + Environment.NewLine);

            matrix1 = matrix1 * 2;

            Console.WriteLine(matrix1 + Environment.NewLine);

            Console.WriteLine(matrix1 == matrix2);

            Console.WriteLine(matrix1 != matrix2);
        }
    }
}