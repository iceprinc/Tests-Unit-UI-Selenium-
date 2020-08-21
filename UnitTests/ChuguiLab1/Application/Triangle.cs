using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class Triangle
    {
        double a, b, c;
        public void SetSides(double A, double B, double C)
        {
            a = A;
            b = B;
            c = C;
        }
        public double Area()
        {
            if (a < 0 || b < 0 || c < 0)
            {
                throw new FormatException("Side < 0");
            }
            if (((a + b) > c) & ((a + c) > b) & ((b + c) > a))
            {
                double p = (a + b + c) / 2; //34
                double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));//34*6*9*19 = 186.772588
                return area;
            }
            else
            {
                throw new ArgumentException("Not triangle");
            }
        }
    }
}
