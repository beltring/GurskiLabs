using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab9
{
    public partial class Form1 : Form
    {
        public Thread myThread1, myThread2;

        Graphics gr;       //объявляем объект - графику, на которой будем рисовать
        Pen p;             //объявляем объект - карандаш, которым будем рисовать контур
        SolidBrush fon;    //объявляем объект - заливки, для заливки соответственно фона
        SolidBrush fig;    //и внутренности рисуемой фигуры


        int rad;          // переменная для хранения радиуса рисуемых кругов
        Random rand;      // объект, для получения случайных чисел
        public Form1()
        {
            InitializeComponent();
            myThread1 = new Thread(new ThreadStart(IntegralThread));
            myThread2 = new Thread(new ThreadStart(DrawThread));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myThread1.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            myThread1.Resume();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myThread1.Suspend();
        }

        private void IntegralThread()
        {
            Random rand = new Random();
            int choice;
            double a, b, step, result;
            int i = 0;

            while (i < 1000)
            {
                choice = rand.Next(0, 4);
                a = rand.Next(-5, 5);
                b = rand.Next(8, 15);
                step = Convert.ToDouble(rand.Next(1, 11)) / 10;
                /*label2.Text = a.ToString();
                label4.Text = b.ToString();
                label6.Text = step.ToString();*/

                Integral integral = new Integral(a, b, step);

                if (choice == 0)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        integral.DrawTrapezium(ref chart1);
                        integral.DrawIntegral(ref chart1);
                    });
                    result = Math.Round(integral.Trapezium(), 6);
                    
                }
                else if (choice == 1)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        integral.DrawRightRect(ref chart1);
                        integral.DrawIntegral(ref chart1);
                    });
                    result = Math.Round(integral.RightRect(), 6);
                }
                else if (choice == 2)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        integral.DrawLeftRect(ref chart1);
                        integral.DrawIntegral(ref chart1);
                    });
                    result = Math.Round(integral.LeftRect(), 6);
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        integral.DrawMiddleRect(ref chart1);
                        integral.DrawIntegral(ref chart1);
                    });
                    result = Math.Round(integral.MiddleRect());
                }
                Action action = () => label2.Text = a.ToString();
                label4.Text = b.ToString();
                label6.Text = step.ToString();
                label8.Text = result.ToString();
                // Свойство InvokeRequired указывает, нeжно ли обращаться к контролу с помощью Invoke
                if (InvokeRequired)
                    Invoke(action);
                else
                    action();

                i++;
                Thread.Sleep(300);
            }
        }
        void DrawCircle(int x, int y)
        {
            int xc, yc;
            xc = x - rad;
            yc = y - rad;
            gr.FillEllipse(fig, xc, yc, rad, rad);

            gr.DrawEllipse(p, xc, yc, rad, rad);

        }
        private void DrawThread()
        {
            gr = pictureBox1.CreateGraphics();

            p = new Pen(Color.Lime);          
            fon = new SolidBrush(Color.Black); 
            fig = new SolidBrush(Color.Purple);

            rad = 40;                     
            rand = new Random(); 

            gr.FillRectangle(fon, 0, 0, pictureBox1.Width, pictureBox1.Height);

            int x, y;

            for (int i = 0; i < 1000; i++)
            {
                x = rand.Next(pictureBox1.Width);
                y = rand.Next(pictureBox1.Height);
                DrawCircle(x, y);
                Thread.Sleep(300);
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            myThread2.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            myThread2.Suspend();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            myThread2.Resume();
        }
    }
}
