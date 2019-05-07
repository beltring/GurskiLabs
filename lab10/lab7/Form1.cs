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
        private List<DivUr> urs = new List<DivUr>();
        private List<string> typeEquation = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("n", "");
            dataGridView1.Rows.Add("X");
            dataGridView1.Rows.Add("Y");

            string name;

            if (urs.Count == 0)
            {
                MessageBox.Show("Добавьте уравнения в список");
            }
            else
            {
                for (int i = 0; i < urs.Count; i++)
                {
                    if (typeEquation[i] == "MethodEilera")
                    {
                        name = "MethodEilera" + i;
                        urs[i].MethodEilera(ref chart1, ref dataGridView1, name);
                    }
                    else if (typeEquation[i] == "MethodTr")
                    {
                        name = "MethodTr" + i;
                        urs[i].MethodTr(ref chart1, ref dataGridView1, name);
                    }
                    else if (typeEquation[i] == "MethodEng4")
                    {
                        name = "MethodEng4" + i;
                        urs[i].MethodEng4(ref chart1, ref dataGridView1, name);
                    }
                    else if (typeEquation[i] == "MethodEng3")
                    {
                        name = "MethodEng3" + i;
                        urs[i].MethodEng3(ref chart1, ref dataGridView1, name);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton5.Checked = true;

            //button1_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox1.Text),
                      b = Convert.ToDouble(textBox2.Text),
                      step = Convert.ToDouble(textBox3.Text);
            DivUr ur = null;
            
            if (radioButton5.Checked)
            {
                ur = new DivUr(a, b, step);
                urs.Add(ur);
            }
            else if (radioButton6.Checked)
            {
                ur = new DivUr2(a, b, step);
                urs.Add(ur);
            }
            else if (radioButton7.Checked)
            {
                ur = new DivUr3(a, b, step);
                urs.Add(ur);
            }

            if (radioButton1.Checked)
            {
                typeEquation.Add("MethodEilera");
            }
            else if (radioButton2.Checked)
            {
                typeEquation.Add("MethodTr");
            }
            else if (radioButton4.Checked)
            {
                typeEquation.Add("MethodEng4");
            }
            else if (radioButton3.Checked)
            {
                typeEquation.Add("MethodEng3");
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(urs.Count == 0)
            {
                MessageBox.Show("Список пустой");
            }
            else
            {
                urs.Clear();
                typeEquation.Clear();
            }
            
        }
    }
}
