using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LB1
{
    public static class Calculator
    {
        public static string Calculate(string a, string b, string operation)
        {
            try
            {
                double num1 = ParseNumber(a, b);
                double num2 = ParseNumber(b, a);

                

                switch (operation)
                {
                    case "+":
                        return Add(num1, num2);
                    case "-":
                        return Subtract(num1, num2);
                    case "*":
                        return Multiply(num1, num2);
                    case "/":
                        return Divide(num1, num2);
                    default:
                        return "operation does not exist";
                }
            }
            catch 
            {
                return "Example error:";
            }
        }

        private static double ParseNumber(string a, string b)
        {
            double res = 0;

            if (Regex.IsMatch(a, @"sin\s*(\d+)"))
            {
                Match match = Regex.Match(a, @"sin\s*(\d+)");
                res = Convert.ToDouble(match.Groups[1].Value);
                Sin(res);
            }
            else if (Regex.IsMatch(a, @"cos\s*(\d+)"))
            {
                Match match = Regex.Match(a, @"cos\s*(\d+)");
                res = Convert.ToDouble(match.Groups[1].Value);
                Cos(res);
            }
            else if (Regex.IsMatch(a, @"tan\s*(\d+)"))
            {
                Match match = Regex.Match(a, @"tan\s*(\d+)");
                res = Convert.ToDouble(match.Groups[1].Value);
                Tan(res);
            }
            else if (Regex.IsMatch(a, @"cot\s*(\d+)"))
            {
                Match match = Regex.Match(a, @"cot\s*(\d+)");
                res = Convert.ToDouble(match.Groups[1].Value);
                Cot(res);
            }

            else if (Regex.IsMatch(a, @"(\d+)\s*%"))
            {
                Match match = Regex.Match(a, @"(\d+)\s*%");
                res = Convert.ToDouble(match.Groups[1].Value);

                if (Regex.IsMatch(b, @"(\d+)\s*%"))
                {
                    throw new Exception();
                }

                //double num2 = CalculateNumberType(b, a);

                res = Convert.ToDouble(b) * (res / 100);
            }

            else if (Regex.IsMatch(a, @"!\s*(\d+)"))
            {
                Match match = Regex.Match(a, @"!\s*(\d+)");
                res = Convert.ToDouble(match.Groups[1].Value);

                Factorial(res);
            }
            else 
            {
                res = Convert.ToDouble(a);
            }

            return res;
        }

        private static string Add(double a, double b) => (a + b).ToString();
        private static string Subtract(double a, double b) => (a - b).ToString();
        private static string Multiply(double a, double b) => (a * b).ToString();
        private static string Divide(double a, double b) => (a / b).ToString();

        //private static double Power(double a, double b) => Math.Pow(a, b);
        //private static double SquareRoot(double a) => Math.Sqrt(a);
        //private static double Modulus(double a) => Math.Abs(a);

        private static double Factorial(double a)
        {
            if (a < 0) return 0;

            double res = 1;

            for (int i = 1; i <= a; i++)
            {
                res *= i;
            }

            return res;
        }

        private static double Sin(double a) => Math.Sin(a);
        private static double Cos(double a) => Math.Cos(a);
        private static double Tan(double a) => Math.Tan(a);
        private static double Cot(double a) => Math.Cos(a) / Math.Sin(a);
    }
}
