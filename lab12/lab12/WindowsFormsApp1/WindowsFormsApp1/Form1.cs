﻿using System;
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

                Calculate calculate = new Calculate(a,b,step);
                
                calculate.ConnectServer(this, 0);
                calculate.DrawTrapezium(ref chart1);
                calculate.DrawIntegral(ref chart1);
                
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

                Calculate calculate = new Calculate(a, b, step);

                calculate.ConnectServer(this, 1);
                calculate.DrawLeftRect(ref chart1);
                calculate.DrawIntegral(ref chart1);
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

                Calculate calculate = new Calculate(a, b, step);

                calculate.ConnectServer(this, 2);
                calculate.DrawRightRect(ref chart1);
                calculate.DrawIntegral(ref chart1);
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

                Calculate calculate = new Calculate(a, b, step);

                calculate.ConnectServer(this, 3);
                calculate.DrawMiddleRect(ref chart1);
                calculate.DrawIntegral(ref chart1);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
