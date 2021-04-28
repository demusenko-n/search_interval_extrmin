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
            do
            {
                double x1 = 0.75 * a + 0.25 * b;        //x1 = (a + x2) / 2
                double x2 = 0.5 * a + 0.5 * b;          //x2 = (a + b) / 2
                double x3 = 0.25 * a + 0.75 * b;        //x3 = (x2 + b) / 2
                

                //Console.WriteLine($"a = {a:F4} | x1 = {x1:F4} | x2 = {x2:F4} | x3 = {x3:F4} | b = {b:F4} |");

                if (function(x1) > function(x2) && function(x2) > function(x3))
                {
                    a = x2;
                }
                else if (function(x1) < function(x2) && function(x2) < function(x3))
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