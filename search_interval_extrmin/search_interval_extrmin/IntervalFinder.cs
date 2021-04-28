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

    /// <summary>
    /// Метод половинного деления (Дихотомии)
    /// </summary>
    public static class PartitionDichotomy
    {
        public static double Calculate(Func<double, double> function, double a, double b, double eps)
        {
            do
            {
                double x1 = 0.75 * a + 0.25 * b;       //x1 = (a + x2) / 2
                double x2 = 0.5 * a + 0.5 * b;         //x2 = (a + b) / 2
                double x3 = 0.125 * a + 0.625 * b;     //x3 = (x2 + b) / 2

                if (function(x1) > function(x2) && function(x2) > function(x3))
                {
                    a = x2;
                    //b = b;
                }
                else if (function(x1) < function(x2) && function(x2) < function(x3))
                {
                    //a = a;
                    b = x2;
                }
                else /*if(function(x1) > function(x2) && function(x2) < function(x3))*/
                {
                    a = x1;
                    b = x3;
                }
            } while (Math.Abs(b - a) >= eps); //Varies the argument
            // or
            // while (Math.Abs(function(b) - function(a)) >= eps); //Varies the function value
            return (a + b) / 2;
        }
    }
}
