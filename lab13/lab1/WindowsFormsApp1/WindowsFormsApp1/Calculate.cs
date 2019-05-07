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
        private double a; //нижний предел
        private double b; //верхний предел
        private double step; //шаг

        public Calculate()
        {
            a = 0;
            b = 10;
            step = 1;
        }

        public Calculate(double a, double b, double step)
        {
            this.a = a;
            this.b = b;
            this.step = step;
        }

        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }
        public double Step { get => step; set => step = value; }
        
        public static double Func(double x)
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

            chart1.SaveImage(@"d:\Study\COURSE_TWO\visual enviroment\4sem\labs\lab13\lab1\WindowsFormsApp1\WindowsFormsApp1\Resources\Chart.jpeg",
                System.Drawing.Imaging.ImageFormat.Jpeg);
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
            chart1.SaveImage(@"d:\Study\COURSE_TWO\visual enviroment\4sem\labs\lab13\lab1\WindowsFormsApp1\WindowsFormsApp1\Resources\Chart.jpeg",
                System.Drawing.Imaging.ImageFormat.Jpeg);
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
            chart1.SaveImage(@"d:\Study\COURSE_TWO\visual enviroment\4sem\labs\lab13\lab1\WindowsFormsApp1\WindowsFormsApp1\Resources\Chart.jpeg",
                System.Drawing.Imaging.ImageFormat.Jpeg);
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
            chart1.SaveImage(@"d:\Study\COURSE_TWO\visual enviroment\4sem\labs\lab13\lab1\WindowsFormsApp1\WindowsFormsApp1\Resources\Chart.jpeg",
                System.Drawing.Imaging.ImageFormat.Jpeg);
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
            chart1.SaveImage(@"d:\Study\COURSE_TWO\visual enviroment\4sem\labs\lab13\lab1\WindowsFormsApp1\WindowsFormsApp1\Resources\Chart.jpeg",
                System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
