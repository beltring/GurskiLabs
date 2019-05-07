using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class CalculationMethod
    {
        private double a; //нижний предел
        private double b; //верхний предел
        private double step; //шаг

        public CalculationMethod(double a, double b, double step)
        {
            this.a = a;
            this.b = b;
            this.step = step;
        }

        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }
        public double Step { get => step; set => step = value; }

        private static double Func(double x)
        {
            return Math.Sqrt(1 - 0.5 * Math.Sin(x) * Math.Sin(x));
        }

        public double Trapezium()
        {
            double result = 0;

            for (double x = a; x <= b; x += step)
            {
                result += step * (Func(x) + Func(x + step)) / 2;
            }

            return result;
        }
        public double LeftRect()
        {
            double result = 0;

            for (double x = a; x <= b; x += step)
            {
                result += Func(x) * step;
            }

            return result;
        }
        public double RightRect()
        {
            double result = 0;

            for (double x = a; x <= b; x += step)
            {
                result += Func(x + step) * step;
            }

            return result;
        }
        public double MiddleRect()
        {
            double result = 0;

            for (double x = a; x <= b; x += step)
            {
                result += Func(x + step / 2) * step;
            }

            return result;
        }
    }
}
