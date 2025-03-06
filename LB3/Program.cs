using LB3.Task_1;
using LB3.Task_2;
using LB3;

class Program
{

    static void Main()
    {
        // you can switch some task to OFF state
        bool Task1 = true;
        bool Task2 = true;
        bool Task3 = true;

        int[] array = { 1,5,8,11,23,678,33,55,111,3467,895,3,51,8 };
        MyArray myArray = new MyArray(array);

        // TASK 1
        if (Task1)
        {
            myArray.Show();
            myArray.Show("My array");
        }

        // TASK 2
        if (Task2)
        {
            Console.WriteLine(myArray.Max() + "\n");
            Console.WriteLine(myArray.Min() + "\n");
            Console.WriteLine(myArray.Avg() + "\n");
            Console.WriteLine(myArray.Search(5) + "\n");
        }

        // TASK 3
        if (Task3)
        {
            myArray.SortAsc();
            myArray.Show();

            myArray.SortDesc();
            myArray.Show();

            myArray.SortByParam(true);
            myArray.Show();
        }

    }
}