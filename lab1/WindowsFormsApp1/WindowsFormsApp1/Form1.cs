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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                double
                    a = Convert.ToDouble(textBox1.Text),
                    b = Convert.ToDouble(textBox2.Text),
                    step = Convert.ToDouble(textBox3.Text);

                label6.Text = Calculate.Trapezium(a, b, step).ToString();
                Calculate.DrawTrapezium(ref chart1, a, b, step);
                Calculate.DrawIntegral(ref chart1, a, b, step);
                
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                double
                    a = Convert.ToDouble(textBox1.Text),
                    b = Convert.ToDouble(textBox2.Text),
                    step = Convert.ToDouble(textBox3.Text);

                label6.Text = Calculate.LeftRect(a, b, step).ToString();
                Calculate.DrawLeftRect(ref chart1, a, b, step);
                Calculate.DrawIntegral(ref chart1, a, b, step);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                double
                    a = Convert.ToDouble(textBox1.Text),
                    b = Convert.ToDouble(textBox2.Text),
                    step = Convert.ToDouble(textBox3.Text);

                label6.Text = Calculate.RightRect(a, b, step).ToString();
                Calculate.DrawRightRect(ref chart1, a, b, step);
                Calculate.DrawIntegral(ref chart1, a, b, step);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                double
                     a = Convert.ToDouble(textBox1.Text),
                     b = Convert.ToDouble(textBox2.Text),
                     step = Convert.ToDouble(textBox3.Text);

                label6.Text = Calculate.MiddleRect(a, b, step).ToString();
                Calculate.DrawMiddleRect(ref chart1, a, b, step);
                Calculate.DrawIntegral(ref chart1, a, b, step);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*chart1.ChartAreas[0].AxisX.Minimum = -0.1;
            chart1.ChartAreas[0].AxisX.Maximum = 1.1;
            chart1.ChartAreas[0].AxisY.Minimum = -0.1;
            chart1.ChartAreas[0].AxisY.Maximum = 0.15;
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 0.05;
            chart1.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(textBox1.Text);
            chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(textBox2.Text);*/
        }
    }
}
