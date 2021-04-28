﻿using System;
using IntervalHelper;

namespace Lab4
{
    class Lab4Main
    {
        static double Function(double x)
            => 1 - Math.Pow(1 - Math.Pow((x - 6) / 5, 4), 0.25);


        static void Main(string[] args)
        {
            IntervalFinder intervalFinder = new();
            
            (double a, double b) = intervalFinder.GetIntervalMin(/*Function*/ x=>x*x*x*x-x*x*x, 2, 0.2);
            Console.WriteLine($"({a}; {b})");
        }
    }
}
