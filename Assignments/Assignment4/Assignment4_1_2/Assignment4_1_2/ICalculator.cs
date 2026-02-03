using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4_1_2
{
    internal interface ICalculator
    {
        double Add(double a, double b);
        double Subtract(double a, double b);
        double Multiply(double a, double b);
        double Divide(double a, double b);
    }
}
