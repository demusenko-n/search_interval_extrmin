using System;

namespace IntervalHelper
{
    /// <summary>
    /// Метод половинного деления (Дихотомии)
    /// </summary>
    public class PartitionDichotomy : IPartitionMethod
    {
        public double Calculate(Func<double, double> function, double a, double b, double eps)
        {
            int i = 1;

            Console.WriteLine("i\t|   a\t|  x1\t|  x2\t|  x3\t|  b\t|  f1\t|  f2\t|  f3\t|");
            Console.WriteLine(new string('-', 73) );

            do
            {
                double x1 = 0.75 * a + 0.25 * b;        //x1 = (a + x2) / 2
                double x2 = 0.5 * a + 0.5 * b;          //x2 = (a + b) / 2
                double x3 = 0.25 * a + 0.75 * b;        //x3 = (x2 + b) / 2

                double f1 = function(x1);
                double f2 = function(x2);
                double f3 = function(x3);

                Console.WriteLine($"{i++}\t|{a:F4}\t|{x1:F4}\t|{x2:F4}\t|{x3:F4}\t|{b:F4}\t|{f1:F4}\t|{f2:F4}\t|{f3:F4}\t|");

                if (f1 > f2 && f2 > f3)
                {
                    a = x2;
                }
                else if (f1 < f2 && f2 < f3)
                {
                    b = x2;
                }
                else
                {
                    a = x1;
                    b = x3;
                }
            } while (Math.Abs(b - a) >= eps); 
            return (a + b) / 2;
        }
    }
}