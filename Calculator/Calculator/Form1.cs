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
        string number; //입력된 숫자
        double number2 = 0; //계산될 숫자

        public Form1()
        {
            InitializeComponent();

            input = new List<string>(); //초기화

        }
        private void ShowText() //number 값 화면에 띄우기
        {
            textBox1.Text = number;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            number += "1"; 
            ShowText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            number += "2";
            ShowText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            number += "3";
            ShowText();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            number += "4";
            ShowText();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            number += "5";
            ShowText();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            number += "6";
            ShowText();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            number += "7";
            ShowText();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            number += "8";
            ShowText();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            number += "9";
            ShowText();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            number += "0";
            ShowText();
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            //input.Add(number);
            //input.Add("+");
            if (number2 != 0)
            {
                number2 += double.Parse(number);
                number = number2.ToString();
                number2 = 0;
            }
            else
            {
                number2 = double.Parse(number);
                number = "";
            }
            ShowText();
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            input.Add(number);
            input.Add("-");
            number = "";
            ShowText();
        }

        private void Multi_Click(object sender, EventArgs e)
        {
            input.Add(number);
            input.Add("*");
            number = "";
            ShowText();
        }

        private void Division_Click(object sender, EventArgs e)
        {
            input.Add(number);
            input.Add("/");
            number = "";
            ShowText();
        }

        private void Negative_Click(object sender, EventArgs e)
        {
            int temp = int.Parse(number);
            temp = temp * -1;
            number = temp.ToString();
            ShowText();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            number = "";
            input.Clear();
            ShowText();
        }

        private void ButtonDot_Click(object sender, EventArgs e)
        {

        }

        private void Result_Click(object sender, EventArgs e)
        {
            double num = 0.0;
            double num2 = 0.0;
            
           foreach(string item in input)
            {
                switch(item)
                {
                    case "+":
                        {
                            break;
                        }
                    case "-":
                        {
                            break;
                        }
                    case "*":
                        {
                            break;
                        }
                    case "/":
                        {
                            break;
                        }
                    default: //숫자
                        {
                            num = double.Parse(item);
                            break;
                        }
                }
            }
        }
    }
}
