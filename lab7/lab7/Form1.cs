using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("n", "");
            dataGridView1.Rows.Add("X");
            dataGridView1.Rows.Add("Y");

            double a = Convert.ToDouble(textBox1.Text),
                      b = Convert.ToDouble(textBox2.Text),
                      step = Convert.ToDouble(textBox3.Text);
            DivUr ur = null;

            if (radioButton5.Checked)
            {
                ur = new DivUr(a, b, step);
            }
            else if(radioButton6.Checked)
            {
                ur = new DivUr2(a, b, step);
                
            }
            else if(radioButton7.Checked)
            {
                ur = new DivUr3(a, b, step);
            }

            if (radioButton1.Checked)
            {
                ur.MethodEilera(ref chart1, ref dataGridView1);
            }else if (radioButton2.Checked)
            {
                ur.MethodTr(ref chart1, ref dataGridView1);
            }else if (radioButton4.Checked)
            {
                ur.MethodEng4(ref chart1, ref dataGridView1);
            }else if (radioButton3.Checked)
            {
                ur.MethodEng3(ref chart1, ref dataGridView1);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton5.Checked = true;

            button1_Click(sender, e);
        }
    }
}
