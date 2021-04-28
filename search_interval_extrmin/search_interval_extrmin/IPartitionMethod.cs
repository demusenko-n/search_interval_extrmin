using System;

namespace IntervalHelper
{
    public interface IPartitionMethod
    {
        public double Calculate(Func<double, double> function, double a, double b, double eps);
    }
}