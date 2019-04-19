using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace lab7
{
    class DivUr
    {
        private double a;
        private double b;
        private double step;

        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }
        public double Step { get => step; set => step = value; }

        public DivUr(double a1, double b1, double step1)
        {
            a = a1;
            b = b1;
            step = step1;
        }

        public virtual double Func(double x, double y)
        {
            return Math.Sin(x) + y;

        }

        public void MethodEilera(ref Chart chart1, ref DataGridView dataGridView1)
        {
            double n = (b - a) / step;
            double x = 0, y = 0;

            chart1.Series[0].Points.AddXY(x, y);

            for (int i = 1; i <= n; i++)
            {
                x = a + i * step;
                y = y + step * Func(x, y);

                CreateResult(ref dataGridView1, x, y, i);

                chart1.Series[0].Points.AddXY(x, y);

            }

        }

        public void MethodTr(ref Chart chart1, ref DataGridView dataGridView1)
        {
            double n = (b - a) / step;
            double k1, k2, x = 0, y = 0;

            chart1.Series[0].Points.AddXY(x, y);

            for (int i = 1; i <= n; i++)
            {
                k1 = Func(x, y);
                k2 = Func(x + step, k1);
                x = a + i * step;
                y = y + (step / 2.5) * (k1 + k2);

                CreateResult(ref dataGridView1, x, y, i);

                chart1.Series[0].Points.AddXY(x, y);

            }
        }

        public void MethodEng4(ref Chart chart1, ref DataGridView dataGridView1)
        {
            double n = (b - a) / step;
            double k1, k2, k3, k4, x = 0, y = 0;

            chart1.Series[0].Points.AddXY(x, y);

            for (int i = 1; i <= n; i++)
            {
                x = a + i * step;
                k1 = step * Func(x, y);
                k2 = step * Func(x , y + k1 / 2.0);
                k3 = step * Func(x , y + k2 / 2);
                k4 = step * Func(x + step, y + k3);
                y = y + (k1 + k2 + k3 + k4) / 4;

                CreateResult(ref dataGridView1, x, y, i);

                chart1.Series[0].Points.AddXY(x, y);

            }
        }

        public void MethodEng3(ref Chart chart1, ref DataGridView dataGridView1)
        {
            double n = (b - a) / step;
            double k1, k2, k3, x = 0, y = 0;

            chart1.Series[0].Points.AddXY(x, y);

            for (int i = 1; i <= n; i++)
            {
                x = a + i * step;
                k1 = step * Func(x, y);
                k2 = step * Func(x, y + k1 / 2.0);
                k3 = step * Func(x + step, y + 2 * k2 + k1);
                y = y + (k1 + 3.5 * k2 + k3) / 6;

                CreateResult(ref dataGridView1, x, y, i);
                CreateFile(x, y, i);

                chart1.Series[0].Points.AddXY(x, y);

            }
        }

        private void CreateResult(ref DataGridView dataGridView1, double x, double y, int i)
        {
            dataGridView1.Columns.Add("n", "n" + i);
            dataGridView1[i, 0].Value = Math.Round(x, 3);

            dataGridView1[i, 1].Value = Math.Round(y, 3);
        }

        public virtual void CreateFile(double x, double y, int i)
        {
            using (FileStream fstream = new FileStream(@"d:\Study\COURSE_TWO\visual enviroment\4sem\labs\lab7\ur.txt", FileMode.Append))
            {
                string str = "n" + i + "{ x:" + Math.Round(x, 3) + " y:" + Math.Round(y, 3) + "}\n";
                byte[] array = System.Text.Encoding.Default.GetBytes(str);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
            }
        }
    }
}
