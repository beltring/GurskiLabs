using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    class Calculate
    {
        public static double Func(double x)
        {
            return Math.Sqrt(1 - 0.5 * Math.Sin(x) * Math.Sin(x));
        }

        public static double Trapezium(double a, double b, double step)
        {
            double result = 0;

            for (double x = a; x <= b; x += step)
            {
                result += step * (Func(x) + Func(x + step)) / 2;
            }

            return result;
        }
        public static double LeftRect(double a, double b, double step)
        {
            double result = 0;

            for (double x = a; x <= b; x += step)
            {
                result += Func(x) * step;
            }

            return result;
        }
        public static double RightRect(double a, double b, double step)
        {
            double result = 0;

            for (double x = a; x <= b; x += step)
            {
                result += Func(x + step) * step;
            }

            return result;
        }
        public static double MiddleRect(double a, double b, double step)
        {
            double result = 0;

            for (double x = a; x <= b; x += step)
            {
                result += Func(x + step / 2) * step;
            }

            return result;
        }
        public static void DrawMiddleRect(ref Chart chart1, double a, double b, double step)
        {
            chart1.Series[0].Points.Clear();
            double y;

            for (double x = a; x <= b; x += step)
            {
                y = Func(x + step / 2);

                chart1.Series[0].Points.AddXY(x, y);
                if (x + step <= b)
                {
                    chart1.Series[0].Points.AddXY(x + step, y);
                }
            }
        }

        public static void DrawTrapezium(ref Chart chart1, double a, double b, double step)
        {
            chart1.Series[0].Points.Clear();
            double y;

            for (double x = a; x <= b; x += step)
            {
                y = Func(x);

                chart1.Series[0].Points.AddXY(x, y);
            }
        }
        public static void DrawLeftRect(ref Chart chart1, double a, double b, double step)
        {
            chart1.Series[0].Points.Clear();
            double y;

            for (double x = a; x <= b; x += step)
            {
                y = Func(x);

                chart1.Series[0].Points.AddXY(x, y);
                if (x + step <= b)
                {
                    chart1.Series[0].Points.AddXY(x + step, y);
                }

            }
        }

        public static void DrawRightRect(ref Chart chart1, double a, double b, double step)
        {
            chart1.Series[0].Points.Clear();
            double y;

            for (double x = a; x <= b; x += step)
            {
                y = Func(x + step);

                chart1.Series[0].Points.AddXY(x, y);
                if (x + step <= b)
                {
                    chart1.Series[0].Points.AddXY(x + step, y);
                }
            }
        }

        public static void DrawIntegral(ref Chart chart1, double a, double b, double step)
        {
            chart1.Series[1].Points.Clear();
            chart1.Series[0].BorderWidth = 3;

            for (double i = a; i <= b; i += step)
            {
                double x = i;
                double y = Func(i);

                chart1.Series[1].Points.AddXY(x, y);
            }
        }
    }
}
