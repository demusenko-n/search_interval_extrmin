using System;

namespace IntervalHelper
{
    /// <summary>
    /// Метод золотого сечения
    /// </summary>
    public class PartitionGoldenRatio : IPartitionMethod
    {
        private double GoldenNumberReversed { get; } = (Math.Sqrt(5) - 1) / 2;
        public double Calculate(Func<double, double> function, double a, double b, double eps)
        {
            double x1 = b - GoldenNumberReversed * (b - a);
            double x2 = a + GoldenNumberReversed * (b - a);

            do
            {
                Console.WriteLine($"a = {a:F4} | x1 = {x1:F4} | x2 = {x2:F4} | b = {b:F4} |");

                if (function(x1) < function(x2))
                {
                    b = x2;
                    x2 = x1;
                    x1 = b - GoldenNumberReversed * (b - a);
                }
                else
                {
                    a = x1;
                    x1 = x2;
                    x2 = a + GoldenNumberReversed * (b - a);
                }
            } while (Math.Abs(b - a) >= eps);

            return (a + b) / 2;
        }
    }
}