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
        string memory; //M 버튼에 의해 저장되고 로드되는 memory 값을 담는 변수
        string history; //현재 연산 기록 --> 텍스트박스(기록 모니터)와 링크되는 변수
        string view; //현재 입력된 숫자 --> 텍스트박스(모니터)와 링크되는 변수
        string total; //연산 완료된 숫자 --> view변수로 받아온 숫자를 여러 연산 기호 버튼에 따라 계산된 최종 값

        public Form1()
        {
            InitializeComponent();

            input = new List<string>(); //초기화
            historys = new List<string>();
            listBox1.DataSource = historys; //Listbox에 컬렉션 연결
            listBox1.Invalidate();

        }
/// <summary>
/// Event 처리 부분
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)  //0~9 숫자 버튼 처리
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

        private void Plus_Click(object sender, EventArgs e) //+버튼 처리
        {
            if (view != null) //view 값이 null이 아님 즉 값이 입력 되었을때에 처리
            {
                history += "+"; //history --> '직전값' '+' 
                ShowHistory(history); //화면에 띄우기
                if (total == null) //total 값이 null 즉 첫번째로 입력된 숫자
                {
                    total = view; //첫 번째 입력 값이기 때문에 최종값 = 현재값
                    input.Add(view); //계산을 위한 연산식에 추가
                    input.Add("+"); //다음에 입력받을 숫자와 + 하려는 것이기 때문에 + 기호 추가
                    view = null; //값이 저장 되었으니 입력된 현재값은 제거
                }
                else //total 값이 null이 아님 즉 첫번째 값이 아님
                {
                    total = ResultValue(double.Parse(view)); //현재 값을 넘겨주어 기록된 연산기록에 의거해 최종값을 계산함
                    if (DivisionError(total) == 0) //중간에 0으로 나누는 에러가 있을시 에러 처리
                    {
                        ShowText(total);
                        view = null;
                        total = null;
                        history = null;
                        input.Clear();
                    }
                    else 
                    {
                        input.Add("+"); //에러가 없다면 이후 값과 + 하는것이기 때문에 + 연산기호 추가
                        view = null; 
                        ShowText(total); //화면에 계산된 최종값 띄워주기
                    }
                }
            }
            else //view값이 null 즉 아무숫자입력없이 +연산기호만 눌렸을 경우
            {
                if (total != null) //직전 연산값이 있을경우
                {
                    history += input[input.Count - 2]; //연산기호의 마지막 item(Count-1)은 연산기호 즉 직전 값을 계속 더하기위해 연산기호 전인 마지막 입력 값을 가져옴 (Count-2)
                    history += "+"; //다음 연산이 + 이기 때문에 기호 추가
                    ShowHistory(history); //연산 기록 화면의 띄움
                    total = ResultValue(double.Parse(input[input.Count - 2])); //값을 가져와서 실제로 계산 하는 작업 수행
                    input.Add("+"); //실제 연산기호에 + 추가
                    ShowText(total); //화면에 최종 연산 값 출력
                }
            }
        }

        private void Minus_Click(object sender, EventArgs e) //+와 동일
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

        private void Multi_Click(object sender, EventArgs e) //+와 동일
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

        private void Division_Click(object sender, EventArgs e) //+와 동일
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
            if (!view.Contains("."))
            {
                history += ".";
                view += ".";
                ShowHistory(history);
                ShowText(view);
            }
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
/// <summary>
/// 내부에서 사용하는 사용자 메서드 부분
/// </summary>
/// <param name="v"></param>
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



       
    }
}
