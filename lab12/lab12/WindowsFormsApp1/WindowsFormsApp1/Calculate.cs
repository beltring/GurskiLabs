using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    class Calculate
    {
        private const int port = 11000;
        private const string dnsName = "DESKTOP-F1RD9OJ";

        private double a; //нижний предел
        private double b; //верхний предел
        private double step; //шаг

        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }
        public double Step { get => step; set => step = value; }

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

        private static double Func(double x)
        {
            return Math.Sqrt(1 - 0.5 * Math.Sin(x) * Math.Sin(x));
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

        public void ConnectServer(Form1 form, int n)
        {
            try
            {
                TcpClient client = new TcpClient(dnsName, port);
             
                NetworkStream stream = client.GetStream();

                string dataSend = n + "_" + a + "_" + b + "_" + step;
                byte[] data = System.Text.Encoding.UTF8.GetBytes(dataSend);
                stream.Write(data, 0, data.Length);
                
                data = new byte[32];
                StringBuilder response = new StringBuilder();

                do
                {
                    int bytes = stream.Read(data, 0, data.Length);
                    response.Append(Encoding.UTF8.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable);

                form.label6.Text = response.ToString();

                stream.Close();
                client.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }
        }
    }
}
