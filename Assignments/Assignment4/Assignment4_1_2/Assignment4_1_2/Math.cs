using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4_1_2
{
    internal class Math : ICalculator
    {
        public double Add(double a, double b) => a + b;
        public double Subtract(double a, double b) => a - b;
        public double Multiply(double a, double b) => a * b;
        public double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divided by 0");
            return a / b;
        }
    }
}
