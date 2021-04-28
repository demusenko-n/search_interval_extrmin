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
            Console.WriteLine($"({a}; {b})");

            IPartitionMethod method = new PartitionDichotomy();
            //IPartitionMethod method = new PartitionGoldenRatio();

            double result = method.Calculate(Function, a, b, Epsilon);
            Console.WriteLine($"Res = {result:F4}");
        }
    }
}
