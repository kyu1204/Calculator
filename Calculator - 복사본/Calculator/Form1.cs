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
        List<string> historys; //연산 기록;
        List<string> input; //계산 할 전체 연산 행
        string memory;
        string history; //현재 연산 기록
        string view; //현재 입력한 숫자
        string total; //연산 완료된 숫자

        public Form1()
        {
            InitializeComponent();

            input = new List<string>(); //초기화
            historys = new List<string>();
            listBox1.DataSource = historys;
            listBox1.Invalidate();

        }
        private void ShowHistory(string v)
        {
            textBox2.Text = v;
            textBox2.Refresh();
        }
        private void ShowText(string v) //total 값 화면에 띄우기
        {
            textBox1.Text = v;
            textBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            view += "1";
            history += "1";
            ShowText(view);
            ShowHistory(history);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            view += "2";
            history += "2";

            ShowHistory(history);
            ShowText(view);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            view += "3";
            history += "3";

            ShowHistory(history);
            ShowText(view);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            view += "4";
            history += "4";

            ShowHistory(history);
            ShowText(view);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            view += "5";
            history += "5";

            ShowHistory(history);
            ShowText(view);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            view += "6";
            history += "6";

            ShowHistory(history);
            ShowText(view);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            view += "7";
            history += "7";

            ShowHistory(history);
            ShowText(view);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            view += "8";
            history += "8";

            ShowHistory(history);
            ShowText(view);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            view += "9";
            history += "9";

            ShowHistory(history);
            ShowText(view);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            view += "0";
            history += "0";

            ShowHistory(history);
            ShowText(view);
        }

        private string ResultValue(double view)
        {
            double result = 0;
            input.Add(view.ToString());

            for (int i = 0; i < input.Count-1; ++i)
            {
                if(i == 0)
                {
                    result = double.Parse(input[i]);
                }
                else
                {
                    switch(input[i])
                    {
                        case "+":
                            result += double.Parse(input[i + 1]);
                            break;
                        case "-":
                            result -= double.Parse(input[i + 1]);
                            break;
                        case "*":
                            result *= double.Parse(input[i + 1]);
                            break;
                        case "/":
                            if (double.Parse(input[i + 1]) == 0)
                            {

                                return "0 으로는 나눌 수 없습니다.";
                            }
                            else
                            {
                                result /= double.Parse(input[i + 1]);
                            }
                            break;
                    }
                }
            }

            return result.ToString();
        }

        private int DivisionError(string total)
        {
            if(total.CompareTo("0 으로는 나눌 수 없습니다.") == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private void RebindingListBox(ListBox listbox, List<string> list)
        {
            listbox.DataSource = null;
            listbox.DataSource = list;
        }



        private void Plus_Click(object sender, EventArgs e)
        {
            if (view != null)
            {
                history += "+";
                ShowHistory(history);
                if (total == null)
                {
                    total = view;
                    input.Add(view);
                    input.Add("+");
                    view = null;
                }
                else
                {
                    total = ResultValue(double.Parse(view));
                    if (DivisionError(total) == 0)
                    {
                        ShowText(total);
                        view = null;
                        total = null;
                        history = null;
                        input.Clear();
                    }
                    else
                    {
                        input.Add("+");
                        view = null;
                        ShowText(total);
                    }
                }
            }
            else
            {
                if (total != null)
                {
                    history += input[input.Count - 2];
                    history += "+";
                    ShowHistory(history);
                    total = ResultValue(double.Parse(input[input.Count - 2]));
                    input.Add("+");
                    ShowText(total);
                }
            }
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            if (view != null)
            {
                history += "-";
                ShowHistory(history);
                if (total == null)
                {
                    total = view;
                    input.Add(view);
                    input.Add("-");
                    view = null;
                }
                else
                {
                    total = ResultValue(double.Parse(view));
                    if (DivisionError(total) == 0)
                    {
                        ShowText(total);
                        view = null;
                        total = null;
                        history = null;
                        input.Clear();
                    }
                    else
                    {
                        input.Add("-");
                        view = null;
                        ShowText(total);
                    }
                }
            }
            else
            {
                if (total != null)
                {
                    history += input[input.Count - 2];
                    history += "-";
                    ShowHistory(history);
                    total = ResultValue(double.Parse(input[input.Count - 2]));
                    input.Add("-");
                    ShowText(total);
                }
            }
        }

        private void Multi_Click(object sender, EventArgs e)
        {
            if (view != null)
            {
                history += "×";
                ShowHistory(history);
                if (total == null)
                {
                    total = view;
                    input.Add(view);
                    input.Add("*");
                    view = null;
                }
                else
                {
                    total = ResultValue(double.Parse(view));
                    if (DivisionError(total) == 0)
                    {
                        ShowText(total);
                        view = null;
                        total = null;
                        history = null;
                        input.Clear();
                    }
                    else
                    {
                        input.Add("*");
                        view = null;
                        ShowText(total);
                    }
                }
            }
            else
            {
                if (total != null)
                {
                    history += input[input.Count - 2];
                    history += "×";
                    ShowHistory(history);
                    total = ResultValue(double.Parse(input[input.Count - 2]));
                    input.Add("×");
                    ShowText(total);
                }
            }
        }

        private void Division_Click(object sender, EventArgs e)
        {
            if (view != null)
            {
                history += "÷";
                ShowHistory(history);
                if (total == null)
                {
                    total = view;
                    input.Add(view);
                    input.Add("/");
                    view = null;
                }
                else
                {
                    total = ResultValue(double.Parse(view));
                    if (DivisionError(total) == 0)
                    {
                        ShowText(total);
                        view = null;
                        total = null;
                        history = null;
                        input.Clear();
                    }
                    else
                    {
                        input.Add("/");
                        view = null;
                        ShowText(total);
                    }
                }
            }
            else
            {
                if (total != null)
                {
                    history += input[input.Count - 2];
                    history += "÷";
                    ShowHistory(history);
                    total = ResultValue(double.Parse(input[input.Count - 2]));
                    input.Add("÷");
                    ShowText(total);
                }
            }
        }

        private void Negative_Click(object sender, EventArgs e)
        {
            int temp = int.Parse(view);
            temp = temp * -1;
            view = temp.ToString();
            history = temp.ToString();
            ShowHistory(history);
            ShowText(view);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            view = null;
            history = null;
            total = null;
            textBox1.Clear();
            textBox2.Clear();
            ShowHistory(history);
            ShowText(view);
        }

        private void ButtonDot_Click(object sender, EventArgs e)
        {

        }

        private void Result_Click(object sender, EventArgs e)
        {
            if (view != null)
            {
                total = ResultValue(double.Parse(view));
                if (DivisionError(total) == 0)
                {
                    ShowText(total);
                    view = null;
                    total = null;
                    history = null;
                    input.Clear();
                }
                else
                {
                    history += "=";
                    history += total;
                    ShowHistory(history);

                    view = null;
                    ShowText(total);

                    input.Clear();
                    historys.Add(history);
                    historys.Add("---------------------------------------------");
                    RebindingListBox(listBox1, historys);
                    history = null;

                }
            }
            else
            {
                ShowText(total);
            }
        }

        private void M_plus_Click(object sender, EventArgs e)
        {
            if (memory == null)
            {
                if (view != null)
                {
                    if (total == null)
                    {
                        total = view;
                        view = null;
                        memory = string.Copy(total);
                        total = null;
                    }
                    else
                    {
                        total = ResultValue(double.Parse(view));
                        if (DivisionError(total) == 0)
                        {
                            ShowText(total);
                            view = null;
                            total = null;
                            history = null;
                            input.Clear();
                        }
                        else
                        {
                            view = null;
                            history = null;
                            memory = string.Copy(total);
                            total = null;
                            input.Clear();
                        }
                    }                   
                }
            }
            else
            {
                if (view != null)
                {
                    if (total == null)
                    {
                        total = view;
                        view = null;
                        double tmp = double.Parse(memory);
                        tmp += double.Parse(total);
                        memory = tmp.ToString();
                        total = null;
                    }
                    else
                    {
                        total = ResultValue(double.Parse(view));
                        if (DivisionError(total) == 0)
                        {
                            ShowText(total);
                            view = null;
                            total = null;
                            history = null;
                            input.Clear();
                        }
                        else
                        {
                            view = null;
                            history = null;

                            double tmp = double.Parse(memory);
                            tmp += double.Parse(total);
                            memory = tmp.ToString();
                            total = null;
                            input.Clear();
                        }
                    }
                }
            }
        }

        private void MR_Click(object sender, EventArgs e)
        {
            history = null;
            view = null;
            history += memory;

            view += memory;
            ShowHistory(history);
            ShowText(view);
        }

        private void MC_Click(object sender, EventArgs e)
        {
            memory = null;
        }

        private void M_minus_Click(object sender, EventArgs e)
        {
            if (memory != null)
            {
                if (view != null)
                {
                    if (total == null)
                    {
                        total = view;
                        view = null;
                        double tmp = double.Parse(memory);
                        tmp -= double.Parse(total);
                        memory = tmp.ToString();
                        total = null;
                    }
                    else
                    {
                        total = ResultValue(double.Parse(view));
                        if (DivisionError(total) == 0)
                        {
                            ShowText(total);
                            view = null;
                            total = null;
                            history = null;
                            input.Clear();
                        }
                        else
                        {
                            view = null;
                            history = null;

                            double tmp = double.Parse(memory);
                            tmp -= double.Parse(total);
                            memory = tmp.ToString();
                            total = null;
                            input.Clear();
                        }
                    }
                }
            }
        }
    }
}
