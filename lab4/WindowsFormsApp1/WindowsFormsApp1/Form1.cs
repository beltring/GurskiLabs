using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e){}

        private void radioButton2_CheckedChanged(object sender, EventArgs e){}

        private void radioButton3_CheckedChanged(object sender, EventArgs e){}

        private void radioButton4_CheckedChanged(object sender, EventArgs e){}

        private void Form1_Load(object sender, EventArgs e)
        {
            this.button2_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double
                   a = Convert.ToDouble(textBox1.Text),
                   b = Convert.ToDouble(textBox2.Text),
                   step = Convert.ToDouble(textBox3.Text);

            Calculate integral = null,
                  integral1 = null;

            if (radioButton5.Checked)
            {
                integral = new Function1(a, b, step);
            }
            else if (radioButton6.Checked)
            {
                integral = new Function2(a, b, step);
            }
            else if (radioButton7.Checked)
            {
                integral = new Function3(a, b, step);
            }
            else if (radioButton8.Checked)
            {
                integral = new Function4(a, b, step);
            }

            if (radioButton12.Checked)
            {
                integral1 = new Function1(a, b, step);
            }
            else if (radioButton11.Checked)
            {
                integral1 = new Function2(a, b, step);
            }
            else if (radioButton10.Checked)
            {
                integral1 = new Function3(a, b, step);
            }
            else if (radioButton9.Checked)
            {
                integral1 = new Function4(a, b, step);
            }

            //draw
            if (radioButton1.Checked)
            {
                label6.Text = integral.Trapezium().ToString();
                integral.DrawTrapezium(ref chart1);
                integral.DrawIntegral(ref chart1);

            }
            else if (radioButton2.Checked)
            {
                label6.Text = integral.LeftRect().ToString();
                integral.DrawLeftRect(ref chart1);
                integral.DrawIntegral(ref chart1);
            }
            else if (radioButton3.Checked)
            {
                label6.Text = integral.RightRect().ToString();
                integral.DrawRightRect(ref chart1);
                integral.DrawIntegral(ref chart1);
            }
            else if (radioButton4.Checked)
            {
                label6.Text = integral.MiddleRect().ToString();
                integral.DrawMiddleRect(ref chart1);
                integral.DrawIntegral(ref chart1);
            }

            if (radioButton16.Checked)
            {
                label7.Text = integral1.Trapezium().ToString();
                integral1.DrawIntegral2(ref chart1);
            }
            else if (radioButton15.Checked)
            {

                label7.Text = integral1.LeftRect().ToString();
                integral1.DrawIntegral2(ref chart1);
            }
            else if (radioButton14.Checked)
            {

                label7.Text = integral1.RightRect().ToString();
                integral1.DrawIntegral2(ref chart1);
            }
            else if (radioButton13.Checked)
            {

                label7.Text = integral1.MiddleRect().ToString();
                integral1.DrawIntegral2(ref chart1);
            }
        }
    }
}
