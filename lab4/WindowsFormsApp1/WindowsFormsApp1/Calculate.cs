using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    abstract class Calculate
    {
        public double a; //нижний предел
        public double b; //верхний предел
        public double step; //шаг

        public Calculate()
        {
            a = 0;
            b = 10;
            step = 1;
        }

        public Calculate(double a1, double b1, double step1)
        {
            a = a1;
            b = b1;
            step = step1;
        }

        public abstract double Func(double x);

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
        public void DrawMiddleRect(ref Chart chart1)
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

        public void DrawTrapezium(ref Chart chart1)
        {
            chart1.Series[0].Points.Clear();
            double y;

            for (double x = a; x <= b; x += step)
            {
                y = Func(x);

                chart1.Series[0].Points.AddXY(x, y);
            }
        }
        public void DrawLeftRect(ref Chart chart1)
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

        public void DrawRightRect(ref Chart chart1)
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

        public void DrawIntegral(ref Chart chart1)
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

        public void DrawIntegral2(ref Chart chart1)
        {
            chart1.Series[2].Points.Clear();
            //chart1.Series[0].BorderWidth = 3;

            for (double i = a; i <= b; i += step)
            {
                double x = i;
                double y = Func(i);

                chart1.Series[2].Points.AddXY(x, y);
            }
        }


    }
}
