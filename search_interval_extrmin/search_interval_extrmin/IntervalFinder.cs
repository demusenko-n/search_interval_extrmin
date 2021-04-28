using System;

namespace IntervalHelper
{
    public static class IntervalFinder
    {
        private static int GetSign(Func<double, double> function, double x0, double step)
            => Math.Sign(function(x0) - function(x0 + step));

        public static (double, double) GetIntervalMin(Func<double, double> function, double x0, double step)
        {
            int sign = GetSign(function, x0, step);

            double xkPrev = x0;
            double xk = xkPrev + step * sign;


            while (function(xk) < function(xkPrev))
            {
                xkPrev = xk;
                xk += step * sign;
            }

            return sign == 1 ? (xkPrev - step * sign, xk) : (xk, xkPrev - step * sign);
        }
    }
}
