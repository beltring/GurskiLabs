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
        Button button1;
        RadioButton radioButton1;
        TextBox textBox1;
        TextBox textBox2;
        TextBox textBox3;
        public Form1()
        {
            InitializeComponent();
            button1 = new Button();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();

            CreateButton(button1);
            CreateTextBox(textBox1,"0", 71, 288);
            CreateTextBox(textBox2, "10", 71, 321);
            CreateTextBox(textBox3, "1", 71, 353);
            CreateRadioButton(radioButton1, "Метод трапеций", 18, 143);
            CreateRadioButton(radioButton2, "Метод левых прямоугольников", 18, 166);
            CreateRadioButton(radioButton3, "Метод правых прямоугольников", 18, 189);
            CreateRadioButton(radioButton4, "Метод средних прямоугольников", 18, 212);

            radioButton1.CheckedChanged += new EventHandler(radioButton1_CheckedChanged);
            radioButton2.CheckedChanged += new EventHandler(radioButton2_CheckedChanged);
            radioButton3.CheckedChanged += new EventHandler(radioButton3_CheckedChanged);
            radioButton4.CheckedChanged += new EventHandler(radioButton4_CheckedChanged);
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

                calculate.b = 5;

                label6.Text = calculate.Trapezium().ToString();
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

                label6.Text = calculate.LeftRect().ToString();
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

                label6.Text = calculate.RightRect().ToString();
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

                label6.Text = calculate.MiddleRect().ToString();
                calculate.DrawMiddleRect(ref chart1);
                calculate.DrawIntegral(ref chart1);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void CreateButton(Button button1)
        {
            button1.Text = "Выход";
            button1.Size = new Size(129, 23);
            button1.Location = new Point(43, 396);
            button1.Click += new EventHandler(button1_Click);
            Controls.Add(button1);
        }
        public void CreateRadioButton(RadioButton radioButton, string text, int x, int y)
        {
            radioButton.Text = text;
            radioButton.Size = new Size(195, 17);
            radioButton.Location = new Point(x, y);
            Controls.Add(radioButton);
        }

        public void CreateTextBox(TextBox textBox, string text, int x, int y)
        {
            textBox.Text = text;
            textBox.Size = new Size(101, 20);
            textBox.Location = new Point(x, y);
            Controls.Add(textBox);
        }
    }
}
