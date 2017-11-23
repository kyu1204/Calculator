using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        List<string> input; //전체 연산 행
        string view; //보여지는 숫자
        double total = 0; //실제 값의 숫자
        double number = 0;

        public Form1()
        {
            InitializeComponent();

            input = new List<string>(); //초기화
            listBox1.DataSource = input;

        }
        private void ShowText(string v) //total 값 화면에 띄우기
        {
            textBox1.Text = v;
            textBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            view += "1";
            ShowText(view);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            view += "2";
            ShowText(view);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            view += "3";
            ShowText(view);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            view += "4";
            ShowText(view);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            view += "5";
            ShowText(view);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            view += "6";
            ShowText(view);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            view += "7";
            ShowText(view);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            view += "8";
            ShowText(view);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            view += "9";
            ShowText(view);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            view += "0";
            ShowText(view);
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            if (view != null)
            {
                if (total != 0)
                {
                    total += double.Parse(view);
                    input.Add(view);
                    input.Add("+");
                    view = null;
                }
                else
                {
                    total = double.Parse(view);
                    input.Add(view);
                    input.Add("+");
                    view = null;
                }
            }
            else
            {
                total += double.Parse(input[input.Count - 2]);
                input.Add(input[input.Count - 2]);
                input.Add("+");
            }

            ShowText(total.ToString());
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            if (view != null)
            {
                if (total != 0)
                {
                    total -= double.Parse(view);
                    input.Add(view);
                    input.Add("-");
                    view = null;
                }
                else
                {
                    total = double.Parse(view);
                    input.Add(view);
                    input.Add("-");
                    view = null;
                }
            }
            else
            {
                total -= double.Parse(input[input.Count - 2]);
                input.Add(input[input.Count - 2]);
                input.Add("-");
            }

            ShowText(total.ToString());
        }

        private void Multi_Click(object sender, EventArgs e)
        {
            if (view != null)
            {
                if (total != 0)
                {
                    total *= double.Parse(view);
                    input.Add(view);
                    input.Add("*");
                    view = null;
                }
                else
                {
                    total = double.Parse(view);
                    input.Add(view);
                    input.Add("*");
                    view = null;
                }
            }
            else
            {
                total *= double.Parse(input[input.Count - 2]);
                input.Add(input[input.Count - 2]);
                input.Add("*");
            }

            ShowText(total.ToString());
        }

        private void Division_Click(object sender, EventArgs e)
        {
            view += "÷";
            ShowText(view);
            //input.Add(total);
            //input.Add("/");
            //total = "";
            //ShowText();
        }

        private void Negative_Click(object sender, EventArgs e)
        {
            int temp = int.Parse(view);
            temp = temp * -1;
            view = temp.ToString();
            ShowText(view);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            view = null;
            textBox1.Clear();
            ShowText(view);
        }

        private void ButtonDot_Click(object sender, EventArgs e)
        {

        }

        private void Result_Click(object sender, EventArgs e)
        {
            switch(input[input.Count-1])
            {
                case "+":
                    total += double.Parse(view);
                    break;
                case "-":
                    total -= double.Parse(view);
                    break;
                case "*":
                    total *= double.Parse(view);
                    break;
                case "/":
                    total += double.Parse(view);
                    break;
            }
            ShowText(total.ToString());
        }
    }
}
