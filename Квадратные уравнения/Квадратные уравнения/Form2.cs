using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Квадратные_уравнения
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private double a, b, c;

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked == false && radioButton2.Checked == false)
                { MessageBox.Show("Выберите способ решения"); }
                else
                {
                    if (Convert.ToDouble(textBox1.Text) == 0)
                    {
                        richTextBox1.Clear();
                        richTextBox1.AppendText("Коэффицент A не должен быть равен 0");
                    }
                    else if (radioButton1.Checked == true)//Дискрименант
                    {
                        try
                        {
                            richTextBox1.Clear();
                            a = Convert.ToDouble(textBox1.Text);
                            b = Convert.ToDouble(textBox2.Text);
                            c = Convert.ToDouble(textBox3.Text);
                            richTextBox1.AppendText(a + "x^2 + " + b + "x +" + c + " =0 \n");
                            double d = Math.Pow(b, 2) - (4 * a * c);

                            if (d < 0) { richTextBox1.AppendText(" Решения нет , дискриминант меньше 0"); }
                            else
                            {

                                double s = Math.Sqrt(d);
                                s = Math.Round(s, 3);
                                richTextBox1.AppendText("D = " + b + "^2 +(4 * " + a + " * " + c + ") = " + d + "\n");
                                double x1 = Math.Round((-b + s) / (2 * a), 3);
                                double x2 = Math.Round((-b - s) / (2 * a), 3);
                                richTextBox1.AppendText("x1 = (" + (-b).ToString() + " + sqrt(" + d + ") /(2 *" + a + ") = " + x1 + "\n");
                                richTextBox1.AppendText("x1 = (" + (-b).ToString() + " - sqrt(" + d + ") /(2 *" + a + ") = " + x2 + "\n");

                            }
                        }
                        catch { MessageBox.Show("Не верно введенны данные"); }
                    }
                    else if (radioButton2.Checked == true)//Виета
                    {
                        try
                        {
                            richTextBox1.Clear();
                            a = Convert.ToDouble(textBox1.Text) / Convert.ToDouble(textBox1.Text);
                            b = Convert.ToDouble(textBox2.Text) / Convert.ToDouble(textBox1.Text);
                            c = Convert.ToDouble(textBox3.Text) / Convert.ToDouble(textBox1.Text);
                            richTextBox1.AppendText(a + "x^2 + " + b + "x + " + c + " =0 \n");
                            double d = Math.Pow(b, 2) - (4 * a * c);
                            if (d < 0) { richTextBox1.AppendText(" Решения нет"); }
                            else
                            {

                                double s = Math.Sqrt(d);
                                s = Math.Round(s, 3);
                                richTextBox1.AppendText(" {x1 + x2 = " + b + "\n");
                                richTextBox1.AppendText(" {x1 * x2 = " + c + "\n");
                                double x1 = Math.Round((-b + s) / (2 * a), 3);
                                double x2 = Math.Round((-b - s) / (2 * a), 3);
                                richTextBox1.AppendText("x1 = (" + x1 + ")\n");
                                richTextBox1.AppendText("x1 = (" + x2 + ")\n");

                            }
                        }
                        catch { MessageBox.Show("Не верно введенны данные"); }
                    }
                    

                }
            }
            catch { MessageBox.Show("Не верно введенны данные"); }
        }
    }
}
