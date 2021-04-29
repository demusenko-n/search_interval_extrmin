using System;
using IntervalHelper;

namespace Lab4
{
    internal class Lab4Main
    {
        private static double Epsilon { get; } = Math.Pow(10, -6);
        private static Func<double, double> Function { get; } = 
            x => 1 - Math.Pow(1 - Math.Pow((x - 6) / 5, 4), 0.25);
        private static void Main(string[] args)
        {
            (double a, double b) = IntervalFinder.GetIntervalMin(Function, 2, 0.2);
            Console.WriteLine($"Interval: ({a:F5}; {b:F5})");

            PartitionGoldenRatio method = new();

            double result = method.Calculate(x=>Math.Sin(x), 2, 6, Epsilon);
            Console.WriteLine($"Res = {result:F5}");

        }
    }
}
